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

namespace Projekat_SIMS_IN_TIM3.ManagerWindows
{
    /// <summary>
    /// Interaction logic for BasicRenovationWindow.xaml
    /// </summary>
    public partial class BasicRenovationWindow : Window
    {

        public int Duration { set; get; }
        public BasicRenovationWindow(Room room)
        {
            InitializeComponent();
        }

        public void Confirm_Button(object sender, RoutedEventArgs e)
        {

        }

        public void Cancel_Button(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
