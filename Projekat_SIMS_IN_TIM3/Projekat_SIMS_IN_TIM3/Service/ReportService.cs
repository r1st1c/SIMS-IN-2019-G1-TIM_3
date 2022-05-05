using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class ReportService
    {

        public ReportRepository repository = new ReportRepository();


        public void create(Report mp)
        {
            repository.create(mp);
        }
        public void update(Report mp)
        {
            repository.update(mp);
        }
    }
}
