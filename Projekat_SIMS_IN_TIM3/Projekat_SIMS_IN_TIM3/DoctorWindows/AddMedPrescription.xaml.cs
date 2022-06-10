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
    /// Interaction logic for AddMedPrescription.xaml
    /// </summary>
    public partial class AddMedPrescription : Window
    {

        PatientController patientController = new PatientController();
        DoctorController doctorController = new DoctorController();
        MedicineController medicineController;
        MedicinePrescriptionController prescriptionController;
        
        public ObservableCollection<string> Patients { get; set; }
        private string PatientSelected;

        public ObservableCollection<string> Medicines { get; set; }
        private string MedicineSelected;

        

        List<Patient> patients = new List<Patient>();
        public int DoctorId { get; set; }
        public int PatientsId { get; set; }
        public string PatientNameAndSurname { get; set; }
        public string DoctorNameAndSurname { get; set; }



        public AddMedPrescription(int PatientId, int doctorsId)
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;
            this.doctorController = app.docController;
            this.patientController = app.patientController;
            this.medicineController = app.medicineController;
            this.prescriptionController = app.medPrescriptionController;
            DoctorId = doctorsId;
            PatientsId = PatientId;
            Patients = new ObservableCollection<string>(patientController.nameSurname());

            Medicines = new ObservableCollection<string>(medicineController.GetVerifiedNames());
            PatientNameAndSurname = patientController.GetById(PatientId).User.Name.ToString() + " " + patientController.GetById(PatientId).User.Surname.ToString();
            DoctorNameAndSurname = doctorController.GetById(doctorsId).User.Name.ToString() + " " + doctorController.GetById(doctorsId).User.Surname.ToString();    

        }

        public void Create(object sender, RoutedEventArgs e)
        {
            
            DateTime dt = (DateTime)startTime1.Value;
            int dur = Convert.ToInt32(duration.Text);
            int freq = Convert.ToInt32(fOfUse.Text);
            int docId = DoctorId;
            int patid = PatientsId;

            string medName = medicinesCb.SelectedItem.ToString();
            int medId = medicineController.getIdByName(medName);
            Medicine medicine = medicineController.GetById(medId);
            // check if chosen medicine has some of patient's allergens
            bool isAllergic = prescriptionController.IsAllergicToMedicine(patid, medicine);
            
            if(isAllergic == true)
            {
                MessageBox.Show("Allergic!");
                return;
            }
             
            

            if (dt < DateTime.Now)
            {
                MessageBox.Show("Wrong date and time! Enter new values for it!");
                return;
            }
            if (dur < 0)
            {
                MessageBox.Show("Duration cannot be negative number");
                return;
            }
            

            if(dt == null || dur == null || freq == null ||  patid == null || docId == null || medId == null)
            {
                MessageBox.Show("All fields are necessary!");
                return;
            } else
            {
                int maxId = (prescriptionController.GetAll() == null) ? 0: prescriptionController.GetNextId();

              
                
                
                var newMedPrescription = new MedicinePrescription(
                    maxId,
                    medId,
                    patid,
                    docId,
                    dt,
                    TimeSpan.FromMinutes(dur),
                    true,
                    TimeSpan.FromMinutes(freq));

                prescriptionController.Create(newMedPrescription);

                MessageBox.Show("You have successfully added new prescription! \n Check patient's medical record to see all prescriptions!", "Added new prescriptions");
                
                this.Close();
            }

     

        }

        public void Cancel(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel adding prescription? \n + By canceling it, all previously entered data will disappear!", "Cancel appointment", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Calendar calendar = new Calendar(DoctorId);
                    calendar.Show();
                    break;

                case MessageBoxResult.No:
                    Close();
                    break;
            }

        }
    }
}
