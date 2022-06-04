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
        private AbsenceRequestService service = new AbsenceRequestService();

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

        public bool CheckTimeOfSendingRequest(DateTime startDate)
        {
            return service.CheckTimeOfSendingRequest(startDate);
        }

        public bool IsThereDoctorWithSameSpecialization(String specialization, DateTime start, DateTime end)
        {
            return service.IsThereDoctorWithSameSpecialization(specialization, start, end); 
        }

        public int CheckDoctorSpecialization(String specialization, DateTime start, DateTime end)
        {
            return service.CheckDoctorSpecialization(specialization, start, end);
        }
    }
}
