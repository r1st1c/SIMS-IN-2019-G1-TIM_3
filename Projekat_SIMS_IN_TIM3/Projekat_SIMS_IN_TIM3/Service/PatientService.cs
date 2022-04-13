using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class PatientService
    {
        private PatientRepository patientRepository = new PatientRepository();
        public List<Patient> GetAll()
        {
            return patientRepository.GetAll();
        }

        public Patient GetById(String id)
        {
            return patientRepository.GetById(id);
        }

        public void Save(Patient patient)
        {
            patientRepository.Save(patient);
        }

        public void Delete(String patient)
        {
            patientRepository.Delete(patient);
        }


    }
}
