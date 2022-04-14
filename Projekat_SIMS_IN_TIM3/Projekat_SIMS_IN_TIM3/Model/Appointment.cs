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
        public DateTime startTime;
        public int durationInMinutes;
        public AppointmentType appointmentType;
        public int doctorId;
        public int patientId;

        public Appointment()
        {
        }

        public Appointment(int id, DateTime start, int durationInMinutes, AppointmentType appointmentType, int doctorsId, int patientsId)
        {
            Id = id;
            this.startTime = start;
            this.durationInMinutes = durationInMinutes;
            this.appointmentType = appointmentType;
            this.doctorId = doctorsId;
            this.patientId = patientsId;
        }


    }
}
