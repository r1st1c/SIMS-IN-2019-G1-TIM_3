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

        public List<Room> GetAll()
        {
            return this.roomRepository.GetAll();
        }

        public bool Create(Room room)
        {
            return this.roomRepository.Create(room);
        }

        public bool Update(Room room)
        {
            return this.roomRepository.Update(room);    
        }

        public bool DeleteById(int id)
        {
            return this.roomRepository.DeleteById(id);
        }

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
                    if(dates[i] == appointment.StartTime && roomId == this.doctorRepository.getById(appointment.DoctorId).room.Id)
                    {
                        dates.RemoveAt(i);
                    }
                }
            }
            List<RenovationTerm> retVal = new List<RenovationTerm>();
            duration--;//first day is already included so we subrtact that day from total amount of days
            int number_of_possible=0;
            for (int i = 0; i < dates.Count-duration; i++)
            {
                if (dates[i].AddDays(duration) == dates[i + duration])
                {
                    retVal.Add(new RenovationTerm(number_of_possible++,dates[i].ToShortDateString(),dates[i+duration].ToShortDateString()));
                }
            }
            return retVal;
        }

        public bool ScheduleRenovation(int roomId, string start, string end)
        {
            return this.roomRepository.ScheduleRenovation(roomId, start, end);
        }

        public bool Split(int id)
        {
            return this.roomRepository.Split(id);
        }

        public bool Merge(int firstId, int secondId)
        {
            return this.roomRepository.Merge(firstId, secondId);
        }

        public RoomRepository roomRepository = new RoomRepository();
        public AppointmentRepository appointmentRepository = new AppointmentRepository();
        public DoctorRepository doctorRepository = new DoctorRepository();
    }
}
