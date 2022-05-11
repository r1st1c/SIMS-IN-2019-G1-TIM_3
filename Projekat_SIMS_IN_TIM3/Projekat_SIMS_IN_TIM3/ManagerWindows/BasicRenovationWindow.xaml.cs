﻿using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Projekat_SIMS_IN_TIM3.ManagerWindows
{
    /// <summary>
    /// Interaction logic for BasicRenovationWindow.xaml
    /// </summary>
    public partial class BasicRenovationWindow : Window
    {
        public Room Room { get; set; }
        public RoomController roomController= new RoomController();
        public int Duration { set; get; }

        public string Description { set; get; }
        public BasicRenovationWindow(Room room)
        {
            Room = room;
            this.DataContext = this;
            InitializeComponent();
        }

        public void Confirm_Button(object sender, RoutedEventArgs e)
        {
            if(StartDate.Text=="" || EndDate.Text == "")
            {
                MessageBox.Show("You must pick both start and end date!");
                return;
            }
            if(Duration <= 0)
            {
                MessageBox.Show("Invalid duration!");
                return;
            }
            if (Description == "")
            {
                MessageBox.Show("Invalid description!");
                return;
            }
            renovationsGrid.ItemsSource = new ObservableCollection<RenovationTerm>(this.roomController.BasicRenovation(Room.Id, DateTime.Parse(StartDate.Text), DateTime.Parse(EndDate.Text), Duration));
            
        }

        public void Cancel_Button(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void Schedule_Click(object sender, RoutedEventArgs e)
        {
            RenovationTerm rt = (RenovationTerm)((Button)e.Source).DataContext;
            this.roomController.ScheduleRenovation(Room.Id, rt.StartDate, rt.EndDate, Description);
            DateTime dateStart = DateTime.ParseExact(rt.StartDate, "dd-MMM-yy", null);
            DateTime dateEnd = DateTime.ParseExact(rt.EndDate, "dd-MMM-yy", null);
            dateEnd = dateEnd.AddHours(23);
            dateEnd = dateEnd.AddMinutes(59);
            dateEnd = dateEnd.AddSeconds(59);
            foreach (var room in RoomPage.Rooms)
            {
                if (room.Id == Room.Id && DateTime.Now >= dateStart && DateTime.Now <= dateEnd)
                {
                    room.DisabledTxt = "Yes";
                }
            }
            Close();
        }
    }
}
