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



namespace Projekat_SIMS_IN_TIM3.SecretaryXAML
{
    /// <summary>
    /// Interaction logic for CreateGuest.xaml
    /// </summary>
    public partial class CreateGuest : Window
    {
        App aplication;
        public CreateGuest()
        {
            InitializeComponent();
            aplication = Application.Current as App;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var newGuest = new Guest(name.Text, surname.Text, jmbg.Text, username.Text, password.Text);
            aplication.guestController.Create(newGuest);
            MessageBox.Show("Successfully created guest.");
        }
    }
}
