using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class MedicinePrescriptionController
    {
        public MedicinePrescriptionService service;

        public MedicinePrescriptionController(MedicinePrescriptionService prescriptionService)
        {
            this.service = prescriptionService;
        }

        public int GetNextId()
        {
            return service.GetNextId();
        }
        public void Create(MedicinePrescription mp) {
            service.Create(mp); 
        }

        public void Update(MedicinePrescription mp)
        {
            service.Update(mp);
        }

        public List<MedicinePrescription> GetAll()
        {

             return this.service.GetAll();
         
        }

        public void Delete(int rId)
        {
            service.Delete(rId);
        }

        public List<MedicinePrescription> GetAllById(int it)
        {
            return service.GetAllById(it);
        }

        public MedicinePrescription GetById(int id)
        {
            return service.GetById(id);

          
        }

        public bool IsAllergicToMedicine(int patientId, Medicine medicine)
        {
            return service.IsAllergicToMedicine(patientId, medicine);
        }



    }
}
