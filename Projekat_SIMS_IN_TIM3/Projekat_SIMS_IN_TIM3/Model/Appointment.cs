using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class Appointment
    {
        public int Id;
        public DateTime date;
        public string time;
        public int durationInMinutes;
        public int doctorsId;
        public int patientsId;

        public Appointment()
        {
        }

        public Appointment(int id, DateTime date, string time, int durationInMinutes, int doctorsId, int patientsId)
        {
            Id = id;
            this.date = date;
            this.time = time;
            this.durationInMinutes = durationInMinutes;
            this.doctorsId = doctorsId;
            this.patientsId = patientsId;
        }


    }
}
