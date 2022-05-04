using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class MedicalRecord
    {
        public MedicalRecord()
        {

        }

        public MedicalRecord(int Id, int PatientId)
        {
            this.Id = Id;
            this.PatientId = PatientId;
            this.PrescriptionList = new List<MedicinePrescription>();
            this.AnamnesisList = new List<Anamnesis> ();
            this.AllergenList = new List<Allergen> ();
        }


        ~MedicalRecord()
        { }

        public int Id;
        public int PatientId { get; set; }
        public List<MedicinePrescription> PrescriptionList { get; set; }
        public List<Anamnesis> AnamnesisList { get; set; }
        public List<Allergen> AllergenList { get; set; }

    }
}
