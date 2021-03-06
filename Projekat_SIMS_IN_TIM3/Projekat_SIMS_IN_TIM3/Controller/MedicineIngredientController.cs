using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projekat_SIMS_IN_TIM3.Service;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.Model;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class MedicineIngredientController
    {
        public MedicineIngredientService medicineIngredientService;
        public MedicineIngredient GetById(int id)
        {
            return this.medicineIngredientService.GetById(id);
        }

        public List<MedicineIngredient> GetAll()
        {
            return this.medicineIngredientService.GetAll();
        }

        public MedicineIngredient Create(MedicineIngredient toCreate)
        {
            return this.medicineIngredientService.Create(toCreate);
        }
        public MedicineIngredient GetByName(string name)
        {
            return this.medicineIngredientService.GetByName(name);
        }

        public MedicineIngredientController(MedicineIngredientService medicineIngredientService)
        {
            this.medicineIngredientService = medicineIngredientService;
        }
    }
}
