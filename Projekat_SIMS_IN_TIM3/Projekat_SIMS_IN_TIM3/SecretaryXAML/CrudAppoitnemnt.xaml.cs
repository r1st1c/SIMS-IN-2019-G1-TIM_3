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
    /// Interaction logic for CrudAppoitnemnt.xaml
    /// </summary>
    public partial class CrudAppoitnemnt : Window
    {
        App application;
        List<Appointment> appointments = new List<Appointment>();
        Appointment selectedAppointment;
        int maxId = 0;
        public CrudAppoitnemnt()
        {
            InitializeComponent();
            
            application = Application.Current as App;
            appointments = application.appointmentController.GetAll();

            DataBinding1.ItemsSource = appointments;
            var appsNew = application.appointmentController.GetAll();
            DataBinding1.ItemsSource = appsNew;


            


        }


        void Show()
        {
            var appsNew = application.appointmentController.GetAll();
            DataBinding1.ItemsSource = appsNew;
        }
        private void btnIsert_Click(object sender, RoutedEventArgs e)
        {
            maxId++;

            var newAppointment = new Appointment(maxId, (DateTime)startTime1.Value, Convert.ToInt32(txtDuration.Text), (AppointmentType)Convert.ToInt32(txtType.Text), Convert.ToInt32(txtPatientnId.Text), Convert.ToInt32(txtDoctorId.Text));


            application.appointmentController.Create(newAppointment);
            MessageBox.Show("Successfully created appointment.");

            txtDoctorId.Text = "";
            txtDuration.Text = "";
            txtPatientnId.Text = "";
            txtType.Text = "";

            Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            
           
            application.appointmentController.Delete(selectedAppointment.Id);
            MessageBox.Show("Successfully deleted appointment");
            startTime1.Value = default(DateTime);

            Show();
        }
      

        private void btnUpadte_Click(object sender, RoutedEventArgs e)
        {


            int appointmentId = selectedAppointment.Id;
            application.appointmentController.Delete(appointmentId);
            var newAppointment = new Appointment(appointmentId, (DateTime)startTime1.Value, selectedAppointment.DurationInMinutes,
                selectedAppointment.Type, selectedAppointment.DoctorId, selectedAppointment.PatientId);


            application.appointmentController.Create(newAppointment);
            MessageBox.Show("You have successfully updated appointment details!");

            Show();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            selectedAppointment = (Appointment)DataBinding1.SelectedItem;
            txtDuration.Text = Convert.ToString(selectedAppointment.DurationInMinutes);
            txtType.Text = Convert.ToString(selectedAppointment.Type);
            txtPatientnId.Text = Convert.ToString(selectedAppointment.PatientId);
            txtDoctorId.Text = Convert.ToString(selectedAppointment.DoctorId);
            startTime1.Value = selectedAppointment.StartTime;


            txtDoctorId.IsEnabled = false;
            txtDuration.IsEnabled = false;
            txtPatientnId.IsEnabled = false;
            txtType.IsEnabled = false;
        }
    }
}
