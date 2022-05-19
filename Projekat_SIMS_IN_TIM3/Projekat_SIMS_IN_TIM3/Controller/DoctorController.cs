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

        public int getIdByNameAndSurname(string name, string surname)
        {
            return doctorService.getIdByNameAndSurname(name, surname);
        }

        public int getIdByUsername(string usname)
        {
            return doctorService.getIdByUsername(usname);
        }

        public void saveAndUpdate(Doctor doctor)
        {
            doctorService.saveAndUpdate(doctor);
        }

        public void delete(int jmbg)
        {
            doctorService.delete(jmbg);
        }

        public List<string> nameSurnameSpec()
        {
           return doctorService.nameSurnameSpec();
        }

        public void addGrade(DoctorGradeDTO gradeDTO, int doctorId)
        {
            doctorService.addGrade(gradeDTO, doctorId);
        }
    }
}
