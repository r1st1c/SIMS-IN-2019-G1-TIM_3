using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class PrescriptionDTO
    {
        /*
            this.Id = Id;
            this.MedicineId = MedicineId;
            this.PatientId = PatientId;
            this.DoctorId = DoctorId;
            this.DateAndTime = DateAndTime;
            this.DurationOfUse = DurationOfUse;
            this.IsActive = isActive;
            this.FrequencyOfUse = FrequencyOfUse;
         */

        public string MedicineName {get; set;}
        public string DateAndTime { get; set;}
        public string FrequencyOfUse { get; set;}

        public PrescriptionDTO(string MedicineName, string DateAndTime, string FrequencyOfUse)
        {
            this.MedicineName = MedicineName;
            this.DateAndTime = DateAndTime;
            this.FrequencyOfUse = FrequencyOfUse;
        }
    }
}
