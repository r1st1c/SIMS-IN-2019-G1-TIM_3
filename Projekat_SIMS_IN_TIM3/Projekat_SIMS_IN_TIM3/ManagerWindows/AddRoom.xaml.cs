using Projekat_SIMS_IN_TIM3.Controller;
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
using Projekat_SIMS_IN_TIM3.View.ManagerView;
using Projekat_SIMS_IN_TIM3.ViewModel.ManagerViewModel;

namespace Projekat_SIMS_IN_TIM3.ManagerWindows
{
    /// <summary>
    /// Interaction logic for AddRoom.xaml
    /// </summary>
    public partial class AddRoom : Window
    {
        private string name;
        private int floor;
        private string description;
        private RoomType roomTypeSelected;
        RoomController roomController;
        public ObservableCollection<Room> Rooms { get; set; }


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
                }
            }
        }

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

        public AddRoom(ObservableCollection<Room> Rooms)
        {
            var app = Application.Current as App;
            this.roomController = app.roomController;
            InitializeComponent();
            this.DataContext = this;
            RoomTypes = new ObservableCollection<RoomType>(Enum.GetValues(typeof(RoomType)).Cast<RoomType>().ToList());
            this.Rooms = Rooms;

        }

        private void Confirm_Button(object sender, RoutedEventArgs e)
        {
            if (floor < 0)
            {
                MessageBox.Show("Room cannot be negative number!");
                return;
            }
            var room = CreateRoom();
            if (room.Name == null || room.Description==null || room.Name == "" || room.Description == "")
            {
                MessageBox.Show("All fields are necessary");
                return;
            }
            var (succWritten,nameOk) = this.roomController.Create(room);
            if (!nameOk)
            {
                MessageBox.Show("Room name must be unique!");
                return;
            }
            if (succWritten)
            {
                Debug.Write("Room successfully written in csv");
                this.Rooms.Add(room);
                Close();
            }
        }

        private Room CreateRoom()
        {
            return new Room(this.roomController.GetMaxId(), name, roomTypeSelected, (uint) floor, description,"No");
        }

        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
