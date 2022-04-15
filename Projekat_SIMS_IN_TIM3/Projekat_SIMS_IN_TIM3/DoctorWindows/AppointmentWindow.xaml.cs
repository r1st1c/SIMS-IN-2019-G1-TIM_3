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

namespace Projekat_SIMS_IN_TIM3.DoctorWindows
{
    /// <summary>
    /// Interaction logic for AppointmentWindow.xaml
    /// </summary>
    public partial class AppointmentWindow : Window
    {
        public App app { get; set; }
        public List<Appointment> appointments { get; set; } = new List<Appointment>();
        public Appointment chosenApp { get; set; }
        public AppointmentWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            app = Application.Current as App;
            appointments = app.appointmentController.GetAll();

            var appsNew = app.appointmentController.GetAll();

            DataBinding1.ItemsSource = appsNew;
        }

        public void Select(object sender, RoutedEventArgs e)
        {
            chosenApp = (Appointment)DataBinding1.SelectedItem;
        }

        public void Show(object sender, RoutedEventArgs e)
        {
            var appsNew = app.appointmentController.GetAll();
            DataBinding1.ItemsSource = appsNew;
        }

        public void Update(object sender, RoutedEventArgs e)
        {
            int appId = chosenApp.Id;
            app.appointmentController.DeleteAppointment(appId);

            var newAppointment = new Appointment(
                appId,
                (DateTime)startTime1.Value,
                chosenApp.DurationInMinutes,
                chosenApp.Type,
                chosenApp.PatientId);

            app.appointmentController.CreateAppointment(newAppointment);
            MessageBox.Show("You have successfully updated appointment details!");
        }

        public void Delete(object sender, RoutedEventArgs e)
        {
            app.appointmentController.DeleteAppointment(chosenApp.Id);
            MessageBox.Show("You have successfully deleted selected appointment!");

            startTime1.Value = default(DateTime);
        }

       
    }
}
