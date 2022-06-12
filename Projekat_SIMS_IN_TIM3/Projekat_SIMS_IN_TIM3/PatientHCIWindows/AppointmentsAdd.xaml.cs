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
    /// Interaction logic for AppointmentsAdd.xaml
    /// </summary>
    public partial class AppointmentsAdd : Page
    {
        string Username;
        public App application { get; set; }

        public Patient patient = new Patient();

        public AppointmentDTO selectedAppointment { get; set; }
        public static List<Appointment> appointments { get; set; } = new List<Appointment>();
        public static List<AppointmentDTO> appointmentsList { get; set; } = new List<AppointmentDTO>();

        public static ObservableCollection<AppointmentDTO> appointmentsCollection { get; set; }

        public SearchAppointmentDTO searchDTO { get; set; }

        public List<int> toRemove { get; set; } = new List<int>();

        UIElement parent = App.Current.MainWindow;
        public AppointmentsAdd(SearchAppointmentDTO searchDTO)
        {
            InitializeComponent();

            this.DataContext = this;
            this.searchDTO = searchDTO;
            this.Username = searchDTO.Username;
            application = Application.Current as App;

            getPatient(Username);

            appointments.Clear();
            appointmentsList.Clear();

            appointments = application.appointmentController.GetByDoctorsId(searchDTO.DoctorId);

            makeDTOs(appointments);

            GetFittingAppointments();

            appointmentsCollection = new ObservableCollection<AppointmentDTO>(appointmentsList);

        }

        public void GetFittingAppointments()
        {
            RemoveUnfittingByDateAppointments();

            if(appointments.Count == 0)
            {
                if (searchDTO.Priority == "Doctor")
                {
                    appointments = application.appointmentController.GetByDoctorsId(searchDTO.DoctorId);
                    return;
                }
                else
                {
                    RemoveUnfittingByDoctorAppointments();
                    return;
                }

            }

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

        public void RemoveUnfittingByDateAppointments()
        {
            DateTime wantedStartTime = searchDTO.StartTime;
            DateTime wantedEndTime = searchDTO.EndTime;

            foreach (Appointment app in appointments)
            {
                if (app.StartTime < wantedStartTime || app.StartTime > wantedEndTime || app.PatientId != -1)
                {
                    toRemove.Add(app.Id);
                }

            }

            RemoveAppointments();
        }

        public void RemoveAppointments()
        {
            foreach (int id in toRemove)
            {
                for (int i = 0; i < appointments.Count; i++)
                {
                    if (appointments[i].Id == id)
                    {
                        appointments.Remove(appointments[i]);
                    }
                }
            }

            toRemove.Clear();
        }

        public void RemoveUnfittingByDoctorAppointments()
        {
            DateTime wantedStartTime = searchDTO.StartTime;
            DateTime wantedEndTime = searchDTO.EndTime;

            Doctor doctor = application.docController.GetById(searchDTO.DoctorId);
            string specialization = doctor.specializationType;
            appointments = application.appointmentController.GetAll();

            foreach (Appointment app in appointments)
            {
                Doctor currDoc = application.docController.GetById(app.DoctorId);
                string currSpec = currDoc.specializationType;
                if (currSpec != specialization || app.PatientId != -1 || app.StartTime < wantedStartTime || app.StartTime > wantedEndTime)
                {
                    toRemove.Add(app.Id);
                }
            }

            RemoveAppointments();
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {

            ApplyForAppointment();

            MainWindowPatient parentWindow = Window.GetWindow(this) as MainWindowPatient;

            parentWindow.Notif.Content = new Appointments(Username);

        }

        public void ApplyForAppointment()
        {
            selectedAppointment = (AppointmentDTO)data.SelectedItem;
            int appointmentId = selectedAppointment.Id;

            var appointment = application.appointmentController.GetById(appointmentId);

            application.appointmentController.Delete(appointmentId);
            var newAppointment = new Appointment(appointmentId, appointment.StartTime, appointment.DurationInMinutes,
                appointment.Type, appointment.DoctorId, patient.User.Id);

            application.appointmentController.Create(newAppointment);

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

            return new AppointmentDTO(name, Convert.ToString(appointment.StartTime), appointment.Id);
        }

        public void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindowPatient parentWindow = Window.GetWindow(this) as MainWindowPatient;


            parentWindow.Notif.Content = new AppointmentsSearch(Username);

        }

        /*
         private void Button_Click(object sender, RoutedEventArgs e)
        {
            int doctorId = Convert.ToInt32(txtDoctorId.Text); //uvezati sa wpfom
            string priority = combobox.Text;
            
            DateTime wantedStartTIme = (DateTime)StartTime1.SelectedDate; //unesen pocetak
            DateTime wantedEndTIme = (DateTime)EndTime1.SelectedDate; //unesen kraj

            appointments = application.appointmentController.GetByDoctorsId(doctorId);


            List<int> toRemove = new List<int>();
            foreach (Appointment app in appointments)//Ne radi za vreme - ne radi iterator zbog remove
            {
                if (app.StartTime < wantedStartTIme || app.StartTime > wantedEndTIme || app.PatientId != -1)
                {
                    toRemove.Add(app.Id);
                }

            }
            foreach (int id in toRemove)
            {
                for (int i = 0; i < appointments.Count; i++)
                {
                    if (appointments[i].Id == id)
                    {
                        appointments.Remove(appointments[i]);
                    }
                }
            }


            if (appointments.Count > 0)
            {
                DataBinding1.ItemsSource = appointments;
                return;
            }
            else
            {
                if (priority == "Doctor")
                {
                    appointments = application.appointmentController.GetByDoctorsId(doctorId);
                    DataBinding1.ItemsSource = appointments;
                    return;
                }
                else
                {
                    Doctor doctor = application.docController.GetById(doctorId);

                    string specialization = doctor.specializationType;

                    appointments = application.appointmentController.GetAll();
                    foreach (Appointment app in appointments)
                    {
                        Doctor currDoc = application.docController.GetById(app.DoctorId);
                        string currSpec = currDoc.specializationType;
                        if (currSpec != specialization || app.PatientId != -1 || app.StartTime < wantedStartTIme || app.StartTime > wantedEndTIme)
                        {
                            toRemove.Add(app.Id);
                        }
                    }

                    foreach (int id in toRemove)
                    {
                        for (int i = 0; i < appointments.Count; i++)
                        {
                            if (appointments[i].Id == id)
                            {
                                appointments.Remove(appointments[i]);
                            }
                        }
                    }
                    DataBinding1.ItemsSource = appointments;
                    return;
                }
            }

        }
         */
    }
}
