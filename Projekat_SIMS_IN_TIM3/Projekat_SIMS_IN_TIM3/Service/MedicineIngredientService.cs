using Projekat_SIMS_IN_TIM3.Repository;
using Projekat_SIMS_IN_TIM3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class MedicineIngredientService
    {
        public MedicineIngredientRepository medicineIngredientRepository { get; set; } = new MedicineIngredientRepository();

        public MedicineIngredient GetById(int id)
        {
            return this.medicineIngredientRepository.GetById(id);
        }

        public List<MedicineIngredient> GetAll()
        {
            return this.medicineIngredientRepository.GetAll();
        }

        public MedicineIngredient Create(MedicineIngredient toCreate)
        {
            return this.medicineIngredientRepository.Create(toCreate);
        }

    }
}
