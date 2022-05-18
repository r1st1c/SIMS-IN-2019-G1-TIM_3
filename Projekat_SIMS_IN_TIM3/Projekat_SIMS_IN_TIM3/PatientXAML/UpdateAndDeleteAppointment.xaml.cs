using Projekat_SIMS_IN_TIM3.Model;
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

namespace Projekat_SIMS_IN_TIM3.PatientXAML
{
    /// <summary>
    /// Interaction logic for UpdateAndDeleteAppointment.xaml
    /// </summary>
   
    public partial class UpdateAndDeleteAppointment : Window
    {

        public Boolean toBlock = true;
        public App application { get; set; }
        public List<Appointment> appointments { get; set; } = new List<Appointment>();
        public Appointment selectedAppointment { get; set; }
        /* public AppText appText { get; set; }
         public List<AppText> appTexts {get; set;} = new List<AppText>();*/

        public int patientId = 1;
        public String Username;
        public UpdateAndDeleteAppointment(string Username)
        {
            InitializeComponent();
            this.DataContext = this;
            this.Username = Username;
            application = Application.Current as App;

            List<Patient> patients = this.application.patientController.GetAll();

            foreach(Patient pat in patients)
            {
                if(pat.User.Username == Username)
                {
                    patientId = pat.User.Id;
                    break;
                }
            }

            var appsNew = application.appointmentController.GetByPatientsId(1);
            
         
            DataBinding1.ItemsSource = appsNew;
        }

        public void Show(object sender, RoutedEventArgs e)
        {
            var appsNew = application.appointmentController.GetByPatientsId(1);
            DataBinding1.ItemsSource = appsNew;
        }

        public void Cancel(object sender, RoutedEventArgs e)
        {
            Boolean canceledAppointment = application.patientController.cancelAppointment(patientId, selectedAppointment.Id);

            if(canceledAppointment)
            {
                Show(sender, e);
                toBlock = false;
            }
            else
            {
                this.application.userLoginController.DeleteLogIn(Username);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
                toBlock = true;
            }

           
        }

        public void Select(object sender, RoutedEventArgs e)
        {
            selectedAppointment = (Appointment)DataBinding1.SelectedItem;
          
        }

        public void Update(object sender, RoutedEventArgs e)
        {

            DateTime startTime = (DateTime)startTime1.Value;

            TimeSpan diff = startTime.Subtract(DateTime.Now);

            int appointmentId = selectedAppointment.Id;
            Appointment currApp = application.appointmentController.GetById(appointmentId);

            DateTime initialDate = currApp.StartTime;

            TimeSpan initialDiff = startTime.Subtract(initialDate);

            if (diff.TotalDays < 1 || initialDiff.TotalDays > 4 || initialDiff.TotalMilliseconds < 0 || diff.TotalMilliseconds < 0)
            {
                if (initialDiff.TotalMilliseconds < 0 || diff.TotalMilliseconds < 0)
                {
                    MessageBox.Show("Cannot update backwards");

                }
                else
                {
                    if (diff.TotalDays <= 1 && initialDiff.TotalDays <= 4)
                    {
                        MessageBox.Show("Too late to update appointment");
                    }
                    else if (initialDiff.TotalDays > 4 && diff.TotalDays >= 1)
                    {
                        MessageBox.Show("New date too far from initial date");
                    }
                    else
                    {
                        MessageBox.Show("Too late to update and new date too far from initial date");
                    }
                }
            }
            else
            {
                Cancel(sender, e);

                if (toBlock)
                {

                    application.appointmentController.DeleteAppointment(appointmentId);
                    var newAppointment = new Appointment(appointmentId, (DateTime)startTime1.Value, selectedAppointment.DurationInMinutes,
                        selectedAppointment.Type, selectedAppointment.DoctorId, selectedAppointment.PatientId);


                    application.appointmentController.CreateAppointment(newAppointment);
                }    
            }
        }
    }

    
}
