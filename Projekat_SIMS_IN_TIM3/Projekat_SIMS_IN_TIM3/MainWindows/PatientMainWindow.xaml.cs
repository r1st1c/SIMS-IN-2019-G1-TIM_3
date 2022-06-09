using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.PatientXAML;
using Projekat_SIMS_IN_TIM3;
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
    /// Interaction logic for PatientMainWindow.xaml
    /// </summary>
    public partial class PatientMainWindow : Window
    {
        string Username;
        public PatientMainWindow(string Username)
        {
            InitializeComponent();
            this.Username = Username;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateAppointment acc = new CreateAppointment();
            acc.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UpdateAndDeleteAppointment ud = new UpdateAndDeleteAppointment(Username);
            ud.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SearchAppointments searchAppointments = new SearchAppointments();
            searchAppointments.Show();
        }

        /*private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PatientXaml.Notifications notifications = new PatientXaml.Notifications(Username);
            notifications.Show();
        }*/

        private void GradeHosp_Click(object sender, RoutedEventArgs e)
        {
            GradeHospital gradeHospital = new GradeHospital();
            gradeHospital.Show();
        }

        private void GradeDoc_Click(object sender, RoutedEventArgs e)
        {
            GradeDoctor gradeDoctor = new GradeDoctor(Username);
            gradeDoctor.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

       
        
    }
}
