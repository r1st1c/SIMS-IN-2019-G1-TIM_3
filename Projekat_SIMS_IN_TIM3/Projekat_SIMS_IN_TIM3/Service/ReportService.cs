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

        public int GetNextId()
        {
            return repository.GetNextId();
        }
        public void Create(Report mp)
        {
            repository.Create(mp);
        }
        public void Update(Report mp)
        {
            repository.Update(mp);
        }

        public List<Report> GetAll()
        {
            return repository.GetAll();
        }

        public void Delete(int rId)
        {
            repository.Delete(rId);
        }

        public List<Report> GetAllById(int id)
        {
            return repository.GetAllById(id);
        }

        public Report GetById(int id)
        {
            return repository.GetById(id);
        }
    }
}
