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
using System.Windows.Shapes;

namespace Projekat_SIMS_IN_TIM3.SecretaryXAML
{
    /// <summary>
    /// Interaction logic for SecretaryPriority.xaml
    /// </summary>
    public partial class SecretaryPriority : Window
    {
        public App application { get; set; }
        public List<Appointment> appointments { get; set; }

        public Appointment selectedAppointment { get; set; }
        public SecretaryPriority()
        {
            InitializeComponent();
            this.DataContext = this;

            application = Application.Current as App;
        }

        private void btnShwo_Click(object sender, RoutedEventArgs e)
        {
            int doctorId = Convert.ToInt32(txtDoctorId.Text); //uvezati sa wpfom
            string priority = comboBox.Text;

            DateTime wantedStartTIme = (DateTime)startTime1.SelectedDate; //unesen pocetak
            DateTime wantedEndTIme = (DateTime)endTime1.SelectedDate; //unesen kraj

            appointments = application.appointmentController.GetByDoctorsId(doctorId);
            

            List<int> toRemove = new List<int>();
            foreach (Appointment app in appointments)//Ne radi za vreme - ne radi iterator zbog remove
            {
                if (app.StartTime < wantedStartTIme || app.StartTime > wantedEndTIme || app.PatientId != -1)
                {
                    toRemove.Add(app.Id);
                }

            }
            foreach (int id in toRemove)
            {
                for (int i = 0; i < appointments.Count; i++)
                {
                    if (appointments[i].Id == id)
                    {
                        appointments.Remove(appointments[i]);
                    }
                }
            }


            if (appointments.Count > 0)
            {
                DataBinding1.ItemsSource = appointments;
                return;
            }
            else
            {
                if (priority == "Doctor")
                {
                    appointments = application.appointmentController.GetByDoctorsId(doctorId);
                    DataBinding1.ItemsSource = appointments;
                    return;
                }
                else
                {
                    Doctor doctor = application.docController.GetById(doctorId);

                    string specialization = doctor.specializationType;

                    appointments = application.appointmentController.GetAll();
                    foreach (Appointment app in appointments)
                    {
                        Doctor currDoc = application.docController.GetById(app.DoctorId);
                        string currSpec = currDoc.specializationType;
                        if (currSpec != specialization || app.PatientId != -1 || app.StartTime < wantedStartTIme || app.StartTime > wantedEndTIme)
                        {
                            toRemove.Add(app.Id);
                        }
                    }

                    foreach(int id in toRemove)
                    {
                        for(int i = 0; i < appointments.Count; i++)
                        {
                            if(appointments[i].Id == id)
                            {
                                appointments.Remove(appointments[i]);
                            }
                        }
                    }
                    DataBinding1.ItemsSource = appointments;
                    return;
                }
            }

        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            selectedAppointment = (Appointment)DataBinding1.SelectedItem;
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            int appointmentId = selectedAppointment.Id;
            int patientId = 1; //uvezati sa frontom

            application.appointmentController.Delete(appointmentId);
            var newAppointment = new Appointment(appointmentId, selectedAppointment.StartTime, selectedAppointment.DurationInMinutes,
                selectedAppointment.Type, selectedAppointment.DoctorId, 1);


            application.appointmentController.Create(newAppointment);
            MessageBox.Show("Successfully signed up for appointment ");
        }
    }
}
