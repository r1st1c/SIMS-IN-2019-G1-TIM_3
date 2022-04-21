using Projekat_SIMS_IN_TIM3.Controller;
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
        public RoomController roomController = new RoomController();
        public EquipmentController equipmentController = new EquipmentController();
        public int equipmentId { get; set; }
        public int targetRoomId { get; set; }
        public MoveEquipment(int id)
        {
            InitializeComponent();
            this.DataContext = this;
            this.equipmentId = id;
        }
        private void Confirm_Button(object sender, RoutedEventArgs e)
        {
            if(this.equipmentController.Move(equipmentId, targetRoomId, DateTime.Parse(PickedDate.Text)))
            {
                var toUpdate = this.equipmentController.GetById(equipmentId);
                List<Equipment> list = EquipmentWindow.Equipment_All.ToList();
                foreach (var eq in list.Where(x => x.Id == toUpdate.Id))
                {
                    eq.RoomId = targetRoomId;
                }
            }
            Close();
        }
        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
