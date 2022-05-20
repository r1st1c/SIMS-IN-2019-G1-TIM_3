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
    public partial class MainPage : Window
    {
        public int DoctorId { get; set; }
        public MainPage(int doctorsId)
        {
            InitializeComponent();
            DoctorId = doctorsId;
        }

        private void HomeBtn(object sender, RoutedEventArgs e)
        {
            MainPage mainPage = new MainPage(DoctorId);
            mainPage.Show();
        }
        private void CalendarPageBtn(object sender, RoutedEventArgs e)
        {
            Calendar calendar = new Calendar(DoctorId);
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
            MedVerif medVerif = new MedVerif(DoctorId);
            medVerif.Show();
        }

        private void AbsenceReqBtn(object sender, RoutedEventArgs e)
        {
            CreateAbsenceReq createAbsenceReq = new CreateAbsenceReq(DoctorId);
            createAbsenceReq.Show();
        }
    }
}
