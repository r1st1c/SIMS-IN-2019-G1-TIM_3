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

        public int GetNextId()
        {
            return medicineService.GetNextId();
        }

        public List<Medicine> GetAll()
        {
            return medicineService.GetAll();
        }

        public Medicine GetById(int Id)
        {
            return medicineService.GetById(Id);
        }

        public void Create(Medicine medicine)
        {
            medicineService.Create(medicine);
        }

        public void Update(Medicine medicine)
        {
            medicineService.Update(medicine);
        }

        public void Delete(int medId)
        {
            medicineService.Delete(medId);
        }

        public List<string> GetVerifiedNames()
        {
            return medicineService.GetVerifiedNames();
        }
        public List<Medicine> GetVerified()
        {
            return medicineService.GetVerified();
        }
        public List<Medicine> GetUnverified()
        {
            return medicineService.GetUnverified();
        }

        public List<Medicine> GetRejected()
        {
            return medicineService.GetRejected();
        }

        public Medicine GetByName(string name)
        {
            return medicineService.GetByName(name);
        }


        public int getIdByName(string name)
        {
            return medicineService.getIdByName(name);
        }
    }
}