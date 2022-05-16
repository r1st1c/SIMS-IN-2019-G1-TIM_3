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

        public static EquipmentController equipmentController = new EquipmentController();
        public static List<Equipment> Equipment_Backup { get; set; }
        public EquipmentPage()
        {
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
            foreach (var equipment in Equipment_Backup.Where(e=>ContainsIgnoreCase(e.Equipmentname,toSearch)))
            {
                queryResult.Add(equipment);
            }
            
            Equipment_All = queryResult;
            Equipment testAdd = new Equipment(5, "test", "test", EquipmentType.static_equipment, 1, 0);
            Equipment_All.Add(testAdd);
            foreach (var equipment in Equipment_All)
            {
                Debug.WriteLine(equipment.Equipmentname);
            }
            //Equipment_All = new ObservableCollection<Equipment>();
            Debug.WriteLine("THIS ENDED");
            //dataGridEquipment.ItemsSource = null;
            //dataGridEquipment.ItemsSource = queryResult;
            //removing elements from list crashes aswell
        }

        bool ContainsIgnoreCase(string str, string substr)
        {
            return str.ToLower().Contains(substr.ToLower());
        }

        private void Filter_Static(object sender, RoutedEventArgs e)
        {
            List<Equipment> queryResult = new List<Equipment>();
            foreach (var equipment in Equipment_Backup)
            {
                if (equipment.Equipmenttype == EquipmentType.static_equipment)
                {
                    queryResult.Add(equipment);
                }
            }
            Equipment_All = new ObservableCollection<Equipment>(queryResult);
            foreach (var equipment in Equipment_All)
            {
                Debug.WriteLine(equipment.Equipmentname);
            }
        }
        private void Filter_Dynamic(object sender, RoutedEventArgs e)
        {
            List<Equipment> queryResult = new List<Equipment>();
            foreach (var equipment in Equipment_Backup)
            {
                if (equipment.Equipmenttype == EquipmentType.dynamic_equipment)
                {
                    queryResult.Add(equipment);
                }
            }
            Equipment_All = new ObservableCollection<Equipment>(queryResult);
            foreach (var equipment in Equipment_All)
            {
                Debug.WriteLine(equipment.Equipmentname);
            }
        }
    }
}
