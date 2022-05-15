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

        public List<RejectedMedicineNotification> getAll()
        {
            return repo.getAll();
        }

        public void createNotification(RejectedMedicineNotification notification)
        {
            repo.createNotification(notification);
        }

        public void deleteNotification(int notificationId)
        {
            repo.deleteNotification(notificationId);
        }
    }
}
