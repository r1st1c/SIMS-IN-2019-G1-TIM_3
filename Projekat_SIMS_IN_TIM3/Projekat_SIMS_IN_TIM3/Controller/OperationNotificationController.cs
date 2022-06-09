using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class OperationNotificationController
    {
        private OperationNotificationService service = new OperationNotificationService();


        public List<OperationNotification> GetAll()
        {
           return  service.GetAll();
        }

        public void Create(OperationNotification notification)
        {
            service.Create(notification);
        }

    }
}
