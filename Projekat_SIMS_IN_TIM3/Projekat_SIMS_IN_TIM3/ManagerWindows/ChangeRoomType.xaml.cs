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

namespace Projekat_SIMS_IN_TIM3.ManagerWindows
{
    /// <summary>
    /// Interaction logic for ChangeRoomType.xaml
    /// </summary>
    public partial class ChangeRoomType : Window
    {
        RoomController roomController = new RoomController();
        private RoomType roomTypeSelected;
        public string NewRoomName
        {
            get; set;
        }

        public string NewDescription
        {
            get;set;
        }

        public int SelectedRoomId
        {
            get;set;
        }


        public ObservableCollection<RoomType> RoomTypes
        {
            get; set;
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

        public ChangeRoomType(int roomId)
        {
            InitializeComponent();
            this.DataContext = this;
            RoomTypes = new ObservableCollection<RoomType>(Enum.GetValues(typeof(RoomType)).Cast<RoomType>().ToList());
            SelectedRoomId = roomId;
        }

        private void Confirm_Button(object sender, RoutedEventArgs e)
        {
            if (NewRoomName == null || roomTypeSelected == null || NewDescription == null || NewDescription == "" || NewRoomName == "")
            {
                MessageBox.Show("All fields are necessary");
                return;
            }
            Room toUpdate = this.roomController.GetById(SelectedRoomId);
            toUpdate.RoomType = RoomTypeSelected;
            toUpdate.Name = NewRoomName;
            toUpdate.Description = NewDescription;
            this.roomController.Update(toUpdate);
            List<Room> roomList = RoomWindow.Rooms.ToList();
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
