using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class RenovationTermService
    {
        public List<RenovationTerm> GetAvailableRenovationTerms(RenovationTerm renovationTerm)
        {
            var dates = new List<DateTime>();

            for (var dt = renovationTerm.Range.Start; dt <= renovationTerm.Range.End; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }

            var appointments = this.appointmentRepository.GetAll();
            RemoveOccupiedDates(renovationTerm, dates, appointments);

            List<RenovationTerm> retVal = new List<RenovationTerm>();
            renovationTerm.Duration--; //first day is already included so we subtract that day from total amount of days
            int renovationId = 0;
            FindAvailableTerms(renovationTerm, dates, retVal, renovationId);

            return retVal;
        }

        private static void FindAvailableTerms(RenovationTerm renovationTerm, List<DateTime> dates, List<RenovationTerm> retVal, int renovationId)
        {
            for (int i = 0; i < dates.Count - renovationTerm.Duration; i++)
            {
                if (DateRangeIsContinuous(renovationTerm, dates, i))
                {
                    retVal.Add(new RenovationTerm(renovationId++, renovationTerm.RoomId, dates[i],
                        dates[i + renovationTerm.Duration], renovationTerm.Description));
                }
            }
        }

        private static bool DateRangeIsContinuous(RenovationTerm renovationTerm, List<DateTime> dates, int i)
        {
            return dates[i].AddDays(renovationTerm.Duration) == dates[i + renovationTerm.Duration];
        }

        private static void RemoveOccupiedDates(RenovationTerm renovationTerm, List<DateTime> dates, List<Appointment> appointments)
        {
            for (int i = 0; i < dates.Count; i++)
            {
                foreach (var appointment in appointments)
                {
                    if (RoomHasAppointmentAtDate(renovationTerm, dates, i, appointment))
                    {
                        dates.RemoveAt(i);
                    }
                }
            }
        }

        private static bool RoomHasAppointmentAtDate(RenovationTerm renovationTerm, List<DateTime> dates, int i, Appointment appointment)
        {
            return dates[i] == appointment.StartTime && renovationTerm.RoomId == appointment.RoomNumber;
        }

        public bool ScheduleRenovation(RenovationTerm renovationTerm)
        {
            if (DateTime.Now >= renovationTerm.Range.Start && DateTime.Now <= renovationTerm.Range.End)
            {
                Room toDisable = this.roomRepository.GetById(renovationTerm.RoomId);
                toDisable.Disabled = 1;
                this.roomRepository.Update(toDisable);
            }

            return this.renovationTermRepository.ScheduleRenovation(renovationTerm);
        }

        public void DisableRenovatingRooms()
        {
            List<RenovationTerm> renovationTerms = this.renovationTermRepository.GetRenovationSchedules();
            List<Room> roomList = this.roomRepository.GetAll();
            foreach (RenovationTerm renovationTerm in renovationTerms)
            {
                foreach (Room room in roomList)
                {
                    if (RoomIsFound(room, renovationTerm))
                    {
                        if (RenovationOccuringNow(renovationTerm, room))
                        {
                            room.Disabled = 1;
                            this.roomRepository.Update(room);
                        }

                        if (RenovationPassed(renovationTerm))
                        {
                            room.Disabled = 0;
                            this.roomRepository.Update(room);
                            this.renovationTermRepository.DeleteScheduling(renovationTerm);
                        }
                    }
                }
            }
        }

        private static bool RenovationPassed(RenovationTerm renovationTerm)
        {
            return DateTime.Now > DateRange.GetLastMoment(renovationTerm.Range.End);
        }

        private static bool RenovationOccuringNow(RenovationTerm renovationTerm, Room room)
        {
            return DateTime.Now >= renovationTerm.Range.Start &&
                   DateTime.Now <= DateRange.GetLastMoment(renovationTerm.Range.End) && room.Disabled == 0;
        }

        private static bool RoomIsFound(Room room, RenovationTerm renovationTerm)
        {
            return room.Id == renovationTerm.RoomId;
        }

        public List<RenovationTerm> GetRenovationSchedules()
        {
            return this.renovationTermRepository.GetRenovationSchedules();
        }

        public RoomRepository roomRepository { get; set; } = new();
        public AppointmentRepository appointmentRepository { get; set; } = new();
        public RenovationTermRepository renovationTermRepository { get; set; } = new();
    }
}