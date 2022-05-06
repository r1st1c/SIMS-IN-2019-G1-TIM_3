using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class AllergenService
    {
        public AllergenRepository allergenRepository = new AllergenRepository();

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
    }
}
