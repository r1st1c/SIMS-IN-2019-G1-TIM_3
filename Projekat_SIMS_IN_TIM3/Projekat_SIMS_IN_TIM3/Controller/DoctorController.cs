using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class DoctorController
    {
        private DoctorService doctorService = new DoctorService();

        public List<Doctor> GetAll()
        {
            return doctorService.GetAll();
        }

        public void saveAndUpdate(Doctor doctor)
        {
            doctorService.saveAndUpdate(doctor);
        }

        public void delete(int jmbg)
        {
            doctorService.delete(jmbg);
        }
    }
}
