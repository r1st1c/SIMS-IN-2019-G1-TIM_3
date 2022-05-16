using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
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
    /// Interaction logic for SplitRoomWindow.xaml
    /// </summary>
    public partial class SplitRoomWindow : Window
    {
        public RoomController roomController { get; set; } = new RoomController();
        public Room Room { get; set; }
        public SplitRoomWindow(Room room)
        {
            InitializeComponent();
            this.selected.Content = room.Name;
            this.Room = room;
            this.DataContext = this;
            InitializeComponent();
        }

        private void Confirm_Button(object sender, RoutedEventArgs e)
        {
            RoomType new1;
            RoomType.TryParse(this.roomType1.Text, out new1); 
            RoomType new2;
            RoomType.TryParse(this.roomType1.Text, out new2);
            this.splitGrid.ItemsSource = this.roomController.GetSplitRenovationAvailableTerms(new SplitRenovationQuery(
                DateTime.Parse(this.StartDate.Text),
                DateTime.Parse(this.EndDate.Text),
                this.Room.Id,
                Int32.Parse(this.duration.Text),
                this.roomName1.Text,
                this.roomName2.Text,
                new1,
                new2,
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
            this.roomController.ScheduleSplit(rt);
            DateTime dateStart = DateTime.ParseExact(rt.StartingDate, "dd-MMM-yy", null);
            DateTime dateEnd = DateRange.GetLastMoment(DateTime.ParseExact(rt.EndingDate, "dd-MMM-yy", null));
            foreach (var room in RoomPage.Rooms)
            {
                if (room.Id == rt.RoomToSplitId && DateTime.Now >= dateStart && DateTime.Now <= dateEnd)
                {
                    room.DisabledTxt = "Splitting";
                }

            }
            Close();
        }
    }
}
