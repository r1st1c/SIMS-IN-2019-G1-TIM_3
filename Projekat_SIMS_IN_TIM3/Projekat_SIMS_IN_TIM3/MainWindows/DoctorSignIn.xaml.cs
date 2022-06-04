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
        public static string initUsname = "";
        UserLoginController controller = new UserLoginController();
        DoctorController doctorController = new DoctorController();

        public DoctorSignIn()
        {
            InitializeComponent();
            password.PasswordChar = '*';
            username.Focus();

        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            string Username = username.Text.ToString();
            initUsname = Username;
            string Password = password.Password.ToString();

            UserLogin userLogin = new UserLogin(Username, Password);
            var (isValid, type) = controller.ValidLogin(userLogin);

            


            if (!isValid)
            {
                MessageBox.Show("Wrong username or password");
                username.Text = "";
                password.Password = "";
            }
            else
            {
                if (type == 0)
                {
                    ManagerMainWindow managerMainWindow = new ManagerMainWindow();
                    managerMainWindow.Show();
                }
                if (type == 1)
                {
                    int doctorsId =  Convert.ToInt32(doctorController.GetIdByUsername(username.Text.ToString()));
                    MainPage doctorMainWindow = new MainPage(doctorsId);
                    doctorMainWindow.Show();
                }
                if (type == 2)
                {
                    SecretaryMainWindow secretaryMainWindow = new SecretaryMainWindow();
                    secretaryMainWindow.Show();
                }
                if (type == 3)
                {
                    PatientMainWindow patientMainWindow = new PatientMainWindow(Username);
                    patientMainWindow.Show();
                }
                this.Close();
            }




        }

        private void HelloWorld_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
