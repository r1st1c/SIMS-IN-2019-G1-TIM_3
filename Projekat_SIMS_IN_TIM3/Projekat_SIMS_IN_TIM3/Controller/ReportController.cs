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

        public int GetNextId()
        {
            return service.GetNextId();
        }
        public void Create(Report mp)
        {
            service.Create(mp);
        }

        public void Update(Report mp)
        {
            service.Update(mp);
        }

        public List<Report> GetAll()
        {
            return service.GetAll();
        }

        public void Delete(int rId)
        {
            service.Delete(rId);
        }

        public List<Report> GetAllById(int id)
        {
            return service.GetAllById(id);
        }

        public Report GetById(int id)
        {
            return service.GetById(id);
        }
    }
}
