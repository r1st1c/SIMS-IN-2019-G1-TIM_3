using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Model;
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

        AppointmentController c = new AppointmentController();
        public static ObservableCollection<Appointment> Appointments { get; set; }
        public Calendar()
        {
            InitializeComponent();
            this.DataContext = this;
            Appointments = new ObservableCollection<Appointment>(c.GetAll());
        }

        private void HomeBtn(object sender, RoutedEventArgs e)
        {
            MainPage mainPage = new MainPage();
            mainPage.Show();
        }

        private void createNewApp(object sender, RoutedEventArgs e)
        {
            CreateNewAppointmentWindow c = new CreateNewAppointmentWindow();
            c.Show();
        }
        private void CalendarPageBtn(object sender, RoutedEventArgs e)
        {
            Calendar calendar = new Calendar();
            calendar.Show();
        }

        private void NotifBtn(object sender, RoutedEventArgs e)
        {
            Notifications notifications = new Notifications();
            notifications.Show();
        }

        private void ListOfMedBtn(object sender, RoutedEventArgs e)
        {
            ListOfMedicines listOfMedicines = new ListOfMedicines();
            listOfMedicines.Show();
        }

        private void MedVerifBtn(object sender, RoutedEventArgs e)
        {
            MedVerif medVerif = new MedVerif();
            medVerif.Show();
        }

        private void medRecordBtn(object sender, RoutedEventArgs e)
        {
            Appointment appointment = (Appointment)((Button)e.Source).DataContext;
            int patid = appointment.PatientId;
            var m = new MedicalRecord(patid);
           
            m.Show();
        }

        private void AbsenceReqBtn(object sender, RoutedEventArgs e)
        {
            CreateAbsenceReq createAbsenceReq = new CreateAbsenceReq();
            createAbsenceReq.Show();
        }

        private void cancelBtn(object sender, RoutedEventArgs e)
        {
            Appointment appointment = (Appointment)((Button)e.Source).DataContext;
            Appointments.Remove(appointment);
            this.c.DeleteAppointment(appointment.Id);
        }

       

        
    }
}
