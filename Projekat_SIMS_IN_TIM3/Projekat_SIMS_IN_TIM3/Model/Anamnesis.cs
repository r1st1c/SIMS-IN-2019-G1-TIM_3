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


        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int AppointmentId { get; set; }
        public DateTime DateAndTime { get; set; }

        public AppointmentType AppType { get; set; }
        public String PerceivedDifficulties { get; set; }
        public String GeneralConclusion { get; set; }
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


    }



}