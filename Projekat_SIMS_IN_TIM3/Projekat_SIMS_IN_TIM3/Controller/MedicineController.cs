using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class MedicineController
    {
        private MedicineService medicineService = new MedicineService();

        public List<Medicine> getAll() { return medicineService.getAll(); }

        public Medicine GetById(int Id) { return medicineService.GetById(Id); }
        public void createMedicine(Medicine medicine) { medicineService.createMedicine(medicine); }

        public void updateMedicine(Medicine medicine) { medicineService.updateMedicine(medicine); }

        public void delete(int medId) { medicineService.delete(medId); }

        public List<String> getAllVerified() { return medicineService.getAllVerified(); }

        public List<Medicine> getAllUnverified()
        {
            return medicineService.getAllUnverified();
        }



        public int getIdByName(string name) { return medicineService.getIdByName(name); }
    }
}
