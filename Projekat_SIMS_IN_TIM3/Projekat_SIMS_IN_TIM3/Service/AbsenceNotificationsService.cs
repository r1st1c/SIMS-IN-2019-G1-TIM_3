using Projekat_SIMS_IN_TIM3.IRepository;
using Projekat_SIMS_IN_TIM3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class AbsenceNotificationsService
    {
        private AbsenceNotificationsIRepository iRepository;
        public AbsenceNotificationsService(AbsenceNotificationsIRepository iRepository)
        {
            this.iRepository = iRepository;
        }

        public int GetNextId()
        {
            return iRepository.GetNextId();
        }
        public void Create(AbsenceNotification notification)
        {
            iRepository.Create(notification);
        }
        public void Delete(int id)
        {
            iRepository.Delete(id);
        }
        public List<AbsenceNotification> GetAll()
        {
            return iRepository.GetAll();
        }
        public List<AbsenceNotification> GetByDoctorsId(int id)
        {
            return iRepository.GetByDoctorsId(id);
        }
        public AbsenceNotification GetById(int id)
        {
            return iRepository.GetById(id);
        }



    }
}
