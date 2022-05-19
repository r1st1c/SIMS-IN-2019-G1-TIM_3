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
    /// Interaction logic for Anamnesis.xaml
    /// </summary>
    public partial class Anamnesis : Window
    {
        ReportController reportController = new ReportController();
        public static ObservableCollection<Report> Reports { get; set;  }

       
        public int PatientId { get; set; }
        public Anamnesis(int id)
        {
            InitializeComponent();
            this.DataContext = this;
            PatientId = id;
            Reports = new ObservableCollection<Report>(reportController.getAllById(PatientId));
           
        }

        public void editReport(object sender, RoutedEventArgs e)
        {
            Report report = (Report)((Button)e.Source).DataContext;
            int editid = report.Id;
            EditReport editReport = new EditReport(editid);
            editReport.Show();
            
        }

        public void deleteReport(object sender, RoutedEventArgs e)
        {
            Report report = (Report)((Button)e.Source).DataContext;
            Reports.Remove(report);
            this.reportController.delete(report.Id);
            
        }

        

    
        private void HomeBtn(object sender, RoutedEventArgs e)
        {
            MainPage mainPage = new MainPage();
            mainPage.Show();
            this.Close();
        }

        private void createNewApp(object sender, RoutedEventArgs e)
        {
            CreateNewAppointmentWindow c = new CreateNewAppointmentWindow();
            c.Show();
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

    }
}
