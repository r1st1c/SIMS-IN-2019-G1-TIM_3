using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{


    public class Anamnesis
    {
        public Anamnesis()
        {
            // TODO: implement
        }

        public Anamnesis(int Id, int PatientId, int DoctorId, int AppointmentId, DateTime DateAndTime, AppointmentType AppType, String PercievedDifficulties, String GeneralConclusion)
        {
            this.Id = Id;
            this.PatientId = PatientId;
            this.DoctorId = DoctorId;
            this.AppointmentId = AppointmentId;
            this.DateAndTime = DateAndTime;
            this.AppType = AppType;
            this.PerceivedDifficulties = PercievedDifficulties;
            this.GeneralConclusion = GeneralConclusion;
        }

        ~Anamnesis()
        {
            // TODO: implement
        }

        private int Id { get; set; }
        private int PatientId { get; set; }
        private int DoctorId { get; set; }
        private int AppointmentId { get; set; }
        private DateTime DateAndTime { get; set; }

        private AppointmentType AppType { get; set; }
        private String PerceivedDifficulties { get; set; }
        private String GeneralConclusion { get; set; }

    }



}