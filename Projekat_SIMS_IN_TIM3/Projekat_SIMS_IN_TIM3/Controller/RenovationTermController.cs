using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class RenovationTermController
    {
        public List<RenovationTerm> BasicRenovation(RenovationTerm renovationTerm)
        {
            return this.renovationTermService.GetAvailableRenovationTerms(renovationTerm);
        }

        public bool ScheduleRenovation(RenovationTerm renovationTerm)
        {
            return this.renovationTermService.ScheduleRenovation(renovationTerm);
        }

        public void DisableRenovatingRooms()
        {
            this.renovationTermService.DisableRenovatingRooms();
        }

        public List<RenovationTerm> GetRenovationSchedules()
        {
            return this.renovationTermService.GetRenovationSchedules();
        }

        public RenovationTermService renovationTermService;

        public RenovationTermController(RenovationTermService renovationTermService)
        {
            this.renovationTermService = renovationTermService;
        }
    }
}