using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class AbsenceRequestController
    {
        public  AbsenceRequestService service;

        public AbsenceRequestController(AbsenceRequestService requestService)
        {
            this.service = requestService;
        }

        public int GetNextId()
        {
            return service.GetNextId();
        }
        public void Create(AbsenceRequest request)
        {
            service.Create(request);
        }

        public List<AbsenceRequest> GetAll()
        {
            return service.GetAll();
        }

        public List<AbsenceRequest> GetAllByDoctorsId(int doctorsId)
        {
            return service.GetAllByDoctorsId(doctorsId);
        }

        public bool CheckSameSpecialization(String specializationForCheck, String specializationExisting)
        {
            return service.CheckSameSpecialization(specializationForCheck, specializationExisting);
        }

        public bool EqualRanges(DateTime startDateForCheck, DateTime endDateForCheck, String specializationForCheck)
        {
            return service.EqualRanges(startDateForCheck, endDateForCheck, specializationForCheck);
        }

        public bool ContainedInRange(DateTime startDateForCheck, DateTime endDateForCheck, String specializationForCheck)
        {
            return service.ContainedInRange(startDateForCheck, endDateForCheck, specializationForCheck);
        }

        public bool StartsInRange(DateTime startDateToCheck, String specializationForCheck)
        {
            return service.StartsInRange(startDateToCheck, specializationForCheck);
        }

        public bool EndsInRange(DateTime endDateForCheck, String specializationForCheck)
        {
            return service.EndsInRange(endDateForCheck, specializationForCheck);
        }

        public bool ContainsRange(DateTime startDateToCheck, DateTime endDateToCheck, String specializationForCheck)
        {
            return service.ContainsRange(startDateToCheck, endDateToCheck, specializationForCheck);
        }





    }
}
