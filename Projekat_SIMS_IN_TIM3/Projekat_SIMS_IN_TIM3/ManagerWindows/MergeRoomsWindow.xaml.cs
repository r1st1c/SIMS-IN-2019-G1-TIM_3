using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Projekat_SIMS_IN_TIM3.View.ManagerView;
using Projekat_SIMS_IN_TIM3.ViewModel.ManagerViewModel;

namespace Projekat_SIMS_IN_TIM3.ManagerWindows
{
    /// <summary>
    /// Interaction logic for MergeRoomsWindow.xaml
    /// </summary>
    public partial class MergeRoomsWindow : Window
    {
        public List<string> RoomNames { get; set; }
        public RoomController roomController { get; set; } = new RoomController();
        public MergeTermController MergeTermController { get; set; } = new MergeTermController();
        public List<RoomType> RoomTypes { get; set; }
        private ObservableCollection<Room> Rooms { get; set; }

        public MergeRoomsWindow(ObservableCollection<Room> Rooms)
        {
            InitializeComponent();
            this.DataContext = this;
            RoomNames = new List<string>();
            RoomTypes = Enum.GetValues(typeof(RoomType)).Cast<RoomType>().ToList();
            this.Rooms = Rooms;
            foreach (var room in this.roomController.GetAll())
            {
                this.RoomNames.Add(room.Name);
            }
        }

        private void Confirm_Button(object sender, RoutedEventArgs e)
        {
            if (AnyFieldIsEmpty())
            {
                MessageBox.Show("ALL FIELDS ARE NECESSARY!");
                return;
            }
            var query = new MergeRenovationTerm(
                DateTime.Parse(this.StartDate.Text), 
                DateTime.Parse(this.EndDate.Text), 
                this.roomController.GetByName(firstRoom.Text).Id, 
                this.roomController.GetByName(secondRoom.Text).Id, 
                Int32.Parse(this.duration.Text), 
                this.description.Text,
                this.newName.Text,
                (RoomType)Enum.Parse(typeof(RoomType),this.newType.Text)
                );
            renovationsGrid.ItemsSource = this.MergeTermController.GetMergeRenovationAvailableTerms(query);
        }

        private bool AnyFieldIsEmpty()
        {
            return String.IsNullOrEmpty(this.StartDate.Text) || 
                   String.IsNullOrEmpty(this.EndDate.Text) || 
                   String.IsNullOrEmpty(this.firstRoom.Text) || 
                   String.IsNullOrEmpty(this.secondRoom.Text) || 
                   String.IsNullOrEmpty(this.duration.Text) || 
                   String.IsNullOrEmpty(this.description.Text) || 
                   String.IsNullOrEmpty(this.newName.Text) || 
                   String.IsNullOrEmpty(this.newType.Text);
        }

        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
            MergeRenovationTerm rt = (MergeRenovationTerm)((Button)e.Source).DataContext;
            this.MergeTermController.ScheduleMerge(rt);
            foreach (var room in this.Rooms)
            {
                if (RoomWasFound(room, rt) && StartDatePassed(rt) && EndDayHasntPassed(rt))
                {
                    room.DisabledTxt = "Merging";
                }

            }
            Close();

        }

        private static bool StartDatePassed(MergeRenovationTerm rt)
        {
            return DateTime.Now >= rt.Range.Start;
        }

        private static bool EndDayHasntPassed(MergeRenovationTerm rt)
        {
            return DateTime.Now <= DateRange.GetLastMoment(rt.Range.End);
        }

        private static bool RoomWasFound(Room room, MergeRenovationTerm rt)
        {
            return (room.Id == rt.RoomId1 || room.Id == rt.RoomId2);
        }
    }
}
