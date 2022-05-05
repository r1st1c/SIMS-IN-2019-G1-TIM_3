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
        int lastId = 0;
        ReportController reportController = new ReportController();
        PatientController patientController = new PatientController();
        public ObservableCollection<string> Patients { get; set; }


        public AddReport()
        {
            InitializeComponent();
            this.DataContext = this;
            Patients = new ObservableCollection<string>(patientController.nameSurname());
            AppTypes = new ObservableCollection<AppointmentType>(Enum.GetValues(typeof(AppointmentType)).Cast<AppointmentType>().ToList());
        }

        public void createReport(object sender, RoutedEventArgs e)
        {
            // patientCb, startTime1, appTypeCb, perceived, conclusion
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

            if(dt == null || at == null || pc == "" || cl == "" || patId == null )
            {
                MessageBox.Show("All fields are necessary!");
                return;
            } else
            {
                lastId++;

                var newReport = new Report(
                    lastId,
                    patId,
                    0,
                    at,
                    dt,
                    pc,
                    cl
                    );

                reportController.create(newReport);
                MessageBox.Show("You have successfully scheduled new appointment! \n Check calendar to see all scheduled appointments!", "Scheduled appointment", MessageBoxButton.OK);
                this.Close();
            }

        }
    }
}
