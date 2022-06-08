using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class AlarmService
    {
        public AlarmRepository alarmRepository = new AlarmRepository();

        public List<Alarm> GetAll()
        {
            return alarmRepository.GetAll();
        }

        
        public void Create(Alarm alarm)
        {
            alarmRepository.Create(alarm);
        }

        public List<Alarm> GetByPatientId(int patientId)
        {
            return alarmRepository.GetByPatientId(patientId);
        }
    }
}
