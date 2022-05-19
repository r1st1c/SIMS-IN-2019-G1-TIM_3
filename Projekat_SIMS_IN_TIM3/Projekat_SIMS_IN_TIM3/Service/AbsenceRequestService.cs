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


        public int getNextId()
        {
            return repository.getNextId();
        }
        public void createAbsenceRequest(AbsenceRequest request)
        {
            repository.createAbsenceRequest(request);
        }

        public List<AbsenceRequest> getAll()
        {
            return repository.getAll();
        }

        public List<AbsenceRequest> getAllByDoctorsId(int doctorsId)
        {
            return repository.getAllByDoctorsId(doctorsId);
        }

        public bool checkTimeOfSendingRequest(DateTime startDate)
        {
            return repository.checkTimeOfSendingRequest(startDate);
        }

        public int CheckDoctorSpecialization(String specialization, DateTime start, DateTime end)
        {
            return repository.CheckDoctorSpecialization(specialization, start, end);
        }

        public bool isThereDoctorWithSameSpecialization(String specialization, DateTime start, DateTime end)
        {
            return repository.isThereDoctorWithSameSpecialization(specialization, start, end);
        }


    }
}
