using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Controller;
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
    /// Interaction logic for CreateNewAppointmentWindow.xaml
    /// </summary>
    public partial class CreateNewAppointmentWindow : Window
    {
        App app;
        List<Appointment> appointments = new List<Appointment>();
        Appointment chosen;

        int lastId = 0;
        public CreateNewAppointmentWindow()
        {
            InitializeComponent();
            app = Application.Current as App;
            appointments = app.appointmentController.GetAll();
        }

        public void Create(object sender, RoutedEventArgs e)
        {
            lastId++;

            var newApp = new Appointment(
                lastId,
                (DateTime)startTime1.Value,
                Convert.ToInt32(tb1.Text),
                (AppointmentType)Convert.ToInt32(tb2.Text),
                Convert.ToInt32(tb3.Text),
                Convert.ToInt32(tb4.Text));

            app.appointmentController.CreateAppointment(newApp);
            MessageBox.Show("You have successfully created new appointment!");

            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
        }
    }
}
