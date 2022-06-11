using Projekat_SIMS_IN_TIM3.IRepository;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class MedicinePrescriptionService
    {
        public MedicinePrescriptionIRepository repository;
        public MedicineIRepository medicineRepository;
        public AllergenIRepository allergenRepository;

        public MedicinePrescriptionService(MedicinePrescriptionIRepository iRepository, MedicineIRepository medicineRepository, AllergenIRepository allergenRepository)
        {
            this.repository = iRepository;
            this.medicineRepository = medicineRepository;
            this.allergenRepository = allergenRepository;
        }

        public int GetNextId()
        {
            return repository.GetNextId();
        }
        public void Create(MedicinePrescription mp)
        {
            repository.Create(mp);
        }
        public void Update(MedicinePrescription mp)
        {
            repository.Update(mp);
        }

        public List<MedicinePrescription> GetAll()
        {

            return this.repository.GetAll();
        }

        public void Delete(int rId)
        {
            repository.Delete(rId);
        }

        public List<MedicinePrescription> GetAllById(int id)
        {
            return repository.GetAllById(id);
        }

        public MedicinePrescription GetById(int id)
        {
            return repository.GetById(id);

        }

        public bool IsAllergicToMedicine(int patientId, Medicine medicine)
        {
           
            var allergens = allergenRepository.GetByPatientsId(patientId);
            foreach(var allergen in allergens)
            {
                if (allergen.Name.Equals(medicine.Name))
                {
                    return true;
                }
            }
            return false;
        }

        
    }
}
