using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekat_SIMS_IN_TIM3.ManagerWindows
{
    /// <summary>
    /// Interaction logic for EquipmentPage.xaml
    /// </summary>
    public partial class EquipmentPage : Page,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private ObservableCollection<Equipment> _equipment_All;

        public ObservableCollection<Equipment> Equipment_All
        {
            get
            { return _equipment_All; }
            set
            {
                if (value != _equipment_All)
                {
                    _equipment_All = value;
                    OnPropertyChanged("Equipment_All");
                }
            }
        }
        public List<string> FilterTypesList { get; set; } = new List<string>(){"All","Static","Dynamic"};

        public EquipmentController equipmentController;
        public static List<Equipment> Equipment_Backup { get; set; }
        public EquipmentPage()
        {
            var app = Application.Current as App;
            this.equipmentController = app.equipmentController;
            InitializeComponent();
            this.DataContext = this;
            equipmentController.MoveFromMoveOrderList();
            Equipment_Backup = equipmentController.GetAll();
            Equipment_All = new ObservableCollection<Equipment>(equipmentController.GetAll());
        }
        private void Move_Button(object sender, RoutedEventArgs e)
        {
            Equipment equipment = (Equipment)((Button)e.Source).DataContext;
            var move = new MoveEquipment(equipment, Equipment_All);
            move.ShowDialog();
        }

        
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string toSearch = Search_Box.Text;
            ObservableCollection<Equipment> queryResult = new ObservableCollection<Equipment>();
            foreach (var equipment in Equipment_All.Where(e=>ContainsIgnoreCase(e.Equipmentname,toSearch)))
            {
                queryResult.Add(equipment);
            }
            Equipment_All = queryResult;
        }

        bool ContainsIgnoreCase(string str, string substr)
        {
            return str.ToLower().Contains(substr.ToLower());
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FilterComboBox.SelectedIndex == 0)
            {
                Equipment_All = new ObservableCollection<Equipment>(equipmentController.GetAll());
            }
            if (FilterComboBox.SelectedIndex == 1)
            {
                Equipment_All = new ObservableCollection<Equipment>(equipmentController.GetByType(EquipmentType.static_equipment));
            }
            else if (FilterComboBox.SelectedIndex == 2)
            {
                Equipment_All = new ObservableCollection<Equipment>(equipmentController.GetByType(EquipmentType.dynamic_equipment));
            }

            Search_Box.Text = "";
        }
    }
}
