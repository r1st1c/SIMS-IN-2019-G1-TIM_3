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

namespace Projekat_SIMS_IN_TIM3.DoctorWindows
{
    /// <summary>
    /// Interaction logic for DoctorsProfile.xaml
    /// </summary>
    public partial class DoctorsProfile : Window
    {
        DoctorController doctorController = new DoctorController();
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }

        public DoctorsProfile(int doctorsId)
        {
            InitializeComponent();
            this.DataContext = this;
            DoctorId = doctorsId;
            pname.Content = doctorController.GetById(DoctorId).User.Name.ToString();
            surname.Content = doctorController.GetById(DoctorId).User.Surname.ToString();   
            jmbg.Content = doctorController.GetById(DoctorId).User.Jmbg.ToString();
            DateOfBirth.Content = Convert.ToDateTime(doctorController.GetById(DoctorId).User.DateOfBirth);
            Address.Content = doctorController.GetById(DoctorId).User.Address.ToString();
            Email.Content = doctorController.GetById(DoctorId).User.Email.ToString();
            TelephoneNumber.Content = doctorController.GetById(DoctorId).User.Phone.ToString();
            specialization.Content = doctorController.GetById(DoctorId).specializationType.ToString();
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


    }
}
