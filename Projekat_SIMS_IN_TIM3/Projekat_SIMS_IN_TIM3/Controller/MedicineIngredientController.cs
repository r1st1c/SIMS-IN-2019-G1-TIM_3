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
        public MedicineIngredientService medicineIngredientService { get; set; } = new MedicineIngredientService();
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
    }
}
