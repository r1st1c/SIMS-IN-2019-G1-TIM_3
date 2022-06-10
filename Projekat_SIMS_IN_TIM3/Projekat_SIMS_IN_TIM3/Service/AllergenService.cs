using Projekat_SIMS_IN_TIM3.IRepository;
using Projekat_SIMS_IN_TIM3.Model;
using System.Collections.Generic;


namespace Projekat_SIMS_IN_TIM3.Service
{
    public class AllergenService
    {
        private AllergenIRepository allergenRepository;

        public AllergenService(AllergenIRepository allergenRepository)
        {
            this.allergenRepository = allergenRepository;
        }

        public List<Allergen> GetAll()
        {
            return allergenRepository.GetAll();
        }

        public List<Allergen> GetById(int id)
        {
            return allergenRepository.GetById(id);
        }

        public void Save(Allergen allergen)
        {
            allergenRepository.Save(allergen);
        }

        public void Delete(int allergen)
        {
            allergenRepository.Delete(allergen);
        }

        public void Update(Allergen allergen)
        {
            allergenRepository.Update(allergen);
        }

        public List<Allergen> GetByPatientsId(int patientId)
        {
            return this.allergenRepository.GetByPatientsId((int)patientId);
        }

        public int GetNextId()
        {
            return allergenRepository.GetNextId();
        }
    }
}
