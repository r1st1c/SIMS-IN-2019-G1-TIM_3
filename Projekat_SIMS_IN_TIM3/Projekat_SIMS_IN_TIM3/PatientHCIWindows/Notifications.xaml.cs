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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Projekat_SIMS_IN_TIM3
{
    /// <summary>
    /// Interaction logic for Notifications.xaml
    /// </summary>
    public partial class Notifications : Page
    {
        string Username;
        public App application { get; set; }
        public List<MedicinePrescription> prescriptions { get; set; }
        public Patient patient { get; set; }
        public List<Notification> notifications { get; set; }

        public Notifications(String Username)
        {
            InitializeComponent();

            this.DataContext = this;


            application = Application.Current as App;

            getPatient(Username);

            //prescriptions = application.medPrescriptionController.GetAll();
            
            /*int currTime = DateTime.Now.Hour;

            int id = 0;
            notifications = new List<Notification>();

            foreach (MedicinePrescription prescription in prescriptions)
            {
                if (prescription.PatientId == patient.User.Id)
                {
                    //logika za obavestenja

                    int startHour = 8;
                    TimeSpan frequency = prescription.FrequencyOfUse;

                    int hr = frequency.Days;


                    while (startHour < 24 && hr != 0)
                    {
                        if (startHour - currTime <= 2 && startHour - currTime > 0)
                        {
                            Medicine med = application.medicineController.GetById(prescription.MedicineId);
                            string medName = med.Name;
                            TimeSpan ts = new TimeSpan(startHour, 0, 0);
                            Notification notif = new Notification(id++, medName, ts);
                            notifications.Add(notif);


                        }
                        startHour += hr;

                    }
                }
            }
            
            DataBinding1.ItemsSource = notifications;*/

        }


        public void getPatient(String Username)
        {
            List<Patient> patients = application.patientController.GetAll();

            foreach (Patient pat in patients)
            {
                if (pat.User.Username == Username)
                {
                    patient = pat;
                    

                }
            }
        }




    }
}
