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

        public int getNextId()
        {
            return repository.getNextId();
        }
        public void create(Report mp)
        {
            repository.create(mp);
        }
        public void update(Report mp)
        {
            repository.update(mp);
        }

        public List<Report> getAll()
        {
            return repository.getAll();
        }

        public void delete(int rId)
        {
            repository.delete(rId);
        }

        public List<Report> getAllById(int id)
        {
            return repository.getAllById(id);
        }

        public Report getById(int id)
        {
            return repository.getById(id);
        }
    }
}
