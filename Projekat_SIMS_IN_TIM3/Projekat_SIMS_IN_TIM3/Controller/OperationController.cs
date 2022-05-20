using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class OperationController
    {
        private OperationService service = new OperationService();

        public List<Operation> getAll()
        {
            return service.getAll();
        }

        public void create(Operation operation)
        {
            service.create(operation);
        }

    }
}
