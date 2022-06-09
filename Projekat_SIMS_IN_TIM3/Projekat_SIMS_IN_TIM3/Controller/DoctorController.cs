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

        public Doctor GetById(int id)
        {
            return doctorService.GetById(id);
        }

        public int GetIdByNameAndSurname(string name, string surname)
        {
            return doctorService.GetIdByNameAndSurname(name, surname);
        }

        public int GetIdByUsername(string usname)
        {
            return doctorService.GetIdByUsername(usname);
        }

        public void SaveAndUpdate(Doctor doctor)
        {
            doctorService.SaveAndUpdate(doctor);
        }

        public void Delete(int jmbg)
        {
            doctorService.Delete(jmbg);
        }

        public List<string> NameSurnameSpec()
        {
           return doctorService.NameSurnameSpec();
        }

       
    }
}
