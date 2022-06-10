using Projekat_SIMS_IN_TIM3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.IRepository
{
    public interface MedicinePrescriptionIRepository
    {
        public int GetNextId();
        public void ReadJson();
        public void WriteToJson();
        public void Create(MedicinePrescription mp);
        public void Update(MedicinePrescription mp);
        public List<MedicinePrescription> GetAll();
        public void Delete(int id);
        public List<MedicinePrescription> GetAllById(int id);
        public MedicinePrescription GetById(int id);

    }
}
