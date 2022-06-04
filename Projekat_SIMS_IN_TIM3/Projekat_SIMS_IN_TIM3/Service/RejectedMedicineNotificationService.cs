using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class RejectedMedicineNotificationService
    {
        private RejectedMedicineNotificationRepository repo = new RejectedMedicineNotificationRepository();

        public List<RejectedMedicineNotification> GetAll()
        {
            return repo.GetAll();
        }

        public void Create(RejectedMedicineNotification notification)
        {
            repo.Create(notification);
        }

        public void Delete(int notificationId)
        {
            repo.Delete(notificationId);
        }
    }
}
