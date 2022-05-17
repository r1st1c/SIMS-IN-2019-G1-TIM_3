using Projekat_SIMS_IN_TIM3.ManagerWindows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for ManagerMainWindow.xaml
    /// </summary>
    public partial class ManagerMainWindow : Window
    {
        public static BrushConverter brushConverter { get; set; }
        public ManagerMainWindow()
        {
            brushConverter = new BrushConverter();
            InitializeComponent();
        }

        private void Room_Click(object sender, RoutedEventArgs e)
        {
            roomsBtn.Background = Brushes.Aqua;
            equipmentBtn.Background = (Brush)brushConverter.ConvertFrom("#FFDDDDDD");
            pollsBtn.Background = (Brush)brushConverter.ConvertFrom("#FFDDDDDD");
            drugsBtn.Background = (Brush)brushConverter.ConvertFrom("#FFDDDDDD");
            ingredientsBtn.Background = (Brush)brushConverter.ConvertFrom("#FFDDDDDD");
            MainFrame.Content = new RoomPage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Equipment_Click(object sender, RoutedEventArgs e)
        {
            roomsBtn.Background = (Brush)brushConverter.ConvertFrom("#FFDDDDDD");
            equipmentBtn.Background = Brushes.Aqua;
            pollsBtn.Background = (Brush)brushConverter.ConvertFrom("#FFDDDDDD");
            ingredientsBtn.Background = (Brush)brushConverter.ConvertFrom("#FFDDDDDD");
            drugsBtn.Background = (Brush)brushConverter.ConvertFrom("#FFDDDDDD");
            MainFrame.Content = new EquipmentPage();
        }

        private void Drugs_Click(object sender, RoutedEventArgs e)
        {
            roomsBtn.Background = (Brush)brushConverter.ConvertFrom("#FFDDDDDD");
            equipmentBtn.Background = (Brush)brushConverter.ConvertFrom("#FFDDDDDD");
            ingredientsBtn.Background = (Brush)brushConverter.ConvertFrom("#FFDDDDDD");
            pollsBtn.Background = (Brush)brushConverter.ConvertFrom("#FFDDDDDD");
            drugsBtn.Background = Brushes.Aqua;
            MainFrame.Content = new DrugsPage();
        }
        private void Ingredients_Click(object sender, RoutedEventArgs e)
        {
            roomsBtn.Background = (Brush)brushConverter.ConvertFrom("#FFDDDDDD");
            equipmentBtn.Background = (Brush)brushConverter.ConvertFrom("#FFDDDDDD");
            pollsBtn.Background = (Brush)brushConverter.ConvertFrom("#FFDDDDDD");
            ingredientsBtn.Background = Brushes.Aqua;
            drugsBtn.Background = (Brush)brushConverter.ConvertFrom("#FFDDDDDD");
            MainFrame.Content = new IngredientsPage();
        }
    }
}
