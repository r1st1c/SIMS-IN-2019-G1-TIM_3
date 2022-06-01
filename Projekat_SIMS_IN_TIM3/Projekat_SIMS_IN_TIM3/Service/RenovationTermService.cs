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
            for (int i = 0; i < dates.Count; i++)
            {
                foreach (var appointment in appointments)
                {
                    if (dates[i] == appointment.StartTime && renovationTerm.RoomId == appointment.RoomNumber)
                    {
                        dates.RemoveAt(i);
                    }
                }
            }

            List<RenovationTerm> retVal = new List<RenovationTerm>();
            renovationTerm.Duration--; //first day is already included so we subrtact that day from total amount of days
            int renovationId = 0;
            for (int i = 0; i < dates.Count - renovationTerm.Duration; i++)
            {
                if (dates[i].AddDays(renovationTerm.Duration) == dates[i + renovationTerm.Duration])
                {
                    retVal.Add(new RenovationTerm(renovationId++,renovationTerm.RoomId, dates[i], dates[i+ renovationTerm.Duration], renovationTerm.Description));
                }
            }

            return retVal;
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
            foreach (Room room in roomList)
            {
                foreach (RenovationTerm renovationTerm in renovationTerms)
                {
                    if (room.Id == renovationTerm.RoomId)
                    {
                        if (DateTime.Now >= renovationTerm.Range.Start && DateTime.Now <= DateRange.GetLastMoment(renovationTerm.Range.End) && room.Disabled == 0)
                        {
                            room.Disabled = 1;
                            this.roomRepository.Update(room);
                        }

                        if (DateTime.Now > renovationTerm.Range.End)
                        {
                            room.Disabled = 0;
                            this.roomRepository.Update(room);
                            this.renovationTermRepository.DeleteScheduling(renovationTerm);
                        }
                    }
                }
            }
        }

        public List<RenovationTerm> GetRenovationSchedules()
        {
            return this.renovationTermRepository.GetRenovationSchedules();
        }

        public RoomRepository roomRepository { get; set; } = new();
        public AppointmentRepository appointmentRepository { get; set; } = new();
        public RenovationTermRepository renovationTermRepository { get; set; } = new ();
    }
}
