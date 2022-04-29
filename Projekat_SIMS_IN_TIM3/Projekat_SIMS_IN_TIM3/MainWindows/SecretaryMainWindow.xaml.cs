using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.SecretaryXAML;
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
    /// Interaction logic for SecretaryMainWindow.xaml
    /// </summary>
    public partial class SecretaryMainWindow : Window
    {
        
        public SecretaryMainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewAcc acc = new NewAcc();
            acc.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UpdateDelete ud = new UpdateDelete();
            ud.Show();
        }

        private void create_guest(object sender, RoutedEventArgs e)
        {
            CreateGuest createGuest = new CreateGuest();

            createGuest.Show(); 
        }

        private void crud_appoitnemnt(object sender, RoutedEventArgs e)
        {
            CrudAppoitnemnt appointment = new CrudAppoitnemnt();
            appointment.Show(); 
        }
    }
}