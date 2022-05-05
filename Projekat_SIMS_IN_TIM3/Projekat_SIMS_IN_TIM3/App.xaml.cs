using Projekat_SIMS_IN_TIM3.Controller;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Projekat_SIMS_IN_TIM3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public readonly UserController userController = new UserController();
        public readonly PatientController patientController = new PatientController();
        public readonly GuestController guestController = new GuestController();
        public readonly AppointmentController appointmentController = new AppointmentController();
        public readonly DoctorController docController = new DoctorController();
        public readonly AllergenController allergenController = new AllergenController();

        public string id;
        internal object doctorController;
    }
}
