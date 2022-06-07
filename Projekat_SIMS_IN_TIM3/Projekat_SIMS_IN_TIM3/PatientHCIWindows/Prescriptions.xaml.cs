using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.MainWindows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Projekat_SIMS_IN_TIM3.PatientHCIWindows
{
    /// <summary>
    /// Interaction logic for Prescriptions.xaml
    /// </summary>
    public partial class Prescriptions : Page
    {
        string Username;
        public App application { get; set; }
        public Patient patient = new Patient();
        public static List<PrescriptionDTO> prescriptions { get; set; } = new List<PrescriptionDTO>();
        public static List<MedicinePrescription> prescriptionsList { get; set; } = new List<MedicinePrescription>();

        public int patId { get; set; } = 1;
        UIElement parent = App.Current.MainWindow;
        public Prescriptions(String Username)
        {
            InitializeComponent();

            this.DataContext = this;

            this.Username = Username;
            application = Application.Current as App;

            List<Patient> patients = application.patientController.GetAll();


            

            foreach (Patient pat in patients)
            {
                if (pat.User.Username == Username)
                {
                    patient = pat;
                    patId = pat.User.Id;

                }
            }
            prescriptionsList.Clear();
            prescriptions.Clear();
            prescriptionsList = application.medPrescriptionController.GetAllById(patient.User.Id);

            makeDTOs(prescriptionsList);

        }

        public void makeDTOs(List<MedicinePrescription> prescripts)
        {
            foreach(MedicinePrescription prescription in prescripts)
            {
                prescriptions.Add(makeDTO(prescription));
            }
        }

        public PrescriptionDTO makeDTO(MedicinePrescription prescription)
        {
            string MedicineName;
            Medicine med = application.medicineController.GetById(prescription.MedicineId);
            
            return new PrescriptionDTO(med.Name, Convert.ToString(prescription.DateAndTime), Convert.ToString(prescription.FrequencyOfUse));
        }
    }
}
