using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class Report
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public AppointmentType Type { get; set; }
        public DateTime DateAndTime { get; set; }
        public string PerceivedDifficulties { get; set; }
        public string GeneralConclusion { get; set; }

        public Report()
        {
        }

        public Report(int id, int patientId, int doctorId, AppointmentType type, DateTime dateAndTime, string perceivedDifficulties, string generalConclusion)
        {
            Id = id;
            PatientId = patientId;
            DoctorId = doctorId;
            Type = type;
            DateAndTime = dateAndTime;
            PerceivedDifficulties = perceivedDifficulties;
            GeneralConclusion = generalConclusion;
        }
    }
}
