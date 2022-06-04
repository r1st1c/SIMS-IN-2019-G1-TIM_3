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
    /// Interaction logic for NewOperation.xaml
    /// </summary>
    public partial class NewOperation : Window
    {
       
        public int DoctorId { get; set; }
        public String DoctorsNameAndSurname { get; set; }
        PatientController patientController = new PatientController();
        DoctorController doctorController = new DoctorController();
        private AppointmentType AppTypeSelected;
        
        public ObservableCollection<string> Patients { get; set; }
        public ObservableCollection<string> Doctors { get; set; }
        public ObservableCollection<AppointmentType> AppTypes { get; set; }
        public NewOperation(int doctorId)
        {
            InitializeComponent();
            this.DataContext = this;
            DoctorId = doctorId;
            AppTypes = new ObservableCollection<AppointmentType>(Enum.GetValues(typeof(AppointmentType)).Cast<AppointmentType>().ToList());
            Patients = new ObservableCollection<string>(patientController.nameSurname());
            Doctors = new ObservableCollection<string>(doctorController.nameSurnameSpec());
            DoctorsNameAndSurname = doctorController.GetById(DoctorId).User.Name.ToString() + " " + doctorController.GetById(DoctorId).User.Surname.ToString();
        }


        public void showOperations(object sender, RoutedEventArgs e)
        {
            DateTime dt = (DateTime)startTime1.Value;
            DateTime dt1 = (DateTime)finishTime.Value;
            AppointmentType at = AppTypeSelected;
            int dur = Convert.ToInt32(duration.Text);

            string pat = patientCb.SelectedItem.ToString();
            string[]? strings = pat.Split(" ");
            string patname = strings[0];
            string patsurname = strings[1];
            int patientId = patientController.getIdByNameAndSurname(patname, patsurname);

            AvailableOperations availableOperations = new AvailableOperations(dt, dt1, at, dur, patientId, DoctorId);
            availableOperations.Show();

           
            
        }
    }
}
