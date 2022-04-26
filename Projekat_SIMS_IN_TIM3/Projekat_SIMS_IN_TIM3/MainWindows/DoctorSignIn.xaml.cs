using Projekat_SIMS_IN_TIM3.DoctorWindows;
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

namespace Projekat_SIMS_IN_TIM3.MainWindows
{
    /// <summary>
    /// Interaction logic for DoctorSignIn.xaml
    /// </summary>
    public partial class DoctorSignIn : Window
    {
        App application;
        List<Doctor> doctors = new List<Doctor>();

        UserController UserController = new UserController();

        public DoctorSignIn()
        {
            InitializeComponent();
            application = Application.Current as App;
            //doctors = application.doctorController.GetAll();
            
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            
            foreach(Doctor doctor in doctors)
            {
               // application.id = doctor.User.Id;
                MainPage mainPage = new MainPage();
                mainPage.Show();
                this.Close();
                return;
            }
            
            MessageBox.Show("Wrong username or password");
            
        }
    }
}
