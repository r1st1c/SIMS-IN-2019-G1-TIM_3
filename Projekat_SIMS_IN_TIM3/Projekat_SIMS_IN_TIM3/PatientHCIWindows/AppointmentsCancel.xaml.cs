using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.MainWindows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekat_SIMS_IN_TIM3.PatientHCIWindows
{
    /// <summary>
    /// Interaction logic for AppointmentsCancel.xaml
    /// </summary>
    public partial class AppointmentsCancel : Page
    {
        public App application { get; set; }

        public String Username { get; set; }

        public int appointmentId { get; set; }

        public Patient patient { get; set; }    
        public AppointmentsCancel(int Id, String Username)
        {
            InitializeComponent();
            this.DataContext = this;
            this.appointmentId = Id;
            this.Username = Username;

            application = Application.Current as App;

            getPatient(Username);

        }

        public void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindowPatient parentWindow = Window.GetWindow(this) as MainWindowPatient;



            parentWindow.Notif.Content = new Appointments(Username);


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


        public void Confirm_Click(object sender, RoutedEventArgs e)
        {
            MainWindowPatient parentWindow = Window.GetWindow(this) as MainWindowPatient;


            
            Boolean canceledAppointment = application.appointmentController.Cancel(patient.User.Id, appointmentId);

            if (canceledAppointment)
            {
                parentWindow.Notif.Content = new Appointments(Username);
            }
            else
            {
                /*this.application.userLoginController.DeleteLogIn(Username);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
                toBlock = true;*/
                MessageBox.Show("Error");
            }

        }
    }
}
