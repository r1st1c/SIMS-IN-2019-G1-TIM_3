using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;
using System.Collections.Generic;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class AbsenceNotificationsController
    {
        public AbsenceNotificationsService notificationsService;

        public AbsenceNotificationsController(AbsenceNotificationsService notificationsService)
        {
            this.notificationsService = notificationsService;
        }

        public int GetNextId()
        {
            return notificationsService.GetNextId();
        }
        public void Create(AbsenceNotification notification)
        {
            notificationsService.Create(notification);
        }
        public void Delete(int id)
        {
            notificationsService.Delete(id);
        }
        public List<AbsenceNotification> GetAll()
        {
            return notificationsService.GetAll();
        }
        public List<AbsenceNotification> GetByDoctorsId(int id)
        {
            return notificationsService.GetByDoctorsId(id);
        }
        public AbsenceNotification GetById(int id)
        {
            return notificationsService.GetById(id);
        }
    }
}
