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
    /// Interaction logic for EditReport.xaml
    /// </summary>
    public partial class EditReport : Window
    {
        public ObservableCollection<AppointmentType> AppTypes { get; set; }
        private AppointmentType AppTypeSelected;
        int lastId = int.MinValue;
        ReportController reportController = new ReportController();
        PatientController patientController = new PatientController();
        public ObservableCollection<string> Patients { get; set; }
        public int SelectedReportId { get; set; }
        public EditReport(int editId)
        {
            InitializeComponent();
            this.DataContext = this;
            Patients = new ObservableCollection<string>(patientController.nameSurname());
            AppTypes = new ObservableCollection<AppointmentType>(Enum.GetValues(typeof(AppointmentType)).Cast<AppointmentType>().ToList());
            SelectedReportId = editId;
        }

        public void editReport(object sender, RoutedEventArgs e)
        {
            Report newReport = this.reportController.GetById(SelectedReportId);


            DateTime dt = (DateTime)startTime1.Value;
            AppointmentType at = AppTypeSelected;
            string pc = perceived.Text;
            string cl = conclusion.Text;
            string pat = patientCb.SelectedItem.ToString();
            string[]? strings = pat.Split(" ");
            string patname = strings[0];
            string patsurname = strings[1];
            int patId = patientController.getIdByNameAndSurname(patname, patsurname);

            if (dt < DateTime.Now)
            {
                MessageBox.Show("Wrong date and time! Enter new values for it!");
                return;
            }

            if (dt == null || at == null || pc == "" || cl == "" || patId == null)
            {
                MessageBox.Show("All fields are necessary!");
                return;
            }
            
            newReport.DateAndTime = dt;
            newReport.PerceivedDifficulties = pc;
            newReport.GeneralConclusion = cl;
            newReport.PatientId = patId;
            newReport.DoctorId = 0;
            newReport.Type = at;

            List<Report> reportList = Anamnesis.Reports.ToList();

                foreach(Report report in reportList.Where(x => x.Id == newReport.Id))
            {
                report.DoctorId = 0;
                report.PatientId = patId;
                report.DateAndTime = dt;
                report.PerceivedDifficulties = pc;
                report.GeneralConclusion = cl;
                report.Type = at;
            }
            
                
                reportController.Update(newReport);
                MessageBox.Show("You have successfully edited report! \n Check patient's medical record to see all medical reports!", "Edited medical report");
                Close();
            
        }
    }
}
