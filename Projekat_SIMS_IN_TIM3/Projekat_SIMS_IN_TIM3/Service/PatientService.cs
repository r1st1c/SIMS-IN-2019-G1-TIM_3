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

        public Patient GetById(int id)
        {
            return patientRepository.GetById(id);
        }

        public bool Save(Patient patient)
        {
            return patientRepository.Save(patient);
        }

        public bool Delete(int patient)
        {
            return patientRepository.Delete(patient);
        }


    }
}
