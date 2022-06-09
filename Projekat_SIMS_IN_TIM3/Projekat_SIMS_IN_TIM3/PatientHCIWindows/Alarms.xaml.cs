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

namespace Projekat_SIMS_IN_TIM3.PatientHCIWindows
{
    /// <summary>
    /// Interaction logic for Alarms.xaml
    /// </summary>
    public partial class Alarms : Page
    {

        string Username;
        public App application { get; set; }
        public Patient patient = new Patient();
        public static List<Alarm> alarms { get; set; } = new List<Alarm>();
        public static List<Alarm> currentAlarms { get; set; } = new List<Alarm>();  

        public Alarms(string Username)
        {
            InitializeComponent();

            this.DataContext = this;

            this.Username = Username;
            application = Application.Current as App;

            getPatient(Username);

            alarms.Clear();
            currentAlarms.Clear();

            alarms = this.application.alarmController.GetByPatientId(patient.User.Id);

            GetCurrentAlarms();
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

        public void GetCurrentAlarms()
        {
            foreach(Alarm alarm in alarms)
            {

                if(IsActive(alarm))
                {
                    currentAlarms.Add(alarm);
                }

            }
        }

        public Boolean IsActive(Alarm alarm)
        {
            TimeSpan timeDifference = alarm.Time.Subtract(DateTime.Now);
            return timeDifference.TotalSeconds < 60 && timeDifference.TotalSeconds>=0;
        }
        public void Add_Alarm_Click(object sender, RoutedEventArgs e)
        {
            MainWindowPatient parentWindow = Window.GetWindow(this) as MainWindowPatient;


            parentWindow.Notif.Content = new AlarmsAdd(Username);
        }
    }
}
