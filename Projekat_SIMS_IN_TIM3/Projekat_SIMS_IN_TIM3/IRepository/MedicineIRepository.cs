using Projekat_SIMS_IN_TIM3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.IRepository
{
    public interface MedicineIRepository
    {
        public int GetNextId();
        public void ReadJson();
        public void WriteToJson();
        public List<Medicine> GetAll();
        public Medicine GetById(int id);
        public void Create(Medicine medicine);
        public void Update(Medicine medicine);
        public void Delete(int id);
        public List<Medicine> GetVerified();
        public List<String> GetVerifiedNames();
        public List<Medicine> GetUnverified();
        public List<Medicine> GetRejected();
        public int getIdByName(string name);
        public Medicine GetByName(string name);
    }
}
