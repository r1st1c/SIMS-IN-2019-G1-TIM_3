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
    /// Interaction logic for SplitRoomWindow.xaml
    /// </summary>
    public partial class SplitRoomWindow : Window
    {
        public Room Room { get; set; }
        public SplitRoomWindow(Room room)
        {
            InitializeComponent();
            this.selected.Content = room.Name;
            this.DataContext = this;
            InitializeComponent();
        }

        private void Confirm_Button(object sender, RoutedEventArgs e)
        {

        }
        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Schedule_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
