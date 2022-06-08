using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class SearchAppointmentDTO
    {
        public int DoctorId { get; set; }
        public string Username { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Priority { get; set; }

        public SearchAppointmentDTO(int DoctorId, string Username, DateTime StartTime, DateTime EndTime, string Priority)
        {
            this.DoctorId = DoctorId;
            this.Username = Username;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.Priority = Priority;
        }
    }
}
