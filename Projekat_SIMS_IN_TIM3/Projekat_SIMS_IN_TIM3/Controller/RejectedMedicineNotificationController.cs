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


        public List<RejectedMedicineNotification> GetAll()
        {
            return service.GetAll();
        }

        public void Create(RejectedMedicineNotification notification)
        {
            service.Create(notification);
        }

        public void Delete(int notificationId)
        {
            service.Delete(notificationId);
        }
    }
}
