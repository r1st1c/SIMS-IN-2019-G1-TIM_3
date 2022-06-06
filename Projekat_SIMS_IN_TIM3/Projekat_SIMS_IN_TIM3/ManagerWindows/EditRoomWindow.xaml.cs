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
using System.Windows.Shapes;
using Projekat_SIMS_IN_TIM3.View.ManagerView;
using Projekat_SIMS_IN_TIM3.ViewModel.ManagerViewModel;

namespace Projekat_SIMS_IN_TIM3.ManagerWindows
{
    /// <summary>
    /// Interaction logic for EditRoomWindow.xaml
    /// </summary>
    public partial class EditRoomWindow : Window
    {
        public RoomController roomController;
        private RoomType roomTypeSelected;
        private ObservableCollection<Room> Rooms { get; set; }
        public string NewRoomName { get; set; }

        public string NewDescription { get; set; }

        public int SelectedRoomId { get; set; }

        public ObservableCollection<RoomType> RoomTypes { get; set; }

        public RoomType RoomTypeSelected
        {
            get => roomTypeSelected;
            set
            {
                if (roomTypeSelected != value)
                {
                    roomTypeSelected = value;
                }
            }
        }

        public EditRoomWindow(int roomId, ObservableCollection<Room> Rooms)
        {
            var app = Application.Current as App;
            this.roomController = app.roomController;
            InitializeComponent();
            this.DataContext = this;
            RoomTypes = new ObservableCollection<RoomType>(Enum.GetValues(typeof(RoomType)).Cast<RoomType>().ToList());
            Room selectedRoom = this.roomController.GetById(roomId);
            SelectedRoomId = roomId;
            NewRoomName = selectedRoom.Name;
            NewDescription = selectedRoom.Description;
            RoomTypeSelected = selectedRoom.RoomType;
            this.Rooms = Rooms;
        }

        private void Confirm_Button(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(NewRoomName) || String.IsNullOrWhiteSpace(NewDescription))
            {
                MessageBox.Show("All fields are necessary");
                return;
            }

            Room toUpdate = this.roomController.GetById(SelectedRoomId);
            toUpdate.RoomType = RoomTypeSelected;
            toUpdate.Description = NewDescription;
            if (NewRoomName == toUpdate.Name)
            {
                this.roomController.UpdateUsingSameName(toUpdate);
            }
            else
            {
                toUpdate.Name = NewRoomName;
                if (!this.roomController.UpdateUsingNewName(toUpdate))
                {
                    MessageBox.Show("Room names must be unique");
                    return;
                }
            }

            List<Room> roomList = this.Rooms.ToList();
            foreach (var room in roomList.Where(x => x.Id == toUpdate.Id))
            {
                room.Name = NewRoomName;
                room.Description = NewDescription;
                room.RoomType = RoomTypeSelected;
            }

            Close();
        }

        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}