using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
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
using System.Windows.Shapes;
using Projekat_SIMS_IN_TIM3.View.ManagerView;
using Projekat_SIMS_IN_TIM3.ViewModel.ManagerViewModel;

namespace Projekat_SIMS_IN_TIM3.ManagerWindows
{
    /// <summary>
    /// Interaction logic for SplitRoomWindow.xaml
    /// </summary>
    public partial class SplitRoomWindow : Window
    {
        private ObservableCollection<Room> Rooms { get; set; }
        public RoomController roomController;
        public SplitTermController SplitTermController;
        public Room Room { get; set; }
        public List<RoomType> RoomTypes { get; set; }

        public SplitRoomWindow(Room room, ObservableCollection<Room> Rooms)
        {
            InitializeComponent();
            var app = Application.Current as App;
            this.roomController = app.roomController;
            this.SplitTermController = app.splitTermController;
            this.selected.Content = room.Name;
            this.Room = room;
            RoomTypes = Enum.GetValues(typeof(RoomType)).Cast<RoomType>().ToList();
            this.Rooms = Rooms;
            this.DataContext = this;
        }

        private void Confirm_Button(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.StartDate.Text) || String.IsNullOrWhiteSpace(this.EndDate.Text) ||
                String.IsNullOrWhiteSpace(this.duration.Text) || String.IsNullOrWhiteSpace(this.roomName1.Text) ||
                String.IsNullOrWhiteSpace(this.roomName2.Text) ||
                String.IsNullOrWhiteSpace(this.roomType1.Text) || String.IsNullOrWhiteSpace(this.roomType2.Text) ||
                String.IsNullOrWhiteSpace(this.roomDescription1.Text) ||
                String.IsNullOrWhiteSpace(this.roomDescription2.Text))
            {
                MessageBox.Show("All fields are neccessary!!");
                return;
            }
                if (DateTime.Parse(StartDate.Text) > DateTime.Parse(EndDate.Text))
                {
                    MessageBox.Show("End date must be after start!");
                    return;
                }

            this.splitGrid.ItemsSource = this.SplitTermController.GetSplitRenovationAvailableTerms(
                new SplitRenovationTerm(
                    DateTime.Parse(this.StartDate.Text),
                    DateTime.Parse(this.EndDate.Text),
                    this.Room.Id,
                    Int32.Parse(this.duration.Text),
                    this.roomName1.Text,
                    this.roomName2.Text,
                    (RoomType)Enum.Parse(typeof(RoomType), this.roomType1.Text),
                    (RoomType)Enum.Parse(typeof(RoomType), this.roomType2.Text),
                    this.roomDescription1.Text,
                    this.roomDescription2.Text));
        }

        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
            SplitRenovationTerm rt = (SplitRenovationTerm)((Button)e.Source).DataContext;
            this.SplitTermController.ScheduleSplit(rt);
            foreach (var room in this.Rooms)
            {
                if (RoomWasFound(room, rt) && StartDatePassed(rt) && EndDayHasntPassed(rt))
                {
                    room.DisabledTxt = "Splitting";
                }
            }

            Close();
        }

        private static bool EndDayHasntPassed(SplitRenovationTerm rt)
        {
            return DateTime.Now <= DateRange.GetLastMoment(rt.Range.End);
        }

        private static bool StartDatePassed(SplitRenovationTerm rt)
        {
            return DateTime.Now >= rt.Range.Start;
        }

        private static bool RoomWasFound(Room room, SplitRenovationTerm rt)
        {
            return room.Id == rt.RoomToSplitId;
        }
    }
}