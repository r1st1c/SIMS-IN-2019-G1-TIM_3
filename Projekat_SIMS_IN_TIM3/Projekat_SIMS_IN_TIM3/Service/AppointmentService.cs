using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
{
     public class AppointmentService
    {
        public AppointmentRepository appointmentRepository = new AppointmentRepository();
        

        public List<Appointment> getAll()
        {
            return this.appointmentRepository.getAll();
        }
    
    }
}
