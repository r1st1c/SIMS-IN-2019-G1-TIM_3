using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.ManagerWindows;
using Projekat_SIMS_IN_TIM3.Model;

namespace Projekat_SIMS_IN_TIM3.View.ManagerView
{
    /// <summary>
    /// Interaction logic for RoomPage.xaml
    /// </summary>
    public partial class RoomPage : Page
    {
        public RoomController roomController = new RoomController();
        public RenovationTermController renovationTermController = new();

        public AppointmentController appointmentController = new AppointmentController();
        public SplitTermController SplitTermController { get; set; } = new SplitTermController();
        public MergeTermController MergeTermController { get; set; } = new MergeTermController();
        public static ObservableCollection<Room> Rooms { get; set; }

        public RoomPage()
        {
            InitializeComponent();
            this.renovationTermController.DisableRenovatingRooms();
            this.MergeTermController.DisableMergingRooms();
            this.MergeTermController.ExecuteMerging();
            this.SplitTermController.DisableSplittingRooms();
            this.SplitTermController.ExecuteSplitting();
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