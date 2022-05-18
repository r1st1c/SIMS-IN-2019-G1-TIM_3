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



    }
}
