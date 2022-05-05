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
        MedicinePrescriptionController prescriptionController = new MedicinePrescriptionController();
        public ObservableCollection<string> Patients { get; set; }
        private string PatientSelected;

        MedicineController medicineController = new MedicineController();
        public ObservableCollection<string> Medicines { get; set; }
        private string MedicineSelected;

        int maxId = 0;

        List<Patient> patients = new List<Patient>();

        

       
        public AddMedPrescription(int PatientId)
        {
            InitializeComponent();
            this.DataContext = this;
            Patients = new ObservableCollection<string>(patientController.nameSurname());
            Medicines = new ObservableCollection<string>(medicineController.getAllVerified());

            patients = patientController.GetAll();
        }

        public void Create(object sender, RoutedEventArgs e)
        {
            maxId++;
            DateTime dt = (DateTime)startTime1.Value;
            int dur = Convert.ToInt32(duration.Text);
            int freq = Convert.ToInt32(fOfUse.Text);

            string pat = patientCb.SelectedItem.ToString();
            string[]? strings = pat.Split(" ");
            string patname = strings[0];
            string patsurname = strings[1];
            int patId = patientController.getIdByNameAndSurname(patname, patsurname);
            int docId = 0;

            string medName = medicinesCb.SelectedItem.ToString();
            int medId = medicineController.getIdByName(medName);

            if(dt < DateTime.Now)
            {
                MessageBox.Show("Wrong date and time! Enter new values for it!");
                return;
            }
            if (dur < 0)
            {
                MessageBox.Show("Duration cannot be negative number");
                return;
            }

            if(dt == null || dur == null || freq == null || patId == null || docId == null || medId == null)
            {
                MessageBox.Show("All fields are necessary!");
                return;
            } else
            {
                
                maxId++;
                var newMedPrescription = new MedicinePrescription(
                    maxId,
                    medId,
                    patId,
                    docId,
                    dt,
                    TimeSpan.FromMinutes(dur),
                    true,
                    TimeSpan.FromMinutes(freq));

                prescriptionController.create(newMedPrescription);

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
                    Calendar calendar = new Calendar();
                    calendar.Show();
                    break;

                case MessageBoxResult.No:
                    Close();
                    break;
            }

        }
    }
}
