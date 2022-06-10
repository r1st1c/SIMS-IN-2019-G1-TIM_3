using Projekat_SIMS_IN_TIM3.Model;
using System;
using System.Collections.Generic;


namespace Projekat_SIMS_IN_TIM3.IRepository
{
    public interface AllergenIRepository
    {
        public void ReadJson();
        public void WriteToJson();
        public void Save(Allergen allergen);
        public void Update(Allergen allergen);
        public void Delete(int id);
        public List<Allergen> GetByPatientsId(int id);
        public List<Allergen> GetById(int id);
        public List<Allergen> GetAll();
        public int GetNextId();

    }
}
