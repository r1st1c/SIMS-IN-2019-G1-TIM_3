using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class MedicinePrescription
    {
        public MedicinePrescription()
        {
            // TODO: implement
        }
        public MedicinePrescription(int Id, int MedicineId, int PatientId, int DoctorId, DateTime DateAndTime, TimeSpan DurationOfUse, bool isActive, TimeSpan FrequencyOfUse)
        {
            this.Id = Id;
            this.MedicineId = MedicineId;
            this.PatientId = PatientId;
            this.DoctorId = DoctorId;
            this.DateAndTime = DateAndTime;
            this.DurationOfUse = DurationOfUse;
            this.IsActive = isActive;
            this.FrequencyOfUse = FrequencyOfUse;
            
        }

        ~MedicinePrescription()
        {
            // TODO: implement
        }

        
        public int Id;
        public int MedicineId;
        public int PatientId;
        public int DoctorId;
        public DateTime DateAndTime;
        public TimeSpan DurationOfUse;
        public bool IsActive;
        public TimeSpan FrequencyOfUse;

    }
}
