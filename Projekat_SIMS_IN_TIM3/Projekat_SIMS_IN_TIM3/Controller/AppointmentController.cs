using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class AppointmentController
    {
        public AppointmentService appointmentService = new AppointmentService();

        public List<Appointment> getAll()
        {
            return this.appointmentService.getAll();
        }

    }
}
