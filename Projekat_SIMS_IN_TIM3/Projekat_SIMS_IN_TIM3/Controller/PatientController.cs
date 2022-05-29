using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class PatientController
    {
        private PatientService patientService = new PatientService();

        public List<Patient> GetAll()
        {
            return patientService.GetAll();
        }

        public Patient GetById(int id)
        {
            return patientService.GetById(id);
        }

        public void Save(Patient patient)
        {
            patientService.Save(patient);
        }

        public void Delete(int jmbg)
        {
            patientService.Delete(jmbg);
        }

        public List<string> nameSurname()
        {
            return patientService.nameSurname();
        }

        public string getName(int id)
        {
            return patientService.getName(id);
        }

        public int getIdByNameAndSurname(string name, string surname)
        {
            return patientService.getIdByNameAndSurname(name, surname);
        }

        

        public string getSurname(int id) { return patientService.getSurname(id); }
        public DateTime getDateOfBirth(int id) { return patientService.getDateOfBirth(id); }
        public string getJMBG(int id) { return patientService.getJMBG(id); }
        public string getAddress(int id) { return patientService.getAddress(id); }
        public string getEmail(int id) { return patientService.getEmail(id); }

        public string getTelNumber(int id) { return patientService.getTelNumber(id); }

    }
}
