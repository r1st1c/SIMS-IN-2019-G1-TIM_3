using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class MedicinePrescriptionController
    {
        public MedicinePrescriptionService service = new MedicinePrescriptionService();

        public int getNextId()
        {
            return service.getNextId();
        }
        public void create(MedicinePrescription mp) {
            service.create(mp); 
        }

        public void update(MedicinePrescription mp)
        {
            service.update(mp);
        }

        public List<MedicinePrescription> getAll()
        {

             return this.service.getAll();
         
        }

        public void delete(int rId)
        {
            service.delete(rId);
        }

        public List<MedicinePrescription> getAllById(int it)
        {
            return service.getAllById(it);
        }

        public MedicinePrescription getById(int id)
        {
            return service.getById(id);

          
        }
    }
}
