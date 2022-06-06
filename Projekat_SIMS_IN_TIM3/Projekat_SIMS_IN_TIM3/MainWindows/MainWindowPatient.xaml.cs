using System;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.PatientHCIWindows;
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
    /// Interaction logic for MainWindowPatient.xaml
    /// </summary>
    public partial class MainWindowPatient : Window
    {
        string Username;
        public App application { get; set; }
        public List<MedicinePrescription> prescriptions { get; set; }
        public Patient patient { get; set; }
        public List<Notification> notifications { get; set; }

        public MainWindowPatient(string Username)
        {
            InitializeComponent();
            this.DataContext = this;
            this.Username = Username;
            this.Notif.Visibility = Visibility.Visible;
            this.Notif.Content = new Profile(Username);
            
        }

        public void Notifications_Click(object sender, RoutedEventArgs e)
        {
            this.Notif.Visibility = Visibility.Visible;
            this.Notif.Content = new Notifications(Username);
        }

        public void Notes_Click(object sender, RoutedEventArgs e)
        {
            this.Notif.Visibility = Visibility.Visible;
            this.Notif.Content = new Notes(Username);
        }
        public void Profile_Click(object sender, RoutedEventArgs e)
        {
            this.Navbar.Visibility = Visibility.Visible;
            this.Notif.Content = new Profile(Username);
            this.Notif.Visibility = Visibility.Visible;
        }

        public void Appointments_Click(object sender, RoutedEventArgs e)
        {
            this.Navbar.Visibility = Visibility.Visible;
            this.Notif.Content = new Appointments(Username);
            this.Notif.Visibility = Visibility.Visible;
        }


        public void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Notif.Content = null;
            this.Navbar.Visibility = Visibility.Collapsed;
            /*this.Log.Visibility = Visibility.Visible;
            this.username.Text = "";
            this.password.Password = "";*/
        }
    }
}
