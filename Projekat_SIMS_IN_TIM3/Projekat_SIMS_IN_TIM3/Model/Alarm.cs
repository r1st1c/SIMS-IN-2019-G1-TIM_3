using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class Alarm
    {
        public int PatientId { get; set; }
        public DateTime Time { get; set; }
        public string Text { get; set; }


        public Alarm(int PatientId, DateTime Time, String Text)
        {
            this.PatientId = PatientId;
            this.Time = Time;
            this.Text = Text;
        }
    }
}
