using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class OperationNotification
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int PatientId { get; set; }

        public AppointmentType Type { get; set; }
        public int Duration { get; set; }

        public OperationNotification(int id, DateTime startTime, int patientId, AppointmentType type, int duration)
        {
            Id = id;
            StartTime = startTime;
            PatientId = patientId;
            Type = type;
            Duration = duration;
        }
    }
}
