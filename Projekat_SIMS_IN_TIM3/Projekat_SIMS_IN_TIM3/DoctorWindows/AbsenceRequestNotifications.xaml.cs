using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.IRepository;
using Projekat_SIMS_IN_TIM3.MainWindows;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using Projekat_SIMS_IN_TIM3.Service;
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
    /// Interaction logic for AbsenceRequestNotifications.xaml
    /// </summary>
    public partial class AbsenceRequestNotifications : Window
    {
        public String DoctorsNameAndSurname { get; set; }
        DoctorController doctorController = new DoctorController();
        AbsenceNotificationsController AbsenceNotificationsController;
        public static ObservableCollection<AbsenceNotification> Notifications { get; set; }

        public int DoctorId { get; set; }
        public AbsenceRequestNotifications(int doctorsId)
        {
            InitializeComponent();
            this.DataContext = this;
            DoctorId = doctorsId;

            AbsenceNotificationsIRepository notificationsIRepository = new AbsenceNotificationsRepository();
            AbsenceNotificationsService absenceNotificationsService = new AbsenceNotificationsService(notificationsIRepository);
            AbsenceNotificationsController = new AbsenceNotificationsController(absenceNotificationsService);


            Notifications = new ObservableCollection<AbsenceNotification>(AbsenceNotificationsController.GetByDoctorsId(doctorsId));
            DoctorsNameAndSurname = doctorController.GetById(Convert.ToInt32(DoctorId)).User.Name.ToString() + " " + doctorController.GetById(Convert.ToInt32(DoctorId)).User.Surname.ToString();
        }

        private void HomeBtn(object sender, RoutedEventArgs e)
        {
            MainPage mainPage = new MainPage(DoctorId);
            mainPage.Show();
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

        private void AbsenceReqBtn(object sender, RoutedEventArgs e)
        {
            CreateAbsenceReq createAbsenceReq = new CreateAbsenceReq(DoctorId);
            createAbsenceReq.Show();
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

        


    }
}
