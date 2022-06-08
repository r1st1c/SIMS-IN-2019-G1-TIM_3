using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class DoctorService
    {
        private DoctorRepository doctorRepository = new DoctorRepository();
        public List<Doctor> GetAll()
        {
            return doctorRepository.GetAll();
        }

        public Doctor GetById(int id)
        {
            return doctorRepository.GetById(id);
        }

        public int GetIdByNameAndSurname(string name, string surname)
        {
            return doctorRepository.GetIdByNameAndSurname(name, surname);
        }

        public int GetIdByUsername(string usname)
        {
            return doctorRepository.GetIdByUsername(usname);
        }

        public bool SaveAndUpdate(Doctor doctor)
        {
            return doctorRepository.SaveAndUpdate(doctor);
        }

        public bool Delete(int id)
        {
            return doctorRepository.Delete(id);
        }

        public List<string> NameSurnameSpec()
        {
            return doctorRepository.NameSurnameSpec();
        }


        


    }
}
