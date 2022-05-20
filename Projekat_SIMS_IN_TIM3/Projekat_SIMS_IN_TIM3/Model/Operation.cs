using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class Operation
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public int RoomNumber { get; set; }
        public AppointmentType Type { get; set; }
        public int DurationInMinutes { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        public Operation(int id, DateTime startTime, DateTime finishTime, int roomNumber, AppointmentType type, int durationInMinutes, int doctorId, int patientId)
        {
            Id = id;
            StartTime = startTime;
            FinishTime = finishTime;
            RoomNumber = roomNumber;
            Type = type;
            DurationInMinutes = durationInMinutes;
            DoctorId = doctorId;
            PatientId = patientId;
        }
    }
}
