using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class MedicalRecordService
    {
        public MedicalRecordRepository mr = new MedicalRecordRepository();



        public void createMedicalRecord(Model.MedicalRecord medicalRecord)
        {
            this.mr.createMedicalRecord(medicalRecord);
        }
        public void deleteMedicalRecord(int id)
        {
            this.mr.deleteMedicalRecord(id);
        }

        public List<MedicalRecord> getAll()
        {
            return this.mr.getAll();
        }
        public MedicalRecord getByPatientId(int id)
        {
            return this.mr.getByPatientId((int)id);
        }
    }
}
