using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.Model;

namespace Projekat_SIMS_IN_TIM3.IRepository
{
    public interface RenovationTermIRepository
    {
        public bool ScheduleRenovation(RenovationTerm renovationTerm);
        public List<RenovationTerm> GetRenovationSchedules();
        public void DeleteScheduling(RenovationTerm renovationTerm);

    }
}
