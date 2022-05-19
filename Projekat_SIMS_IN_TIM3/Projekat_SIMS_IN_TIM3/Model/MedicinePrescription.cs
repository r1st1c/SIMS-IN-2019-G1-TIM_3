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

        
        public int Id { get; set; }
        public int MedicineId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime DateAndTime { get; set; }
        public TimeSpan DurationOfUse { get; set; }
        public bool IsActive { get; set; }
        public TimeSpan FrequencyOfUse { get; set; }

    }
}
