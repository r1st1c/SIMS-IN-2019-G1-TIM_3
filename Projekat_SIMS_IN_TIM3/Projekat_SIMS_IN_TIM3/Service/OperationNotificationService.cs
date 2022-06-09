using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class OperationNotificationService
    {
        private OperationNotificationRepository repo = new OperationNotificationRepository();

        public void Create(OperationNotification notification)
        {
            repo.Create(notification);
        }

        public List<OperationNotification> GetAll()
        {
            return repo.GetAll();
        }
    }
}
