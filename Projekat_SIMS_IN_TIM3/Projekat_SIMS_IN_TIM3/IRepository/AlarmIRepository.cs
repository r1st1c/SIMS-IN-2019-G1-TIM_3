using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.Model;

namespace Projekat_SIMS_IN_TIM3.IRepository
{
     public interface AlarmIRepository
    {
        public void readJson();

        public void writeToJson();

        public List<Alarm> GetAll();

        public List<Alarm> GetByPatientId(int patientId);

        public void Create(Alarm alarm);
    }
}
