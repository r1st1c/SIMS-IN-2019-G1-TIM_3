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


        public void Create(MedicalRecord mr)
        {
            this.mr.Create(mr);
        }
        public void Delete(int id)
        {
            this.mr.Delete(id);
        }

        public List<MedicalRecord> getAll()
        {
            return this.mr.GetAll();
        }
        public MedicalRecord getByPatientId(int id)
        {
            return this.mr.GetByPatientId((int)id);
        }
    }
}
