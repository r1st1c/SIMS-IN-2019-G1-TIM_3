using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class Notification
    {
        public Notification()
        {
            // TODO: implement
        }

        public Notification(int Id, String MedicineName, TimeSpan Time)
        {
            this.Id = Id;
            this.MedicineName = MedicineName;
            this.Time = Time;
        }



        ~Notification()
        {
            // TODO: implement
        }

        public int Id { get; set; }
        public String MedicineName { get; set; }
        public TimeSpan Time { get; set; }
    }
}
