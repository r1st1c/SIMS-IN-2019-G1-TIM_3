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
    public class AbsenceRequestService
    {
        private AbsenceRequestIRepository repository;
        private DoctorService doctorService;

        public AbsenceRequestService(AbsenceRequestIRepository requestIRepository, DoctorService doctorService)
        {
            this.repository = requestIRepository;
            this.doctorService = doctorService;
        }

        public int GetNextId()
        {
            return repository.GetNextId();
        }
        public void Create(AbsenceRequest request)
        {
            repository.Create(request);
        }

        public List<AbsenceRequest> GetAll()
        {
            return repository.GetAll();
        }

        public List<AbsenceRequest> GetAllByDoctorsId(int id)
        {
            return repository.GetRequestsByDoctorsId(id);
        }

      
        public bool CheckSameSpecialization(String specializationForCheck, String specializationExisting)
        {
            return specializationForCheck.Equals(specializationExisting) ? true : false;
        }
        public bool EqualRanges(DateTime startDateForCheck, DateTime endDateForCheck, String specializationForCheck)
        {
            var requests = GetAll();
            bool retVal = false;
            bool sameSpecialization = false;
            foreach (var request in requests)
            {
                TimeSpan existingSpan = request.EndDate.Date - startDateForCheck.Date;
                retVal = existingSpan.Equals((TimeSpan)(endDateForCheck - startDateForCheck));
                sameSpecialization = CheckSameSpecialization(specializationForCheck, doctorService.GetById(request.DoctorId).specializationType);
            }
            return ((retVal == true) || (sameSpecialization == true)) ? true : false;
        }

       

        public bool ContainedInRange(DateTime startDateForCheck, DateTime endDateForCheck,String specializationForCheck)
        {
            var requests = GetAll();
            bool retVal = false;
            bool sameSpecialization = false;
            foreach (var request in requests)
            {
                TimeSpan existingSpan = request.EndDate.Date - request.StartDate.Date;
                retVal = ((startDateForCheck >= request.StartDate.Date && startDateForCheck <= request.EndDate.Date) && (endDateForCheck >= request.StartDate.Date && endDateForCheck <= request.EndDate.Date));
                sameSpecialization = CheckSameSpecialization(specializationForCheck, doctorService.GetById(request.DoctorId).specializationType);
            }
            return ((retVal == true) || (sameSpecialization == true)) ? true : false;
        }

        public bool StartsInRange(DateTime startDateToCheck, String specializationForCheck)
        {
            var requests = GetAll();
            bool retVal = false;
            bool sameSpecialization = false;
                foreach(var request in requests)
            {
                retVal = (startDateToCheck >= request.StartDate.Date) && (startDateToCheck <= request.EndDate.Date);
                sameSpecialization = CheckSameSpecialization(specializationForCheck, doctorService.GetById(request.DoctorId).specializationType);
            }
           return ((retVal == true) || (sameSpecialization == true)) ? true : false;
        }

        public bool EndsInRange(DateTime endDateForCheck, String specializationForCheck)
        {
            var requests = GetAll();
            bool retVal = false;
            bool sameSpecialization = false;
            foreach (var request in requests)
            {
                retVal = (endDateForCheck >= request.StartDate.Date) && (endDateForCheck <= request.EndDate.Date);
                sameSpecialization = CheckSameSpecialization(specializationForCheck, doctorService.GetById(request.DoctorId).specializationType);
            }
            return ((retVal == true) || (sameSpecialization == true)) ? true : false;
           
        }

        public bool ContainsRange(DateTime startDateToCheck, DateTime endDateToCheck, String specializationForCheck)
        {

            var requests = GetAll();
            bool startInRange = false;
            bool endInRange = false;
            bool sameSpecialization = false;
            foreach (var request in requests)
            {
                startInRange = (startDateToCheck >= request.StartDate.Date) && (startDateToCheck <= request.EndDate.Date) ? true : false;
                endInRange = (endDateToCheck >= request.StartDate.Date) && (endDateToCheck <= request.EndDate.Date) ? true : false;
                sameSpecialization = CheckSameSpecialization(specializationForCheck, doctorService.GetById(request.DoctorId).specializationType);
            }
            

            return (startInRange == true) || (endInRange == true) || (endInRange == true) ? true : false;
        }


    }
}
