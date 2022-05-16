using System;
using System.Collections.Generic;
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
using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Model;

namespace Projekat_SIMS_IN_TIM3.ManagerWindows
{
    /// <summary>
    /// Interaction logic for MergeRoomsWindow.xaml
    /// </summary>
    public partial class MergeRoomsWindow : Window
    {
        public List<string> RoomNames { get; set; }
        public RoomController roomController { get; set; } = new RoomController();
        public List<RoomType> RoomTypes { get; set; }
        public MergeRoomsWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            RoomNames = new List<string>();
            RoomTypes = Enum.GetValues(typeof(RoomType)).Cast<RoomType>().ToList();
            foreach (var room in this.roomController.GetAll())
            {
                this.RoomNames.Add(room.Name);
            }
        }

        private void Confirm_Button(object sender, RoutedEventArgs e)
        {
            int firstRoomId = this.roomController.GetByName(firstRoom.Text).Id;
            int secondRoomId = this.roomController.GetByName(secondRoom.Text).Id;
            string description = this.description.Text;
            string name = this.newName.Text;
            RoomType roomtype;
            RoomType.TryParse(this.newType.Text,out roomtype);
            int duration = Int32.Parse(this.duration.Text);
            DateTime startDate = DateTime.Parse(this.StartDate.Text);
            DateTime endDate = DateTime.Parse(this.EndDate.Text);
            Debug.WriteLine(roomtype);
            var query = new MergeRenovationQuery(startDate, endDate, firstRoomId, secondRoomId, duration, description,name,roomtype);
            List<MergeRenovationTerm> available = this.roomController.MergeRenovation(query);
            renovationsGrid.ItemsSource = available;
        }

        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
            MergeRenovationTerm rt = (MergeRenovationTerm)((Button)e.Source).DataContext;
            this.roomController.ScheduleMerge(rt);
            DateTime dateStart = DateTime.ParseExact(rt.StartingDate, "dd-MMM-yy", null);
            DateTime dateEnd = DateRange.GetLastMoment(DateTime.ParseExact(rt.EndingDate, "dd-MMM-yy", null));
            foreach (var room in RoomPage.Rooms)
            {
                if ((room.Id == rt.RoomId1 || room.Id == rt.RoomId2) && DateTime.Now >= dateStart && DateTime.Now <= dateEnd)
                {
                    room.DisabledTxt = "Yes";
                }

            }
            Close();

        }
    }
}
