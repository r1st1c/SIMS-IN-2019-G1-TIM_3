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

        public void Create(MedicalRecord mr)
        {
            this.ms.Create(mr);
        }

        public void Delete(int id)
        {
            this.ms.Delete(id);
        }

        public List<MedicalRecord> GetAll()
        {
            return this.ms.getAll();
        }

        public MedicalRecord GetByPatientId(int id)
        {
            return this.GetByPatientId(id);
        }



    }
}
