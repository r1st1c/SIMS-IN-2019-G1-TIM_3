using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class RejectedMedicineNotificationController
    {
        private RejectedMedicineNotificationService service = new RejectedMedicineNotificationService();


        public List<RejectedMedicineNotification> getAll()
        {
            return service.getAll();
        }

        public void createNotification(RejectedMedicineNotification notification)
        {
            service.createNotification(notification);
        }

        public void deleteNotification(int notificationId)
        {
            service.deleteNotification(notificationId);
        }
    }
}
