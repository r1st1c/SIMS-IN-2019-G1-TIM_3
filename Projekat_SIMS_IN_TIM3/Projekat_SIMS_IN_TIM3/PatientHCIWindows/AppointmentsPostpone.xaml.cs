using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.MainWindows;
using Projekat_SIMS_IN_TIM3.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;
using MessageBox = System.Windows.MessageBox;

namespace Projekat_SIMS_IN_TIM3.PatientHCIWindows
{
    /// <summary>
    /// Interaction logic for AppointmentsPostpone.xaml
    /// </summary>
    public partial class AppointmentsPostpone : Page
    {
        public App application { get; set; }

        public String Username { get; set; }

        public int appointmentId { get; set; }

        public Patient patient { get; set; }

        public Appointment appointment { get; set; }
        public AppointmentsPostpone(int Id, String Username)
        {

            InitializeComponent();

            InitializeComponent();
            this.DataContext = this;
            this.appointmentId = Id;
            this.Username = Username;

            application = Application.Current as App;

            getPatient(Username);
        }

        public void getPatient(String Username)
        {
            List<Patient> patients = application.patientController.GetAll();

            foreach (Patient pat in patients)
            {
                if (pat.User.Username == Username)
                {
                    patient = pat;


                }
            }
        }


        public void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindowPatient parentWindow = Window.GetWindow(this) as MainWindowPatient;



            parentWindow.Notif.Content = new Appointments(Username);


        }

        public void Confirm_Click(object sender, RoutedEventArgs e)
        {
            MainWindowPatient parentWindow = Window.GetWindow(this) as MainWindowPatient;

            appointment = application.appointmentController.GetById(appointmentId);
            application.appointmentController.Delete(appointmentId);
            var newAppointment = new Appointment(appointmentId, (DateTime)startTime1.Value, appointment.DurationInMinutes,
                appointment.Type, appointment.DoctorId, appointment.PatientId);

            application.appointmentController.Create(newAppointment);

            parentWindow.Notif.Content = new Appointments(Username);

        }
    }
}
