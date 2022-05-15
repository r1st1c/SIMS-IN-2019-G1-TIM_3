﻿using Projekat_SIMS_IN_TIM3.Controller;
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
    public partial class EquipmentPage : Page
    {
        

        public static ObservableCollection<Equipment> Equipment_All { get; set; }

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
            var move = new MoveEquipment(equipment);
            move.ShowDialog();
        }

        
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string toSearch = Search_Box.Text;
            List<Equipment> queryResult = new List<Equipment>();
            foreach (var equipment in Equipment_Backup)
            {
                if(ContainsIgnoreCase(equipment.Equipmentname,toSearch))
                {
                    queryResult.Add(equipment);
                }
            }
            Equipment_All = new ObservableCollection<Equipment>(queryResult);
            foreach (var equipment in Equipment_All)
            {
                Debug.WriteLine(equipment.Equipmentname);
            }
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