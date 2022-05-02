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
using System.Collections.ObjectModel;

namespace Projekat_SIMS_IN_TIM3.DoctorWindows
{
    /// <summary>
    /// Interaction logic for CreateNewAppointmentWindow.xaml
    /// </summary>
    public partial class CreateNewAppointmentWindow : Window
    {
        App app;
        List<Appointment> appointments = new List<Appointment>();
        private Appointment chosen;

        DoctorController doctorController = new DoctorController();
        public ObservableCollection<string> Doctors { get; set; }
        private Doctor DoctorSelected;

        PatientController patientController = new PatientController();
        public ObservableCollection<string> Patients { get; set; }
        private Patient PatientSelected;

        private AppointmentType AppTypeSelected;

        //RoomController roomController = new RoomController();
        //public ObservableCollection<Room> Rooms { get; set; }
        //private Room RoomSelected;
        public ObservableCollection<AppointmentType> AppTypes { get; set; }

        int lastId = 0;
        public CreateNewAppointmentWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            app = Application.Current as App;
            appointments = app.appointmentController.GetAll();
            Doctors = new ObservableCollection<string>(doctorController.nameSurnameSpec());
            Patients = new ObservableCollection<string>(patientController.nameSurname());
            //Rooms = new ObservableCollection<int>(roomController.GetAll());
            AppTypes = new ObservableCollection<AppointmentType>(Enum.GetValues(typeof(AppointmentType)).Cast<AppointmentType>().ToList());

        }
        
        public void Create(object sender, RoutedEventArgs e)
          {
                    lastId++;
            // patient, apptype, doctor, startTime1, duration
            DateTime dt = (DateTime)startTime1.Value;
            AppointmentType at = AppTypeSelected;
            
            int patientId = PatientSelected.User.Id;
            int doctorsId = DoctorSelected.User.Id;
            int dur = Convert.ToInt32(duration.Text);

            if(dt < DateTime.Now)
            {
                MessageBox.Show("Wrong date and time! Enter new values for it!");
                return;
            }

            if(dur < 0)
            {
                MessageBox.Show("Duration cannot be negative number");
            }

            if(dt == null || at == null || dur == null || patientId == null || doctorsId == null )
            {
                MessageBox.Show("All fields are necessary!");
                return;
            } else
            {
                var newApp = new Appointment(
                        lastId,
                        dt,
                        dur,
                        at,
                        doctorsId, patientId);

                app.appointmentController.CreateAppointment(newApp);

               MessageBoxResult result = MessageBox.Show("You have successfully scheduled new appointment! \n Check calendar to see all scheduled appointments!", "Scheduled appointment", MessageBoxButton.OK);
               switch(result)
                {
                    case MessageBoxResult.OK:
                        Calendar calendar = new Calendar();
                        calendar.Show();
                        break;
                }
            }
           
                }
        public void Cancel(object sender, RoutedEventArgs e)
        {
            
            
              MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel scheduling new appointment? \n + By canceling it, all previously entered data will disappear!", "Cancel appointment", MessageBoxButton.YesNo);
              switch(result)
            {
                case MessageBoxResult.Yes:
                    Calendar calendar = new Calendar();
                    calendar.Show();
                break;

                case MessageBoxResult.No:
                    Close();
                    break;
            }
            
        }
    }
}
