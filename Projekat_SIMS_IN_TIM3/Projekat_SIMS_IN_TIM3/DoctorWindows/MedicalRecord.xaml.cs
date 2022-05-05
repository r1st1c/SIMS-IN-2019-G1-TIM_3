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
        public int PatientId { get; set; }
       
      
        public MedicalRecord(int patid)
        {
            InitializeComponent();
            this.DataContext = this;
            PatientId = patid;
            pname.Content = pc.getName(PatientId);
            surname.Content = pc.getSurname(PatientId);
            jmbg.Content = pc.getJMBG(PatientId);
            DateOfBirth.Content = pc.getDateOfBirth(PatientId);
            Address.Content = pc.getAddress(PatientId);
            Email.Content = pc.getEmail(PatientId);
            TelephoneNumber.Content = pc.getTelNumber(PatientId);
            
      
        }

        private void HomeBtn(object sender, RoutedEventArgs e)
        {
            MainPage mainPage = new MainPage();
            mainPage.Show();
            this.Close();
        }
        private void CalendarPageBtn(object sender, RoutedEventArgs e)
        {
            Calendar calendar = new Calendar();
            calendar.Show();
            this.Close();
        }

        private void NotifBtn(object sender, RoutedEventArgs e)
        {
            Notifications notifications = new Notifications();
            notifications.Show();
            this.Close();
        }

        private void ListOfMedBtn(object sender, RoutedEventArgs e)
        {
            ListOfMedicines listOfMedicines = new ListOfMedicines();
            listOfMedicines.Show();
            this.Close();
        }

        private void MedVerifBtn(object sender, RoutedEventArgs e)
        {
            MedVerif medVerif = new MedVerif();
            medVerif.Show();
            this.Close();
        }

        private void AbsenceReqBtn(object sender, RoutedEventArgs e)
        {
            CreateAbsenceReq createAbsenceReq = new CreateAbsenceReq();
            createAbsenceReq.Show();
            this.Close();
        }

        public void addMedPrescription(object sender, RoutedEventArgs e)
        {
            AddMedPrescription addMedPrescription = new AddMedPrescription(PatientId);
            addMedPrescription.Show();
        }

        public void addReport(object sender, RoutedEventArgs e)
        {
            AddReport addReport = new AddReport();
            addReport.Show();
        }
    }
}
