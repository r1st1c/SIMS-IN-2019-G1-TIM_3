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

        public void create(MedicinePrescription mp) {
            service.create(mp); 
        }

        public void update(MedicinePrescription mp)
        {
            service.update(mp);
        }
    }
}
