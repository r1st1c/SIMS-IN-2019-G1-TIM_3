using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class ReportController
    {
        public ReportService service = new ReportService();

        public void create(Report mp)
        {
            service.create(mp);
        }

        public void update(Report mp)
        {
            service.update(mp);
        }
    }
}
