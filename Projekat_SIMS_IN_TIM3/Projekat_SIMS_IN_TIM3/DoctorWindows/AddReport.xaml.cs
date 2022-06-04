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
    /// Interaction logic for AddReport.xaml
    /// </summary>
    public partial class AddReport : Window
    {
        public ObservableCollection<AppointmentType> AppTypes { get; set; }
        private AppointmentType AppTypeSelected;
        int lastId = int.MinValue;
        ReportController reportController = new ReportController();
        PatientController patientController = new PatientController();
        DoctorController doctorController = new DoctorController();
        
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        public string PatientNameAndSurname { get; set; }
        public string DoctorNameAndSurname { get; set; }

        public AddReport(int doctorsId, int patientId)
        {
            InitializeComponent();
            this.DataContext = this;
            DoctorId = doctorsId;
            PatientId = patientId;
            PatientNameAndSurname = patientController.GetById(patientId).User.Name.ToString() + " " + patientController.GetById(patientId).User.Surname.ToString();
            DoctorNameAndSurname = doctorController.GetById(DoctorId).User.Name.ToString() + " " + doctorController.GetById(DoctorId).User.Surname.ToString();
           
            AppTypes = new ObservableCollection<AppointmentType>(Enum.GetValues(typeof(AppointmentType)).Cast<AppointmentType>().ToList());
        }

        public void createReport(object sender, RoutedEventArgs e)
        {
            // patientCb, startTime1, appTypeCb, perceived, conclusion
            DateTime dt = (DateTime)startTime1.Value;
            AppointmentType at = AppTypeSelected;
            string pc = perceived.Text;
            string cl = conclusion.Text;
            int patId = PatientId;
            
          
            if (dt < DateTime.Now)
            {
                MessageBox.Show("Wrong date and time! Enter new values for it!");
                return;
            }

            if(dt == null || at == null || pc == "" || cl == "" || patId == null )
            {
                MessageBox.Show("All fields are necessary!");
                return;
            } else
            {
                lastId = reportController.getNextId();
                lastId++;
                var newReport = new Report(
                    lastId,
                    patId,
                    Convert.ToInt32(DoctorId),
                    at,
                    dt,
                    pc,
                    cl
                    );

                reportController.create(newReport);
                MessageBox.Show("You have successfully added new report! \n Check patient's medical record to see all medical reports!", "Added medical report");
                this.Close();
            }

        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel adding report for patient " + PatientNameAndSurname + "?", "Cancelation of adding new report", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MedicalRecord medicalRecord = new MedicalRecord(PatientId, DoctorId);
                    medicalRecord.Show();
                    return;
                    break;

                case MessageBoxResult.No:
                    return;
                    break;
            }
        }
    }
}
