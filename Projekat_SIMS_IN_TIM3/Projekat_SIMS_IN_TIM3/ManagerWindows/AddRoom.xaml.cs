﻿using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for AddRoom.xaml
    /// </summary>
    public partial class AddRoom : Window,INotifyPropertyChanged
    {
        private string name;
        private int floor;
        private string description;
        RoomType RooomType { get; set; }
        private readonly DataView _dataView;
        public event PropertyChangedEventHandler PropertyChanged;
        RoomController roomController = new RoomController();

        public ObservableCollection<RoomType> RoomTypes
        {
            get; set;
        }

        public string Namew
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        

        public string Description
        {
            get => description;
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public int Floor
        {
            get => floor;
            set
            {
                if (floor != value)
                {
                    floor = value;
                    OnPropertyChanged("Floor");
                }
            }
        }


        public AddRoom()
        {
            InitializeComponent();
            this.DataContext = this;
            RoomTypes = new ObservableCollection<RoomType>(Enum.GetValues(typeof(RoomType)).Cast<RoomType>().ToList());

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(name)); }
        }

        private void Confirm_Button(object sender, RoutedEventArgs e)
        {
            var room = CreateRoom();
            if (this.roomController.Create(room)){
                Debug.Write("Room successfully written in csv");
            }
            Close();
        }

        

        private Room CreateRoom()
        {
            var room = new Room(this.roomController.getMaxId(), name, RooomType, floor, description);
            
            return room;
        }
    }
}
