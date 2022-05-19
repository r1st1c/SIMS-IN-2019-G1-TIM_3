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

        public (bool, bool) Create(Room room)
        {
            var list = this.roomRepository.GetAll();
            foreach (var existingRoom in list)
            {
                if (existingRoom.Name == room.Name)
                {
                    return (false, false);
                }
            }

            return (this.roomRepository.Create(room), true);
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
        public List<RenovationTerm> BasicRenovation(int roomId, DateTime start, DateTime end, int duration)
        {
            var dates = new List<DateTime>();

            for (var dt = start; dt <= end; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }

            var appointments = this.appointmentRepository.GetAll();
            for (int i = 0; i < dates.Count; i++)
            {
                foreach (var appointment in appointments)
                {
                    if (dates[i] == appointment.StartTime && roomId == appointment.RoomNumber)
                    {
                        dates.RemoveAt(i);
                    }
                }
            }

            List<RenovationTerm> retVal = new List<RenovationTerm>();
            duration--; //first day is already included so we subrtact that day from total amount of days
            int renovationId = 0;
            for (int i = 0; i < dates.Count - duration; i++)
            {
                if (dates[i].AddDays(duration) == dates[i + duration])
                {
                    retVal.Add(new RenovationTerm(renovationId++, dates[i].ToShortDateString(),
                        dates[i + duration].ToShortDateString()));
                }
            }

            return retVal;
        }

        public bool ScheduleRenovation(int roomId, string start, string end, string description)
        {
            return this.roomRepository.ScheduleRenovation(roomId, start, end, description);
        }

        public void UpdateDisabledFields()
        {
            List<RenovationTerm> renovationTerms = this.roomRepository.GetRenovationSchedules();
            List<Room> roomList = this.roomRepository.GetAll();
            foreach (Room room in roomList)
            {
                foreach (RenovationTerm renovationTerm in renovationTerms)
                {
                    if (room.Id == renovationTerm.Id)
                    {
                        DateTime dateStart = DateTime.ParseExact(renovationTerm.startDate, "dd-MMM-yy", null);
                        DateTime dateEnd = DateTime.ParseExact(renovationTerm.endDate, "dd-MMM-yy", null);
                        dateEnd = dateEnd.AddHours(23);
                        dateEnd = dateEnd.AddMinutes(59);
                        dateEnd = dateEnd.AddSeconds(59);
                        if (DateTime.Now >= dateStart && DateTime.Now <= dateEnd && room.Disabled == 0)
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
        public List<MergeRenovationTerm> GetMergeRenovationAvailableTerms(MergeRenovationTerm mergeRenovationQuery)
        {
            List<DateTime> intersectedAvailableDays = FindIntersectedAvailableDays(mergeRenovationQuery);

            List<MergeRenovationTerm> available = new List<MergeRenovationTerm>();

            FindAvailableTerms(mergeRenovationQuery, intersectedAvailableDays, available);
            return available;
        }

        private static void FindAvailableTerms(MergeRenovationTerm mergeRenovationQuery,
            List<DateTime> intersectedAvailableDays,
            List<MergeRenovationTerm> available)
        {
            mergeRenovationQuery
                .Duration--; //first day is already included so we subtract that day from total amount of days'
            int renovationId = 0;

            for (int i = 0; i < intersectedAvailableDays.Count - mergeRenovationQuery.Duration; i++)
            {
                if (StartDayPlusDurationIsEndDay(mergeRenovationQuery, intersectedAvailableDays, i))
                {
                    renovationId =
                        AddAsAvailableTerm(mergeRenovationQuery, available, renovationId, intersectedAvailableDays, i);
                }
            }
        }

        private static int AddAsAvailableTerm(MergeRenovationTerm mergeRenovationQuery,
            List<MergeRenovationTerm> available, int renovationId,
            List<DateTime> intersectedAvailableDays, int i)
        {
            available.Add(new MergeRenovationTerm(renovationId++,
                mergeRenovationQuery.RoomId1,
                mergeRenovationQuery.RoomId2,
                intersectedAvailableDays[i],
                intersectedAvailableDays[i + mergeRenovationQuery.Duration],
                mergeRenovationQuery.Description,
                mergeRenovationQuery.Name,
                mergeRenovationQuery.RoomType));
            return renovationId;
        }

        private static bool StartDayPlusDurationIsEndDay(MergeRenovationTerm mergeRenovationQuery,
            List<DateTime> intersectedAvailableDays, int i)
        {
            return intersectedAvailableDays[i].AddDays(mergeRenovationQuery.Duration) ==
                   intersectedAvailableDays[i + mergeRenovationQuery.Duration];
        }

        private List<DateTime> FindIntersectedAvailableDays(MergeRenovationTerm mergeRenovationQuery)
        {
            var firstRoomAvailableDays = new List<DateTime>();
            var secondRoomAvailableDays = new List<DateTime>();
            List<Appointment> allAppointments = this.appointmentRepository.GetAll();

            FillInAllDays(mergeRenovationQuery, firstRoomAvailableDays, secondRoomAvailableDays);

            RemoveOccupiedDays(mergeRenovationQuery, firstRoomAvailableDays, allAppointments, secondRoomAvailableDays);

            return firstRoomAvailableDays.Intersect(secondRoomAvailableDays).ToList();
        }

        private static void RemoveOccupiedDays(MergeRenovationTerm mergeRenovationQuery,
            List<DateTime> firstRoomAvailableDays,
            List<Appointment> allAppointments, List<DateTime> secondRoomAvailableDays)
        {
            for (int i = 0; i < firstRoomAvailableDays.Count; i++)
            {
                foreach (var appointment in allAppointments)
                {
                    if (RoomHasAppointmentAtGivenDate(mergeRenovationQuery, firstRoomAvailableDays, i, appointment, 1))
                    {
                        firstRoomAvailableDays.RemoveAt(i);
                    }

                    if (RoomHasAppointmentAtGivenDate(mergeRenovationQuery, secondRoomAvailableDays, i, appointment, 2))
                    {
                        secondRoomAvailableDays.RemoveAt(i);
                    }
                }
            }
        }

        private static bool RoomHasAppointmentAtGivenDate(MergeRenovationTerm mergeRenovationQuery,
            List<DateTime> roomAvailableDays, int i, Appointment appointment, int roomId)
        {
            if (roomId == 1)
            {
                return roomAvailableDays[i].Date == appointment.StartTime.Date &&
                       mergeRenovationQuery.RoomId1 == appointment.RoomNumber;
            }

            if (roomId == 2)
            {
                return roomAvailableDays[i].Date == appointment.StartTime.Date &&
                       mergeRenovationQuery.RoomId2 == appointment.RoomNumber;
            }

            throw new Exception("ROOM ID RoomHasAppointmentAtGivenDate == ???");
        }

        private static void FillInAllDays(MergeRenovationTerm mergeRenovationQuery,
            List<DateTime> firstRoomAvailableDays,
            List<DateTime> secondRoomAvailableDays)
        {
            for (var dt = mergeRenovationQuery.Range.Start; dt <= mergeRenovationQuery.Range.End; dt = dt.AddDays(1))
            {
                firstRoomAvailableDays.Add(dt);
                secondRoomAvailableDays.Add(dt);
            }
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
                    if (StartingDatePassed(renovationTerm) && RoomFound(room, renovationTerm))
                    {
                        DisableAndUpdateMergingRoom(room);
                    }
                }
            }
        }

        private void DisableAndUpdateMergingRoom(Room room)
        {
            room.Disabled = 2;
            this.roomRepository.Update(room);
        }

        private static bool StartingDatePassed(MergeRenovationTerm renovationTerm)
        {
            return DateTime.Now >= renovationTerm.Range.Start;
        }

        public void ExecuteMerging()
        {
            List<MergeRenovationTerm> mergeRenovations = this.roomRepository.GetMergeSchedules();
            List<Room> existing = this.roomRepository.GetAll();
            List<Room> toCreateList = new List<Room>();
            foreach (var renovationTerm in mergeRenovations)
            {
                foreach (var room in existing)
                {
                    if (EndingDatePassed(renovationTerm) && RoomFound(room, renovationTerm))
                    {
                        CreateRoomAndAddToCreationList(toCreateList, renovationTerm, room);
                        DeleteRoomAndItsMergeScheduling(room, renovationTerm);
                    }
                }
            }

            List<Room> distinctRooms = RemoveDuplicateRooms(toCreateList);
            CreateRooms(distinctRooms);
        }

        private void DeleteRoomAndItsMergeScheduling(Room room, MergeRenovationTerm renovationTerm)
        {
            this.roomRepository.DeleteById(room.Id);
            this.roomRepository.DeleteMergeScheduling(renovationTerm);
        }

        private static void CreateRoomAndAddToCreationList(List<Room> toCreateList, MergeRenovationTerm renovationTerm,
            Room room)
        {
            toCreateList.Add(new Room(0, renovationTerm.Name, renovationTerm.RoomType, room.Floor,
                renovationTerm.Description,
                "No"));
        }

        private void CreateRooms(List<Room> distinctList)
        {
            foreach (Room toBeCreated in distinctList)
            {
                toBeCreated.Id = this.roomRepository.next_id();
                this.roomRepository.Create(toBeCreated);
            }
        }

        private static List<Room> RemoveDuplicateRooms(List<Room> toCreateList)
        {
            return toCreateList.DistinctBy(x => x.Name).ToList();
        }

        private static bool RoomFound(Room room, MergeRenovationTerm renovationTerm)
        {
            return (room.Id == renovationTerm.RoomId1 || room.Id == renovationTerm.RoomId2);
        }

        private static bool EndingDatePassed(MergeRenovationTerm renovationTerm)
        {
            return DateTime.Now >
                   DateRange.GetLastMoment(renovationTerm.Range.End);
        }

        /// MERGE
        /// 
        ///////////////////////////////////////////////////////////////////////////////// 
        /// 
        /// SPLIT
        public List<SplitRenovationTerm> GetSplitRenovationAvailableTerms(SplitRenovationTerm splitRenovationQuery)
        {
            var dates = new List<DateTime>();

            FillInAllDays(splitRenovationQuery, dates);

            List<Appointment> appointments = this.appointmentRepository.GetAll();

            FindAvailableDays(splitRenovationQuery, dates, appointments);

            var available = new List<SplitRenovationTerm>();
            FindAvailableTerms(splitRenovationQuery, dates, available);
            return available;
        }

        private static void FindAvailableTerms(SplitRenovationTerm splitRenovationQuery, List<DateTime> dates,
            List<SplitRenovationTerm> available)
        {
            splitRenovationQuery
                .Duration--; //first day is already included so we subtract that day from total amount of days
            int renovationId = 0;

            for (int i = 0; i < dates.Count - splitRenovationQuery.Duration; i++)
            {
                if (StartDayPlusDurationIsEndDay(splitRenovationQuery, dates, i))
                {
                    renovationId = AddAvailableTerm(splitRenovationQuery, dates, available, renovationId, i);
                }
            }
        }

        private static int AddAvailableTerm(SplitRenovationTerm splitRenovationQuery, List<DateTime> dates,
            List<SplitRenovationTerm> available,
            int renovationId, int i)
        {
            available.Add(new SplitRenovationTerm(
                renovationId++,
                splitRenovationQuery.Roomtosplitid,
                splitRenovationQuery.Newroomname1,
                splitRenovationQuery.Newroomname2,
                splitRenovationQuery.Newroomdescription1,
                splitRenovationQuery.Newroomdescription2,
                splitRenovationQuery.Newroomtype1,
                splitRenovationQuery.Newroomtype2,
                dates[i],
                dates[i + splitRenovationQuery.Duration]
            ));
            return renovationId;
        }

        private static void FindAvailableDays(SplitRenovationTerm splitRenovationQuery, List<DateTime> dates,
            List<Appointment> appointments)
        {
            for (int i = 0; i < dates.Count; i++)
            {
                foreach (var appointment in appointments)
                {
                    if (RoomHasAppointmentAtGivenDate(splitRenovationQuery, dates, i, appointment))
                    {
                        dates.RemoveAt(i);
                    }
                }
            }
        }

        private static bool StartDayPlusDurationIsEndDay(SplitRenovationTerm splitRenovationQuery,
            List<DateTime> dates, int i)
        {
            return dates[i].AddDays(splitRenovationQuery.Duration) == dates[i + splitRenovationQuery.Duration];
        }

        private static void FillInAllDays(SplitRenovationTerm splitRenovationQuery, List<DateTime> dates)
        {
            for (var dt = splitRenovationQuery.Range.Start; dt <= splitRenovationQuery.Range.End; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }
        }

        private static bool RoomHasAppointmentAtGivenDate(SplitRenovationTerm splitRenovationQuery,
            List<DateTime> dates, int i, Appointment appointment)
        {
            return dates[i] == appointment.StartTime.Date &&
                   splitRenovationQuery.Roomtosplitid == appointment.RoomNumber;
        }

        public bool ScheduleSplit(SplitRenovationTerm splitRenovationTerm)
        {
            return this.roomRepository.ScheduleSplit(splitRenovationTerm);
        }

        public void DisableSplittingRooms()
        {
            List<SplitRenovationTerm> splitRenovations = this.roomRepository.GetSplitSchedules();
            List<Room> existing = this.roomRepository.GetAll();
            foreach (var room in existing)
            {
                foreach (var renovationTerm in splitRenovations)
                {
                    if (StartingDayPassed(renovationTerm) && RoomFound(room, renovationTerm))
                    {
                        DisableAndUpdateSplittingRoom(room);
                    }
                }
            }
        }

        private void DisableAndUpdateSplittingRoom(Room room)
        {
            room.Disabled = 3;
            this.roomRepository.Update(room);
        }

        private static bool RoomFound(Room room, SplitRenovationTerm renovationTerm)
        {
            return room.Id == renovationTerm.Roomtosplitid;
        }

        private static bool StartingDayPassed(SplitRenovationTerm renovationTerm)
        {
            return DateTime.Now >= renovationTerm.Range.Start;
        }

        public void ExecuteSplitting()
        {
            List<SplitRenovationTerm> splitRenovationTerms = this.roomRepository.GetSplitSchedules();
            List<Room> existing = this.roomRepository.GetAll();
            foreach (var renovationTerm in splitRenovationTerms)
            {
                foreach (var room in existing)
                {
                    if (EndingDateHasPassed(renovationTerm) && RoomFound(room, renovationTerm))
                    {
                        CreateNewRooms(renovationTerm, room);
                        DeleteRoomAndItsSchedule(room, renovationTerm);
                    }
                }
            }
        }

        private void DeleteRoomAndItsSchedule(Room room, SplitRenovationTerm renovationTerm)
        {
            this.roomRepository.DeleteById(room.Id);
            this.roomRepository.DeleteSplitScheduling(renovationTerm);
        }

        private void CreateNewRooms(SplitRenovationTerm renovationTerm, Room room)
        {
            this.roomRepository.Create(new Room(this.roomRepository.next_id(), renovationTerm.Newroomname1,
                renovationTerm.Newroomtype1, room.Floor, renovationTerm.Newroomdescription1, "No"));
            this.roomRepository.Create(new Room(this.roomRepository.next_id(), renovationTerm.Newroomname2,
                renovationTerm.Newroomtype2, room.Floor, renovationTerm.Newroomdescription2, "No"));
        }

        private static bool EndingDateHasPassed(SplitRenovationTerm renovationTerm)
        {
            return DateTime.Now >
                   DateRange.GetLastMoment(renovationTerm.Range.End);
        }

        public RoomRepository roomRepository = new RoomRepository();
        public AppointmentRepository appointmentRepository = new AppointmentRepository();
        public EquipmentRepository equipmentRepository = new EquipmentRepository();
    }
}