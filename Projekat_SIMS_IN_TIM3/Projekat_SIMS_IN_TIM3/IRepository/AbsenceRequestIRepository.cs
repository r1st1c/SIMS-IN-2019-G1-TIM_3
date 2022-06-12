using Projekat_SIMS_IN_TIM3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.IRepository
{
    public interface AbsenceRequestIRepository
    {
        public int GetNextId();
        public void Create(AbsenceRequest request);
        public List<AbsenceRequest> GetAll();
        public List<AbsenceRequest> GetRequestsByDoctorsId(int id);
    }
}
