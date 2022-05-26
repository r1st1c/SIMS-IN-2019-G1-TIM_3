﻿using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class MedicineService
    {
        private MedicineRepository medicineRepository = new MedicineRepository();
        public int GetNextId() { return medicineRepository.GetNextId(); }
        public List<Medicine> GetAll() { return medicineRepository.GetAll();  }

        public Medicine GetById(int Id) { return medicineRepository.GetById(Id); }
        public void Create(Medicine medicine) { medicineRepository.Create(medicine); }

        public void Update(Medicine medicine) { medicineRepository.Update(medicine); }

        public void Delete(int medId) { medicineRepository.DeleteById(medId); }

        public List<String> GetVerified() { return medicineRepository.GetVerified(); }

        public List<Medicine> GetUnverified() {  return medicineRepository.GetUnverified(); } 
        public int getIdByName(string name) { return medicineRepository.getIdByName(name); }
        public Medicine GetByName(string name) { return medicineRepository.GetByName(name); }











    }
}
