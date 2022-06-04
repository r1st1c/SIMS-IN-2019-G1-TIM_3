using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class MedicinePrescriptionService
    {
        public MedicinePrescriptionRepository repository = new MedicinePrescriptionRepository();

        public int GetNextId()
        {
            return repository.GetNextId();
        }
        public void Create(MedicinePrescription mp)
        {
            repository.Create(mp);
        }
        public void Update(MedicinePrescription mp)
        {
            repository.Update(mp);
        }

        public List<MedicinePrescription> GetAll()
        {

            return this.repository.GetAll();
        }

        public void Delete(int rId)
        {
            repository.Delete(rId);
        }

        public List<MedicinePrescription> GetAllById(int id)
        {
            return repository.GetAllById(id);
        }

        public MedicinePrescription GetById(int id)
        {
            return repository.GetById(id);

        }
    }
}
