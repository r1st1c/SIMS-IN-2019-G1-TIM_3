
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

namespace Projekat_SIMS_IN_TIM3.PatientXAML
{
    /// <summary>
    /// Interaction logic for PatientLogin.xaml
    /// </summary>
    public partial class PatientLogin : Window
    {
        public static string initUsname = "";
        UserLoginController controller = new UserLoginController();
        public PatientLogin()
        {
            InitializeComponent();
            password.PasswordChar = '*';
        }


        private void SignIn_Click(object sender, RoutedEventArgs e)
        {

            /*string Username = username.Text.ToString();
            initUsname = Username;
            string Password = password.Password.ToString();

            UserLogin userLogin = new UserLogin(Username, Password);
            Boolean isValid = controller.ValidLogin(userLogin);

            if (!isValid)
            {
                MessageBox.Show("Wrong username or password");
                username.Text = "";
                password.Password = "";
            }
            else
            {
                UpdateAndDeleteAppointment ud = new UpdateAndDeleteAppointment();
                this.Close();
                ud.Show();
            }*/

        }
    }
}
