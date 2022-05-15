using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class RejectedMedicineNotification
    {
        public int Id { get; set; }
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public string Explanation { get; set; }

        public RejectedMedicineNotification()
        {
        }

        public RejectedMedicineNotification(int id, int medicineId, string medicineName, string explanation)
        {
            this.Id = id;
            MedicineId = medicineId;
            MedicineName = medicineName;
            Explanation = explanation;
        }
    }
}
