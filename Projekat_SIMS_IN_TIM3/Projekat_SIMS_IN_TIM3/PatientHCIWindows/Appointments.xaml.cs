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
    /// Interaction logic for Appointments.xaml
    /// </summary>
    public partial class Appointments : Page
    {
        string Username;
        public App application { get; set; }
        public Patient patient = new Patient();
        public static List<Appointment> appointments { get; set; } = new List<Appointment>();
        public static List<AppointmentDTO> appointmentsList { get; set; } = new List<AppointmentDTO>();

        public static ObservableCollection<AppointmentDTO> appointmentsCollection { get; set; }
        public int patId { get; set; } = 1;
        UIElement parent = App.Current.MainWindow;
        public Appointments(String Username)
        {
            InitializeComponent();

            this.DataContext = this;

            this.Username = Username;
            application = Application.Current as App;

            getPatient(Username);

            appointments = application.appointmentController.GetByPatientsId(patient.User.Id);

            makeDTOs(appointments);

            appointmentsCollection = new ObservableCollection<AppointmentDTO>(appointmentsList);

            

        }

        public void makeDTOs(List<Appointment> appointments)
        {
            foreach (Appointment appointment in appointments)
            {
                appointmentsList.Add(makeDTO(appointment));
            }
        }

        public AppointmentDTO makeDTO(Appointment appointment)
        {
            Doctor doctor = this.application.docController.GetById(appointment.DoctorId);

            string name = doctor.User.Name + " " + doctor.User.Surname;

            return new AppointmentDTO(name, Convert.ToString(appointment.StartTime));
        }

        public void getPatient(String Username)
        {
            List<Patient> patients = application.patientController.GetAll();

            foreach (Patient pat in patients)
            {
                if (pat.User.Username == Username)
                {
                    patient = pat;
                    patId = pat.User.Id;

                }
            }
        }
        public void Add_Appointment_Click(object sender, RoutedEventArgs e)
        {
            /*MainWindowPatient parentWindow = Window.GetWindow(this) as MainWindowPatient;


            parentWindow.Notif.Content = new NotesAdd(Username, patId);*/
        }

        public void Edit_Appointment_Click(object sender, RoutedEventArgs e)
        {
            /*MainWindowPatient parentWindow = Window.GetWindow(this) as MainWindowPatient;

            Note note = (Note)((Button)e.Source).DataContext;
            int id = note.Id;
            
            parentWindow.Notif.Content = new NotesEdit(id, Username, patId);*/
        }

        public void Delete_Appointment_Click(object sender, RoutedEventArgs e)
        {
            /*MainWindowPatient parentWindow = Window.GetWindow(this) as MainWindowPatient;

            Note note = (Note)((Button)e.Source).DataContext;
            int id = note.Id;

            parentWindow.Notif.Content = new NotesDelete(id, Username);*/
        }


    }
}
