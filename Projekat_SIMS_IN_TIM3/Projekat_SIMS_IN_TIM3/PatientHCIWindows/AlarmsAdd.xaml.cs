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
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xceed.Wpf.Toolkit;
using MessageBox = System.Windows.MessageBox;

namespace Projekat_SIMS_IN_TIM3.PatientHCIWindows
{
    /// <summary>
    /// Interaction logic for AlarmsAdd.xaml
    /// </summary>
    public partial class AlarmsAdd : Page
    {
        string Username;
        public App application { get; set; }
        public Patient patient = new Patient();
        public static List<Alarm> alarms { get; set; } = new List<Alarm>();
        public static List<Alarm> currentAlarms { get; set; } = new List<Alarm>();
        public AlarmsAdd(String Username)
        {
            InitializeComponent();

            this.DataContext = this;

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


            parentWindow.Notif.Content = new Alarms(Username);

        }

        public void Confirm_Click(object sender, RoutedEventArgs e)
        {
            MainWindowPatient parentWindow = Window.GetWindow(this) as MainWindowPatient;

            Alarm alarm = new Alarm(patient.User.Id, (DateTime)startTime1.Value, this.Text.Text);

            this.application.alarmController.Create(alarm);

            parentWindow.Notif.Content = new Alarms(Username);

        }
    }
}
