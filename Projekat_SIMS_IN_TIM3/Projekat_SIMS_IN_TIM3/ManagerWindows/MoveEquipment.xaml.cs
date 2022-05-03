﻿using Projekat_SIMS_IN_TIM3.Controller;
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
    /// Interaction logic for MoveEquipment.xaml
    /// </summary>
    public partial class MoveEquipment : Window
    {
        public EquipmentController equipmentController = new EquipmentController();
        public RoomController roomController = new RoomController();
        public int equipmentId { get; set; }
        public string RoomNameSelected { get; set; }

        public List<string> RoomNames { get; set; } = new List<string>();
        public MoveEquipment(Equipment equipment)
        {
            InitializeComponent();
            this.DataContext = this;
            var roomList = this.roomController.GetAll();
            foreach(Room room in roomList)
            {
                RoomNames.Add(room.Name);
            }
            this.equipmentId = equipment.Id;
        }
        private void Confirm_Button(object sender, RoutedEventArgs e)
        {
            if(PickedDate.Text=="" || PickedDate.Text == null)
            {
                MessageBox.Show("Date must be picked!");
                return;
            }
            int targetRoomId = this.roomController.GetByName(RoomNameSelected).Id;
            var (toRefresh, toClose) = this.equipmentController.Move(equipmentId, targetRoomId, DateTime.Parse(PickedDate.Text));

            if (toRefresh)
            {
                var toUpdate = this.equipmentController.GetById(equipmentId);
                List<Equipment> list = EquipmentWindow.Equipment_All.ToList();
                foreach (var eq in list.Where(x => x.Id == toUpdate.Id))
                {
                    eq.RoomId = targetRoomId;
                    eq.RoomName = this.roomController.GetById(targetRoomId).Name;
                }
            }
            if(toClose) Close();
        }
        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
