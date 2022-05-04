using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class MedicalRecordController
    {
        public MedicalRecordService ms = new MedicalRecordService();

        public void createMedicalRecord(Model.MedicalRecord medicalRecord)
        {
            this.ms.createMedicalRecord(medicalRecord);
        }

        public void deleteMedicalRecord(int id)
        {
            this.ms.deleteMedicalRecord(id);
        }

        public List<MedicalRecord> getAll()
        {
            return this.ms.getAll();
        }

        public MedicalRecord getByPatientId(int id)
        {
            return this.getByPatientId(id);
        }



    }
}
