using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
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
    /// Interaction logic for RoomWindow.xaml
    /// </summary>
    public partial class RoomWindow : Window, INotifyPropertyChanged
    {
        RoomController roomController = new RoomController();
        public event PropertyChangedEventHandler PropertyChanged;
        public static ObservableCollection<Room> Rooms { get; set; }
        public RoomWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Rooms = new ObservableCollection<Room>(roomController.GetAll());
            
        }

        private void Add_Room_Click(object sender, RoutedEventArgs e)
        {
            var addRoom = new AddRoom();
            addRoom.Show();
        }

        private void Change_Type_Click(object sender, RoutedEventArgs e)
        {
            Room room = (Room)((Button)e.Source).DataContext;
            int id = room.Id;
            var change = new ChangeRoomType(id);
            change.Show();
        }

        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //Get the sender observable collection
            ObservableCollection<Room> obsSender = sender as ObservableCollection<Room>;
            NotifyCollectionChangedAction action = e.Action;
        }
    }
}
