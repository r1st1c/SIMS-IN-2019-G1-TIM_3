using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string DateAndTime { get; set; }

        public AppointmentDTO(string DoctorName, string DateAndTime, int Id)
        {
            this.DoctorName = DoctorName;
            this.DateAndTime = DateAndTime;
            this.Id = Id;
        }
        
    }
}
