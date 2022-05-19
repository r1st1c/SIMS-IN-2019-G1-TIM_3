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

        public int getNextId()
        {
            return repository.getNextId();
        }
        public void create(MedicinePrescription mp)
        {
            repository.create(mp);
        }
        public void update(MedicinePrescription mp)
        {
            repository.update(mp);
        }

        public List<MedicinePrescription> getAll()
        {

            return this.repository.getAll();
        }

        public void delete(int rId)
        {
            repository.delete(rId);
        }

        public List<MedicinePrescription> getAllById(int id)
        {
            return repository.getAllById(id);
        }

        public MedicinePrescription getById(int id)
        {
            return repository.getById(id);

        }
    }
}
