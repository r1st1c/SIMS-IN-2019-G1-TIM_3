using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class Note
    {

        public Note()
        {
            // TODO: implement
        }

        public Note(int Id,int PatientId, String Title, String Text, DateTime Time)
        {
            this.Id = Id;
            this.PatientId = PatientId;
            this.Title = Title;
            this.Text = Text;
            this.Time = Time;
        }

        public Note(int Id, String Title, DateTime Time)
        {
            this.Id = Id;
            this.Title = Title;
            this.Time = Time;
        }



        ~Note()
        {
            // TODO: implement
        }

        public int Id { get; set; }
        public int PatientId { get; set; }
        public String Title { get; set; }
        public String Text { get; set; }

        public DateTime Time { get; set; }
    }
}
