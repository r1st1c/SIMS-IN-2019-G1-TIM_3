using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class AlarmController
    {
        public AlarmController(AlarmService alarmService)
        {
            this.alarmService = alarmService;
        }

        public AlarmService alarmService;

        public List<Alarm> GetAll()
        {
            return alarmService.GetAll();
        }


        public void Create(Alarm alarm)
        {
            alarmService.Create(alarm);
        }

        public List<Alarm> GetByPatientId(int patientId)
        {
            return alarmService.GetByPatientId(patientId);
        }
    }
}
