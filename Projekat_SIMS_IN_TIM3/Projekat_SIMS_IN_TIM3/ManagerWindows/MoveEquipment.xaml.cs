using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Model;
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
    /// Interaction logic for MoveEquipment.xaml
    /// </summary>
    public partial class MoveEquipment : Window
    {
        public EquipmentController equipmentController = new EquipmentController();
        public RoomController roomController = new RoomController();
        ObservableCollection<Equipment> Equipment_All { get; set; }
        public int equipmentId { get; set; }
        public string RoomNameSelected { get; set; }
        public string SelectedEquipment { get; set; }
        public string CurrentRoom { get; set; }
        public List<string> RoomNames { get; set; } = new List<string>();
        public MoveEquipment(Equipment equipment, ObservableCollection<Equipment> equipment_All)
        {
            InitializeComponent();
            this.Equipment_All = equipment_All;
            this.DataContext = this;
            var roomList = this.roomController.GetAll();
            foreach(Room room in roomList)
            {
                RoomNames.Add(room.Name);
            }
            this.equipmentId = equipment.Id;
            this.CurrentRoom = this.roomController.GetById(equipment.RoomId).Name;
            this.SelectedEquipment = equipment.Equipmentname;
        }
        private void Confirm_Button(object sender, RoutedEventArgs e)
        {
            if(PickedDate.Text=="" || PickedDate.Text == null)
            {
                MessageBox.Show("Date must be picked!");
                return;
            }
            if (this.roomController.GetByName(RoomNameSelected).Id == this.equipmentController.GetById(equipmentId).RoomId)
            {
                MessageBox.Show("Equipment already at selected room!");
                return;
            }
            Room targetRoom = this.roomController.GetByName(RoomNameSelected);
            int targetRoomId = targetRoom.Id;
            List<RenovationTerm> renovationTerms = this.roomController.GetRenovationSchedules();
            foreach(RenovationTerm renovationTerm in renovationTerms)
            {
                if(renovationTerm.Id == targetRoomId)
                {
                    DateTime dateStart = DateTime.ParseExact(renovationTerm.startDate, "dd-MMM-yy", null);
                    DateTime dateEnd = DateTime.ParseExact(renovationTerm.endDate, "dd-MMM-yy", null);
                    dateEnd = dateEnd.AddHours(23);
                    dateEnd = dateEnd.AddMinutes(59);
                    dateEnd = dateEnd.AddSeconds(59);
                    if (DateTime.Parse(PickedDate.Text)>= dateStart && DateTime.Parse(PickedDate.Text) <= dateEnd)
                    {
                        MessageBox.Show("Cannot move to target room because it is under renovation at selected time");
                        return;
                    }
                }
            }
            var (toRefresh, toClose) = this.equipmentController.Move(equipmentId, targetRoomId, DateTime.Parse(PickedDate.Text));

            if (toRefresh)
            {
                var toUpdate = this.equipmentController.GetById(equipmentId);
                List<Equipment> list = this.Equipment_All.ToList();
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

        private void Today_Click(object sender, RoutedEventArgs e)
        {
            PickedDate.SelectedDate = DateTime.Today;
        }
    }
}
