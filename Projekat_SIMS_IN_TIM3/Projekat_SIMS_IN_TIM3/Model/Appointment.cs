using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public enum AppointmentType
    {
        basic,
        urgent
    }

    public class Appointment
    {
        private int appId;
        private DateTime value;
        public int RoomNumber { get; set; }

        public Appointment()
        {
            // TODO: implement
        }

        ~Appointment()
        {
            // TODO: implement
        }

        public Appointment(int id, DateTime startTime, int durationInMinutes, AppointmentType type, int doctorId, int patientId)
        {
            this.Id = id;
            this.StartTime = startTime;
            this.DurationInMinutes = durationInMinutes;
            this.Type = type;
            this.DoctorId = doctorId;
            this.PatientId = patientId;

        }

        public Appointment(int appId, DateTime value, int durationInMinutes, AppointmentType type, int patientId)
        {
            this.appId = appId;
            this.value = value;
            DurationInMinutes = durationInMinutes;
            Type = type;
            PatientId = patientId;
        }

        public Appointment(int roomNumber, int id, DateTime startTime, DateTime finishTime, int durationInMinutes, AppointmentType type, int doctorId, int patientId)
        {
            RoomNumber = roomNumber;
            Id = id;
            StartTime = startTime;
            FinishTime = finishTime;
            DurationInMinutes = durationInMinutes;
            Type = type;
            DoctorId = doctorId;
            PatientId = patientId;
        }

        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public int DurationInMinutes { get; set; }
        public AppointmentType Type { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }


    }
}
