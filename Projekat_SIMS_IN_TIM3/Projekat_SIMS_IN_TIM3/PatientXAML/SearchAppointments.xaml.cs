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
            int doctorId = Convert.ToInt32(txtDocotrId.Text); //uvezati sa wpfom
            string priority = combobox.Text;

            DateTime wantedStartTIme = (DateTime)StartTime1.SelectedDate; //unesen pocetak
            DateTime wantedEndTIme = (DateTime)EndTime1.SelectedDate; //unesen kraj

            appointments = application.appointmentController.GetByDoctorsId(1);

            foreach (Appointment app in appointments)
            {
                if(app.StartTime<wantedStartTIme || app.StartTime>wantedEndTIme || app.PatientId!=-1)
                {
                    appointments.Remove(app);
                }
            }

            if(appointments.Count > 0)
            {
                DataBinding1.ItemsSource = appointments;
                return;
            }
            else
            {
                if (priority == "Doctor")
                {
                    appointments = application.appointmentController.GetByDoctorsId(1);
                    DataBinding1.ItemsSource = appointments;
                    return;
                }
                else
                {
                    Doctor doctor = application.docController.GetById(1);

                    string specialization = doctor.specializationType;

                    appointments = application.appointmentController.GetAll();
                    foreach (Appointment app in appointments)
                    {
                        Doctor currDoc = application.docController.GetById(app.DoctorId);
                        string currSpec = currDoc.specializationType;
                        if (currSpec != specialization || app.PatientId != -1 || app.StartTime < wantedStartTIme || app.StartTime>wantedEndTIme)
                        {
                            appointments.Remove(app);
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

            application.appointmentController.DeleteAppointment(appointmentId);
            var newAppointment = new Appointment(appointmentId, selectedAppointment.StartTime, selectedAppointment.DurationInMinutes,
                selectedAppointment.Type, selectedAppointment.DoctorId, 1);


            application.appointmentController.CreateAppointment(newAppointment);
            MessageBox.Show("Successfully signed up for appointment ");
        }


        //dobavi sve slobodne preglede kod lekara u datom intervalu
        // ako je dobavljena lista prazna -> gledamo prioritet
        // dobavi sve slobodne u datom intervalu ako je vreme prioritet
        // dobavi sve slobodne drugih lekara 
    }
}
