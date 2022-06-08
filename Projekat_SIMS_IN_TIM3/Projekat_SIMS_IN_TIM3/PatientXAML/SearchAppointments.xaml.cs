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
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Controller;

namespace Projekat_SIMS_IN_TIM3.PatientXAML
{
   
    
    public partial class SearchAppointments : Window
    {
        public App application { get; set; }
        public List<Appointment> appointments { get; set; }

        public Appointment selectedAppointment { get; set; }

        public SearchAppointments()
        {
            InitializeComponent();
            this.DataContext = this;

            application = Application.Current as App;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int doctorId = Convert.ToInt32(txtDoctorId.Text); //uvezati sa wpfom
            string priority = combobox.Text;
            
            DateTime wantedStartTIme = (DateTime)StartTime1.SelectedDate; //unesen pocetak
            DateTime wantedEndTIme = (DateTime)EndTime1.SelectedDate; //unesen kraj

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
                    DataBinding1.ItemsSource = appointments;
                    return;
                }
            }

        }

        private void Select(object sender, RoutedEventArgs e)
        {
            selectedAppointment = (Appointment)DataBinding1.SelectedItem;
        }

        private void SignUp(object sender, RoutedEventArgs e)
        {
            int appointmentId = selectedAppointment.Id;
            int patientId = 1; //uvezati sa frontom

            application.appointmentController.Delete(appointmentId);
            var newAppointment = new Appointment(appointmentId, selectedAppointment.StartTime, selectedAppointment.DurationInMinutes,
                selectedAppointment.Type, selectedAppointment.DoctorId, 1);


            application.appointmentController.Create(newAppointment);
            MessageBox.Show("Successfully signed up for appointment ");
        }


        //dobavi sve slobodne preglede kod lekara u datom intervalu
        // ako je dobavljena lista prazna -> gledamo prioritet
        // dobavi sve slobodne u datom intervalu ako je vreme prioritet
        // dobavi sve slobodne drugih lekara 
    }
}
