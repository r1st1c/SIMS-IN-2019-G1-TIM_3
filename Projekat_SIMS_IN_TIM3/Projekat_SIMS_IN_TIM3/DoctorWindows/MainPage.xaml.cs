using Projekat_SIMS_IN_TIM3.Controller;
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
using System.Windows.Shapes;

namespace Projekat_SIMS_IN_TIM3.DoctorWindows
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    /// 
    

    public partial class MainPage : Window
    {

        public String DoctorsNameAndSurname { get; set; }
        DoctorController doctorController = new DoctorController();
        public String WelcomeMessage { get; set; }

        public int DoctorId { get; set; }
        public MainPage(int doctorsId)
        {
            InitializeComponent();
            this.DataContext = this;
            DoctorId = doctorsId;
            WelcomeMessage = "Welcome back, " + doctorController.GetById(doctorsId).User.Name.ToString() + "!";
            DoctorsNameAndSurname = doctorController.GetById(DoctorId).User.Name.ToString() + " " + doctorController.GetById(DoctorId).User.Surname.ToString();
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
