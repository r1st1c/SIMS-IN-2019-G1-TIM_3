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
        private AbsenceRequestRepository repository = new AbsenceRequestRepository();


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

        public bool CheckTimeOfSendingRequest(DateTime startDate)
        {
            return repository.CheckTimeOfSendingRequest(startDate);
        }

        public int CheckDoctorSpecialization(String specialization, DateTime start, DateTime end)
        {
            return repository.CheckDoctorSpecialization(specialization, start, end);
        }

        public bool IsThereDoctorWithSameSpecialization(String specialization, DateTime start, DateTime end)
        {
            return repository.IsThereDoctorWithSameSpecialization(specialization, start, end);
        }


    }
}
