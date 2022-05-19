using Projekat_SIMS_IN_TIM3.PatientHCIWindows;
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

namespace Projekat_SIMS_IN_TIM3.MainWindows
{
    /// <summary>
    /// Interaction logic for PatientHCI.xaml
    /// </summary>
    public partial class PatientHCI : Window
    {
        public PatientHCI()
        {
            InitializeComponent();
        }

        private void Appointments_Click(object sender, RoutedEventArgs e)
        {
            var appointmentWindow = new AppointmentsWindow();
            appointmentWindow.Show();
        }
    }
}
