using Projekat_SIMS_IN_TIM3.DoctorWindows;
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

namespace Projekat_SIMS_IN_TIM3
{
    /// <summary>
    /// Interaction logic for DoctorMainWindow.xaml
    /// </summary>
    public partial class DoctorMainWindow : Window
    {
        public DoctorMainWindow()
        {
            InitializeComponent();
        }

        private void ListApp_Click(object sender, RoutedEventArgs e)
        {
            var appList = new AppointmentWindow();
            appList.Show();
        }

        private void CreateAppt(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
