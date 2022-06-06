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
    /// Interaction logic for EditPrescription.xaml
    /// </summary>
    public partial class EditPrescription : Window
    {
        PatientController patientController = new PatientController();
        MedicinePrescriptionController prescriptionController = new MedicinePrescriptionController();
        public ObservableCollection<string> Patients { get; set; }
        private string PatientSelected;

        MedicineController medicineController = new MedicineController();
        public ObservableCollection<string> Medicines { get; set; }
        private string MedicineSelected;

        int maxId = int.MinValue;
        public int SelectedPresId { get; set; }

        List<Patient> patients = new List<Patient>();
        public EditPrescription(int editId)
        {
            InitializeComponent();
            this.DataContext = this;
            Patients = new ObservableCollection<string>(patientController.nameSurname());
            Medicines = new ObservableCollection<string>(medicineController.GetVerifiedNames());
            SelectedPresId = editId;
            patients = patientController.GetAll();
        }

        public void Create(object sender, RoutedEventArgs e)
        {
            MedicinePrescription newPrescription = this.prescriptionController.GetById(SelectedPresId);
            
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

            if (dt == null || dur == null || freq == null || patId == null || docId == null || medId == null)
            {
                MessageBox.Show("All fields are necessary!");
                return;
            }

            newPrescription.DateAndTime = dt;
            newPrescription.DurationOfUse = TimeSpan.FromDays(dur);
            newPrescription.FrequencyOfUse = TimeSpan.FromHours(freq);
            newPrescription.PatientId = patId;
            newPrescription.DoctorId = 0;
            newPrescription.MedicineId = medId;

                
            List<MedicinePrescription> prescriptionsList = anamnesisPrescriptions.Prescriptions.ToList();
                foreach (MedicinePrescription prescription in prescriptionsList)
            {
                prescription.DurationOfUse = TimeSpan.FromDays(dur);
                prescription.FrequencyOfUse = TimeSpan.FromHours(freq);
                prescription.PatientId = patId;
                prescription.DoctorId = 0;
                prescription.MedicineId = medId;
            }

                prescriptionController.Update(newPrescription);

                MessageBox.Show("You have successfully added new prescription! \n Check patient's medical record to see all prescriptions!", "Added new prescriptions");

                this.Close();
            
        }

        public void Cancel(object sender, RoutedEventArgs e)
        {

        }
    }
}
