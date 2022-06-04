using Projekat_SIMS_IN_TIM3.Controller;
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
using Xceed.Wpf.Toolkit;
using MessageBox = System.Windows.MessageBox;

namespace Projekat_SIMS_IN_TIM3.PatientXAML
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CreateAppointment : Window
    {
        App application;
        List<Appointment> appointments = new List<Appointment>();
        Appointment selectedAppointment;
        int maxId = 0;
        public CreateAppointment()
        {
            InitializeComponent();
            application = Application.Current as App;
            appointments = application.appointmentController.GetAll();
        }

        public void Create(object sender, RoutedEventArgs e)
        {
            maxId++;

            var newAppointment = new Appointment(maxId, (DateTime)startTime1.Value, Convert.ToInt32(tb1.Text), (AppointmentType)Convert.ToInt32(tb2.Text), Convert.ToInt32(tb3.Text), Convert.ToInt32(tb4.Text)); 
            
            
            application.appointmentController.Create(newAppointment);
            MessageBox.Show("Successfully created appointment.");

            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            

        }
    }
}
