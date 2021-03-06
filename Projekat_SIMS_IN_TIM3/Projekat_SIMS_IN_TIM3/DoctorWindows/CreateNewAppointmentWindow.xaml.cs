using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Service;
using Projekat_SIMS_IN_TIM3.Repository;
using Projekat_SIMS_IN_TIM3.IRepository;
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
        public String DoctorsNameAndSurname { get; set; }
        List<Appointment> appointments = new List<Appointment>();
        private Appointment chosen;

        public static AppointmentIRepository appointmentRepository = new AppointmentRepository();
        public static PatientService patientService = new PatientService();
        public static AppointmentService appointmentService = new AppointmentService(appointmentRepository, patientService);

        AppointmentController appointmentController = new AppointmentController(appointmentService);
        DoctorController doctorController = new DoctorController();
        public ObservableCollection<string> Doctors { get; set; }
        private string DoctorSelected;

        PatientController patientController = new PatientController();
        public ObservableCollection<string> Patients { get; set; }
        private string PatientSelected;

        public ObservableCollection<int> PatientsIds { get; set; }

        private AppointmentType AppTypeSelected;

        public int DoctorId { get; set; }

        //RoomController roomController = new RoomController();
        //public ObservableCollection<Room> Rooms { get; set; }
        //private Room RoomSelected;
        public ObservableCollection<AppointmentType> AppTypes { get; set; }

        int lastId = int.MinValue;
        public CreateNewAppointmentWindow(int doctorId)
        {
            InitializeComponent();
            this.DataContext = this;
            DoctorId = doctorId;
            app = Application.Current as App;
            appointments = app.appointmentController.GetAll();
            Doctors = new ObservableCollection<string>(doctorController.NameSurnameSpec());
            Patients = new ObservableCollection<string>(patientController.nameSurname());
          
            AppTypes = new ObservableCollection<AppointmentType>(Enum.GetValues(typeof(AppointmentType)).Cast<AppointmentType>().ToList());
            DoctorsNameAndSurname = doctorController.GetById(DoctorId).User.Name.ToString() + " " + doctorController.GetById(DoctorId).User.Surname.ToString();
        }
        
        public void Create(object sender, RoutedEventArgs e)
          {
                    
            // patient, apptype, doctor, startTime1, duration
            DateTime dt = (DateTime)startTime1.Value;
            AppointmentType at = AppTypeSelected;

            string pat = patientCb.SelectedItem.ToString();
            string[]? strings = pat.Split(" ");
            string patname = strings[0];
            string patsurname = strings[1];

            string doc = doctorCb.SelectedItem.ToString();
            string[]? strings1 = doc.Split(" ");
            string docname = strings1[0];
            string docsurname = strings1[1];
            string docspec = strings1[2];

            int patientId = patientController.getIdByNameAndSurname(patname, patsurname);
            int doctorsId = doctorController.GetIdByNameAndSurname(docname, docsurname);
            int dur = Convert.ToInt32(duration.Text);

            if(dt < DateTime.Now)
            {
                MessageBox.Show("Wrong date and time! Enter new values for it!");
                return;
            }

            if(dur < 0)
            {
                MessageBox.Show("Duration cannot be negative number");
                return;
            }

            if(dt == null || at == null || dur == null || patientId == null || doctorsId == null )
            {
                MessageBox.Show("All fields are necessary!");
                return;
            } else
            {
                lastId = appointmentController.GetNextId(); 
                var newApp = new Appointment(
                        lastId,
                        dt,
                        dur,
                        at,
                        Convert.ToInt32(DoctorId), Convert.ToInt32(patientId));

                app.appointmentController.Create(newApp);

               MessageBoxResult result = MessageBox.Show("You have successfully scheduled new appointment! \n Check calendar to see all scheduled appointments!", "Scheduled appointment", MessageBoxButton.OK);
               switch(result)
                {
                    case MessageBoxResult.OK:
                        Calendar calendar = new Calendar(DoctorId);
                        calendar.Show();
                        break;
                }
                this.Close();
            }
           
                }
        public void Cancel(object sender, RoutedEventArgs e)
        {
            
            
              MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel scheduling new appointment? \n + By canceling it, all previously entered data will disappear!", "Cancel appointment", MessageBoxButton.YesNo);
              switch(result)
            {
                case MessageBoxResult.Yes:
                    Calendar calendar = new Calendar(DoctorId);
                    calendar.Show();
                break;

                case MessageBoxResult.No:
                    Close();
                    break;
            }
            
        }
    }
}
