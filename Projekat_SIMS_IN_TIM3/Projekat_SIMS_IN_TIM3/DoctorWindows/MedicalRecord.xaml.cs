using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Model;
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
    /// Interaction logic for MedicalRecord.xaml
    /// </summary>
    public partial class MedicalRecord : Window
    {
        MedicalRecordController mcnt = new MedicalRecordController();
        
        PatientController pc = new PatientController();
        DoctorController doctorController = new DoctorController();
        public int PatientId { get; set; }
        public int DoctorId     { get; set; }

        public String DoctorsNameAndSurname { get; set; }
        public MedicalRecord(int patid, int doctorId)
        {
            InitializeComponent();
            this.DataContext = this;
            PatientId = patid;
            DoctorId = doctorId;
            pname.Content = pc.GetById(PatientId).User.Name.ToString();
            surname.Content = pc.GetById(PatientId).User.Surname.ToString();
            jmbg.Content = pc.GetById(PatientId).User.Jmbg.ToString();
            DateOfBirth.Content = (DateTime)pc.GetById(PatientId).User.DateOfBirth;
            Address.Content = pc.GetById(PatientId).User.Address.ToString();
            Email.Content = pc.GetById(PatientId).User.Email.ToString();
            TelephoneNumber.Content = pc.GetById(PatientId).User.Phone.ToString();

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

        public void addMedPrescription(object sender, RoutedEventArgs e)
        {
            AddMedPrescription addMedPrescription = new AddMedPrescription(PatientId, DoctorId);
            addMedPrescription.Show();
        }

        public void addReport(object sender, RoutedEventArgs e)
        {
            AddReport addReport = new AddReport(DoctorId, PatientId);
            addReport.Show();
        }

        public void addAllergen(object sender, RoutedEventArgs e)
        {
            AddAllergen addAllergen = new AddAllergen(PatientId, DoctorId);
            addAllergen.Show();
        }

        public void seeMoreLink(object sender, RoutedEventArgs e)
        {
            int id = (int)labelPatientId.Content;
            Anamnesis amamnesis = new Anamnesis(id, DoctorId);
            amamnesis.Show();
        }

        public void presc(object sender, RoutedEventArgs e)
        {
            int id = (int)labelPatientId.Content;
            anamnesisPrescriptions apr = new anamnesisPrescriptions(DoctorId,id);
            apr.Show();
        }

        
    }
}
