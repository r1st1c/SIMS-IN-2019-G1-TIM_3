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


        public void createAbsenceRequest(AbsenceRequest request)
        {
            service.createAbsenceRequest(request);
        }

        public List<AbsenceRequest> getAll()
        {
            return service.getAll();
        }

        public List<AbsenceRequest> getAllByDoctorsId(int doctorsId)
        {
            return service.getAllByDoctorsId(doctorsId);
        }
    }
}
