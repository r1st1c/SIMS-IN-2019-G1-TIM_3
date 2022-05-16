using Projekat_SIMS_IN_TIM3.ManagerWindows;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class RoomService
    {

        public int getMaxId()
        {
            return this.roomRepository.next_id();
        }
        public Room GetById(int id)
        {
            return this.roomRepository.GetById(id);
        }
        public Room GetByName(string name)
        {
            var list = this.roomRepository.GetAll();
            foreach (var item in list)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            Debug.WriteLine("Room not found!");
            return null;
        }

        public List<Room> GetAll()
        {
            return this.roomRepository.GetAll();
        }

        public (bool,bool) Create(Room room)
        {
            var list = this.roomRepository.GetAll();
            foreach(var existingRoom in list)
            {
                if(existingRoom.Name == room.Name)
                {
                    return (false,false);
                }
            }
            return (this.roomRepository.Create(room),true);
        }

        public bool UpdateUsingSameName(Room room)
        {
            return this.roomRepository.Update(room);
        }
        public bool UpdateUsingNewName(Room room)
        {
            var list = this.roomRepository.GetAll();
            foreach (var existingRoom in list)
            {
                if (existingRoom.Name == room.Name)
                {
                    return false;
                }
            }
            return this.roomRepository.Update(room);    
        }

        public bool DeleteById(int id)
        {
            this.equipmentRepository.MoveEquipmentToDefaultRoomAfterDeletingRoom(id);
            return this.roomRepository.DeleteById(id);
        }
        /// CRUD
        /// 
        ///////////////////////////////////////////////////////////////////////////////// 
        /// 
        /// BASIC RENOVATION
        public List<RenovationTerm> BasicRenovation(int roomId, DateTime start, DateTime end,int duration)
        {
            var dates = new List<DateTime>();

            for (var dt = start; dt <= end; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }
            var appointments = this.appointmentRepository.GetAll();
            for (int i = 0; i < dates.Count;i++)
            {
                foreach(var appointment in appointments)
                {
                    if(dates[i] == appointment.StartTime && roomId == appointment.RoomNumber)
                    {
                        dates.RemoveAt(i);
                    }
                }
            }
            List<RenovationTerm> retVal = new List<RenovationTerm>();
            duration--;//first day is already included so we subrtact that day from total amount of days
            int renovationId=0;
            for (int i = 0; i < dates.Count-duration; i++)
            {
                if (dates[i].AddDays(duration) == dates[i + duration])
                {
                    retVal.Add(new RenovationTerm(renovationId++,dates[i].ToShortDateString(),dates[i+duration].ToShortDateString()));
                }
            }
            return retVal;
        }

        public bool ScheduleRenovation(int roomId, string start, string end,string description)
        {
            return this.roomRepository.ScheduleRenovation(roomId, start, end, description);
        }

        public void UpdateDisabledFields()
        {
            List<RenovationTerm> renovationTerms = this.roomRepository.GetRenovationSchedules();
            List<Room> roomList = this.roomRepository.GetAll();
            foreach (Room room in roomList)
            {
                foreach(RenovationTerm renovationTerm in renovationTerms)
                {
                    if (room.Id == renovationTerm.Id)
                    {
                        DateTime dateStart = DateTime.ParseExact(renovationTerm.startDate, "dd-MMM-yy", null);
                        DateTime dateEnd = DateTime.ParseExact(renovationTerm.endDate, "dd-MMM-yy", null);
                        dateEnd = dateEnd.AddHours(23);
                        dateEnd = dateEnd.AddMinutes(59);
                        dateEnd = dateEnd.AddSeconds(59);
                        if (DateTime.Now >= dateStart && DateTime.Now <= dateEnd && room.Disabled==0)
                        {
                            room.Disabled = 1;
                            this.roomRepository.Update(room);
                        }
                        if (DateTime.Now > dateEnd)
                        {
                            room.Disabled = 0;
                            this.roomRepository.Update(room);
                            this.roomRepository.DeleteScheduling(renovationTerm);
                        }
                    }
                }
            }
        }
        public List<RenovationTerm> GetRenovationSchedules()
        {
            return this.roomRepository.GetRenovationSchedules();
        }
        /// BASIC RENOVATION
        /// 
        ///////////////////////////////////////////////////////////////////////////////// 
        /// 
        /// MERGE
        public List<MergeRenovationTerm> GetMergeRenovationAvailableTerms(MergeRenovationQuery mergeRenovationQuery)
        {
            var IntersectedAvailabeDays = FindIntersectedAvailableDays(mergeRenovationQuery);

            List<MergeRenovationTerm> retVal = new List<MergeRenovationTerm>();
            int duration = mergeRenovationQuery.Duration;
            duration--;//first day is already included so we subrtact that day from total amount of days'
            int renovationId = 0;

            for (int i = 0; i < IntersectedAvailabeDays.Count - duration; i++)
            {
                if (IntersectedAvailabeDays[i].AddDays(duration) == IntersectedAvailabeDays[i + duration])
                {
                    retVal.Add(new MergeRenovationTerm(renovationId++,
                                                            mergeRenovationQuery.RoomId1,
                                                            mergeRenovationQuery.RoomId2,
                                                            IntersectedAvailabeDays[i].ToShortDateString(), 
                                                            IntersectedAvailabeDays[i + duration].ToShortDateString(),
                                                                mergeRenovationQuery.Description,
                                                                mergeRenovationQuery.Name,
                                                                mergeRenovationQuery.RoomType));
                }
            }
            return retVal;
        }

        private List<DateTime> FindIntersectedAvailableDays(MergeRenovationQuery mergeRenovationQuery)
        {
            var FirstRoomAvailableDays = new List<DateTime>();
            var SecondRoomAvailableDays = new List<DateTime>();
            var allAppointments = this.appointmentRepository.GetAll();

            for (var dt = mergeRenovationQuery.Range.Start; dt <= mergeRenovationQuery.Range.End; dt = dt.AddDays(1))
            {
                FirstRoomAvailableDays.Add(dt);
                SecondRoomAvailableDays.Add(dt);
            }

            for (int i = 0; i < FirstRoomAvailableDays.Count; i++)
            {
                foreach (var appointment in allAppointments)
                {
                    if (FirstRoomAvailableDays[i].Date == appointment.StartTime.Date &&
                        mergeRenovationQuery.RoomId1 == appointment.RoomNumber)
                    {
                        FirstRoomAvailableDays.RemoveAt(i);
                    }

                    if (SecondRoomAvailableDays[i].Date == appointment.StartTime.Date &&
                        mergeRenovationQuery.RoomId2 == appointment.RoomNumber)
                    {
                        SecondRoomAvailableDays.RemoveAt(i);
                    }
                }
            }

            List<DateTime> IntersectedAvailabeDays = FirstRoomAvailableDays.Intersect(SecondRoomAvailableDays).ToList();
            return IntersectedAvailabeDays;
        }

        public bool ScheduleMerge(MergeRenovationTerm mergeRenovationTerm)
        {
            return this.roomRepository.ScheduleMerge(mergeRenovationTerm);
        }

        public void DisableMergingRooms()
        {
            List<MergeRenovationTerm> mergeRenovations = this.roomRepository.GetMergeSchedules();
            List<Room> existing = this.roomRepository.GetAll();
            foreach (var room in existing)
            {
                foreach (var renovationTerm in mergeRenovations)
                {
                    if (DateTime.Now >= DateTime.ParseExact(renovationTerm.StartingDate, "dd-MMM-yy", null) && 
                        (room.Id == renovationTerm.RoomId1 || room.Id == renovationTerm.RoomId2))
                    {
                        room.Disabled = 2;
                        this.roomRepository.Update(room);
                    }
                }
            }
        }

        public void ExecuteMerging()
        {
            List<MergeRenovationTerm> mergeRenovations = this.roomRepository.GetMergeSchedules();
            List<Room> existing = this.roomRepository.GetAll();
            uint floor=1;
            foreach (var renovationTerm in mergeRenovations)
            {
                bool tocreate = false;
                foreach (var room in existing)
                {
                    if (DateTime.Now > DateRange.GetLastMoment(DateTime.ParseExact(renovationTerm.EndingDate, "dd-MMM-yy", null)) &&
                        (room.Id == renovationTerm.RoomId1 || room.Id == renovationTerm.RoomId2))
                    {
                        floor = room.Floor;
                        tocreate = true;
                        this.roomRepository.DeleteById(room.Id);
                    }
                }

                if (tocreate)
                {
                    this.roomRepository.Create(new Room(this.roomRepository.next_id(), renovationTerm.Name,
                        renovationTerm.RoomType, floor, renovationTerm.Description, "No"));
                    this.roomRepository.DeleteMergeScheduling(renovationTerm);
                }
            }
        }

        /// MERGE
        /// 
        ///////////////////////////////////////////////////////////////////////////////// 
        /// 
        /// SPLIT
 
        public List<SplitRenovationTerm> GetSplitRenovationAvailableTerms(SplitRenovationQuery splitRenovationQuery)
        {
            var dates = new List<DateTime>();

            for (var dt = splitRenovationQuery.Range.Start; dt <= splitRenovationQuery.Range.End; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }
            //Debug.WriteLine("NUMBER OF DATES:" + dates.Count);
            var appointments = this.appointmentRepository.GetAll();
            for (int i = 0; i < dates.Count; i++)
            {
                //Debug.WriteLine("INDEX:" + i);
                foreach (var appointment in appointments)
                {
                    if (dates[i] == appointment.StartTime.Date && splitRenovationQuery.Roomtosplitid == appointment.RoomNumber)
                    {
                        dates.RemoveAt(i);
                    }
                }
            }
            List<SplitRenovationTerm> retVal = new List<SplitRenovationTerm>();
            int duration = splitRenovationQuery.Duration;
            duration--;//first day is already included so we subrtact that day from total amount of days
            int renovationId = 0;
            for (int i = 0; i < dates.Count - duration; i++)
            {
                if (dates[i].AddDays(duration) == dates[i + duration])
                {
                    retVal.Add(new SplitRenovationTerm(
                        renovationId++,
                        splitRenovationQuery.Roomtosplitid,
                        splitRenovationQuery.Newroomname1,
                        splitRenovationQuery.Newroomname2,
                        splitRenovationQuery.Newroomdescription1,
                        splitRenovationQuery.Newroomdescription2,
                        splitRenovationQuery.Newroomtype1,
                        splitRenovationQuery.Newroomtype2,
                        dates[i].ToShortDateString(),
                        dates[i+duration].ToShortDateString()
                        ));
                }
            }
            return retVal;
        }
        public bool ScheduleSplit(SplitRenovationTerm splitRenovationTerm)
        {
            return this.roomRepository.ScheduleSplit(splitRenovationTerm);
        }

        public void DisableSplittingRooms()
        {
            List<MergeRenovationTerm> mergeRenovations = this.roomRepository.GetMergeSchedules();
            List<Room> existing = this.roomRepository.GetAll();
            foreach (var room in existing)
            {
                foreach (var renovationTerm in mergeRenovations)
                {
                    if (DateTime.Now >= DateTime.ParseExact(renovationTerm.StartingDate, "dd-MMM-yy", null) &&
                        (room.Id == renovationTerm.RoomId1 || room.Id == renovationTerm.RoomId2))
                    {
                        room.Disabled = 2;
                        this.roomRepository.Update(room);
                    }
                }
            }
        }

        public RoomRepository roomRepository = new RoomRepository();
        public AppointmentRepository appointmentRepository = new AppointmentRepository();
        public EquipmentRepository equipmentRepository = new EquipmentRepository();
    }
}
