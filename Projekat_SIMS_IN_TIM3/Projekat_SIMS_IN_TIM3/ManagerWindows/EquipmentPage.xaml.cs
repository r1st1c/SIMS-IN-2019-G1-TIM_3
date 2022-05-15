using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekat_SIMS_IN_TIM3.ManagerWindows
{
    /// <summary>
    /// Interaction logic for EquipmentPage.xaml
    /// </summary>
    public partial class EquipmentPage : Page
    {
        public static ObservableCollection<Equipment> Equipment_All { get; set; }
        public static EquipmentController equipmentController = new EquipmentController();
        public EquipmentPage()
        {
            InitializeComponent();
            this.DataContext = this;
            equipmentController.MoveFromMoveOrderList();
            Equipment_All = new ObservableCollection<Equipment>(equipmentController.GetAll());
        }
        private void Move_Button(object sender, RoutedEventArgs e)
        {
            Equipment equipment = (Equipment)((Button)e.Source).DataContext;
            var move = new MoveEquipment(equipment);
            move.ShowDialog();
        }
    }
}
