using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class OperationService
    {
        private OperationRepository repo = new OperationRepository();

        public List<Operation> GetAll()
        {
            return repo.GetAll();
        }

        public void Create(Operation operation)
        {
            repo.Create(operation);

        }
    }
}
