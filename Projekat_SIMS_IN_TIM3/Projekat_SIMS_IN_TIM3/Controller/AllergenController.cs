using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class AllergenController
    {
        private AllergenService allergenService = new AllergenService();


        public List<Allergen> GetAll()
        {
            return allergenService.GetAll();
        }

        public List<Allergen> GetById(int id)
        {
            return allergenService.GetById(id);
        }

        public void Save(Allergen allergen)
        {
            allergenService.Save(allergen);
        }

        public void Delete(int allergen)
        {
            allergenService.Delete(allergen);
        }
        
        public void Update(Allergen allergen)
        {
            allergenService.Update(allergen);
        }

        public List<Allergen> GetByPatientsId(int patientId)
        {
            return this.allergenService.GetByPatientsId(patientId);
        }
    }
}
