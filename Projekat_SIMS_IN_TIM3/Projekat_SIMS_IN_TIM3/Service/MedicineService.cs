using Projekat_SIMS_IN_TIM3.Model;
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

        public List<Medicine> getAll() { return medicineRepository.getAll();  }

        public Medicine GetById(int Id) { return medicineRepository.GetById(Id); }
        public void createMedicine(Medicine medicine) { medicineRepository.createMedicine(medicine); }

        public void updateMedicine(Medicine medicine) { medicineRepository.updateMedicine(medicine); }

        public void delete(int medId) { medicineRepository.delete(medId); }

        public List<String> getAllVerified() { return medicineRepository.getAllVerified(); }

        public int getIdByName(string name) { return medicineRepository.getIdByName(name); }











    }
}
