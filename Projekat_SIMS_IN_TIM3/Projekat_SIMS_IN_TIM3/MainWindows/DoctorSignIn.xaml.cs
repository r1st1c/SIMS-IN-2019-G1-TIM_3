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

        public DoctorSignIn()
        {
            InitializeComponent();
          
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
          
            string Username = username.Text.ToString();
            initUsname = Username;
            string Password = password.Text.ToString();

            UserLogin userLogin = new UserLogin(Username, Password);
            Boolean isValid = controller.ValidLogin(userLogin);

                if (!isValid)
            {
                MessageBox.Show("Wrong username or password");
                username.Text = "";
                password.Text = "";
            } else
            {
                MainPage mainPage = new MainPage();
                this.Close();
                mainPage.Show();
            }
  
        }
    }
}
