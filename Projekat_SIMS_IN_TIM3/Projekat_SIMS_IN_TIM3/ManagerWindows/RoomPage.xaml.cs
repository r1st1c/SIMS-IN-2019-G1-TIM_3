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
    /// Interaction logic for RoomPage.xaml
    /// </summary>
    public partial class RoomPage : Page
    {
        RoomController roomController = new RoomController();

        AppointmentController appointmentController = new AppointmentController();
        public static ObservableCollection<Room> Rooms { get; set; }
        public RoomPage()
        {
            InitializeComponent();
            this.roomController.UpdateDisabledFields();
            this.roomController.DisableAdvancedRenovatingRooms();
            this.roomController.EnableAdvancedRenovatedRooms();
            this.DataContext = this;
            Rooms = new ObservableCollection<Room>(roomController.GetAll());
        }

        private void Add_Room_Click(object sender, RoutedEventArgs e)
        {
            var addRoom = new AddRoom();
            addRoom.ShowDialog();
        }

        private void Edit_Room_Click(object sender, RoutedEventArgs e)
        {
            Room room = (Room)((Button)e.Source).DataContext;
            int id = room.Id;
            var change = new EditRoomWindow(id);
            change.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Room room = (Room)((Button)e.Source).DataContext;
            if (room.Id == 0)
            {
                MessageBox.Show("Default storage room cant be deleted!");
                return;
            }
            Rooms.Remove(room);
            /*if (EquipmentPage.Equipment_All != null)
            {
                foreach (var equipment in EquipmentPage.Equipment_All.Where(x => x.RoomId == room.Id))
                {
                    equipment.RoomName = this.roomController.GetById(0).Name;
                }
            }*/
            this.roomController.DeleteById(room.Id);
        }

        private void Basic_Click(object sender, RoutedEventArgs e)
        {
            Room room = (Room)((Button)e.Source).DataContext;
            var basic = new BasicRenovationWindow(room);
            basic.ShowDialog();
        }

        private void Merge_Click(object sender, RoutedEventArgs e)
        {
            var merge = new MergeRoomsWindow();
            merge.ShowDialog();
        }

        private void Split_Click(object sender, RoutedEventArgs e)
        {
            Room room = (Room)((Button)e.Source).DataContext;
            var split = new SplitRoomWindow(room);
            split.ShowDialog();
        }
    }
}
