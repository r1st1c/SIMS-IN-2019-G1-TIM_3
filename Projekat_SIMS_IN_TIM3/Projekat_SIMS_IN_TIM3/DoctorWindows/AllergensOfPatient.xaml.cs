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
    /// Interaction logic for AllergensOfPatient.xaml
    /// </summary>
    public partial class AllergensOfPatient : Window
    {
        
        
        public String DoctorsNameAndSurname { get; set; }
        DoctorController doctorController = new DoctorController();
        PatientController patientController = new PatientController();
        AllergenController allergenController;
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        public static ObservableCollection<Allergen> Allergens { get; set; }

        public AllergensOfPatient(int patientsId, int doctorId)
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;

            this.doctorController = app.docController;
            this.patientController = app.patientController;
            this.allergenController = app.allergenController;

            PatientId = patientsId;
            DoctorId = doctorId;
            DoctorsNameAndSurname = doctorController.GetById(DoctorId).User.Name.ToString() + " " + doctorController.GetById(DoctorId).User.Surname.ToString();
            Allergens = new ObservableCollection<Allergen>(allergenController.GetByPatientsId(patientsId));
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
