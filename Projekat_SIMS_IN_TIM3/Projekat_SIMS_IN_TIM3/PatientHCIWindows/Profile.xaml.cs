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
using System.Collections.ObjectModel;

namespace Projekat_SIMS_IN_TIM3.PatientHCIWindows
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        string Username;
        public App application { get; set; }
        public List<MedicinePrescription> prescriptions { get; set; }
        public Patient patient { get; set; }
        public List<Notification> notifications { get; set; }
        public Profile(String Username)
        {
            InitializeComponent();

            application = Application.Current as App;

            prescriptions = application.medPrescriptionController.GetAll();
            List<Patient> patients = application.patientController.GetAll();

            this.Username = Username;

            patient = null;

            foreach (Patient pat in patients)
            {
                if (pat.User.Username == Username)
                {
                    patient = pat;
                    break;
                }
            }

            this.uname.Text=patient.User.Username;
            this.name.Text = patient.User.Name;
            this.surname.Text = patient.User.Surname;
            this.email.Text = patient.User.Email;
            this.address.Text = patient.User.Address;
            this.birthday.Text = Convert.ToString(patient.User.DateOfBirth);

        }
        public void Prescriptions_Click(object sender, RoutedEventArgs e)
        {
            MainWindowPatient parentWindow = Window.GetWindow(this) as MainWindowPatient;


            parentWindow.Notif.Content = new Prescriptions(Username);
        }

    }
}
