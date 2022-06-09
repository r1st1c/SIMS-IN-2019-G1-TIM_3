using Projekat_SIMS_IN_TIM3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.IRepository
{
    public interface AbsenceNotificationsIRepository
    {
        public void ReadJson();
        public void WriteToJson();
        public int GetNextId();
        public void Create(AbsenceNotification notification);
        public void Update(AbsenceNotification notification);
        public List<AbsenceNotification> GetAll();
        public void Delete(int id);
        public AbsenceNotification GetById(int id);
        public List<AbsenceNotification> GetByDoctorsId(int id);    


    }
}
