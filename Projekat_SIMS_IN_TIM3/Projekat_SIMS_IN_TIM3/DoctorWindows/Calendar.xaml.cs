using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Service;
using Projekat_SIMS_IN_TIM3.MainWindows;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.IRepository;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Projekat_SIMS_IN_TIM3.DoctorWindows
{
    /// <summary>
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class Calendar : Window
    {
        public static AppointmentIRepository appointmentRepository = new AppointmentRepository();
        public static PatientService patientService = new PatientService();
        public static AppointmentService appointmentService = new AppointmentService(appointmentRepository, patientService);
        public int DoctorId { get; set; }
        public String DoctorsNameAndSurname { get; set; }

        AppointmentController c = new AppointmentController(appointmentService);
        DoctorController doctorController = new DoctorController(); 
        public static ObservableCollection<Appointment> Appointments { get; set; }
        public Calendar(int doctorsId)
        {
            InitializeComponent();
            this.DataContext = this;
            this.DoctorId = doctorsId;

            DoctorsNameAndSurname = doctorController.GetById(DoctorId).User.Name.ToString() + " " + doctorController.GetById(DoctorId).User.Surname.ToString();
            Appointments = new ObservableCollection<Appointment>(c.GetByDoctorsId(Convert.ToInt32(DoctorId)));
        }

        private void HomeBtn(object sender, RoutedEventArgs e)
        {
            MainPage mainPage = new MainPage(DoctorId);
            mainPage.Show();
        }

        private void createNewApp(object sender, RoutedEventArgs e)
        {
            CreateNewAppointmentWindow c = new CreateNewAppointmentWindow(DoctorId);
            c.Show();
            this.Close();
        }

        private void createNewOp(object sender, RoutedEventArgs e)
        {
            NewOperation newOperation = new NewOperation(DoctorId);
            newOperation.Show();
            this.Close();
        }

        private void CalendarPageBtn(object sender, RoutedEventArgs e)
        {
            Calendar calendar = new Calendar(DoctorId);
            calendar.Show();
            this.Close();
        }

        private void NotifBtn(object sender, RoutedEventArgs e)
        {
            Notifications notifications = new Notifications(DoctorId);
            notifications.Show();
            this.Close();
        }

        private void MedVerifBtn(object sender, RoutedEventArgs e)
        {
            MedVerif medVerif = new MedVerif(DoctorId);
            medVerif.Show();
            this.Close();
        }

        private void medRecordBtn(object sender, RoutedEventArgs e)
        {
            Appointment appointment = (Appointment)((Button)e.Source).DataContext;
            int patid = appointment.PatientId;
            var m = new MedicalRecord(patid, DoctorId);
           
            m.Show();
            this.Close();
        }

        private void signOutBtn(object sender, RoutedEventArgs e)
        {
            this.Close();
            DoctorSignIn doctorSign = new DoctorSignIn();
            doctorSign.Show();
        }

        private void myProfileBtn(object sender, RoutedEventArgs e)
        {
            DoctorsProfile doctorsProfile = new DoctorsProfile(DoctorId);
            doctorsProfile.Show();
            this.Close();
        }

        private void AbsenceReqBtn(object sender, RoutedEventArgs e)
        {
            CreateAbsenceReq createAbsenceReq = new CreateAbsenceReq(DoctorId);
            createAbsenceReq.Show();
            this.Close();
        }

        private void cancelBtn(object sender, RoutedEventArgs e)
        {
            Appointment appointment = (Appointment)((Button)e.Source).DataContext;
            Appointments.Remove(appointment);
            this.c.Delete(appointment.Id);
            
        }

       

        
    }
}
