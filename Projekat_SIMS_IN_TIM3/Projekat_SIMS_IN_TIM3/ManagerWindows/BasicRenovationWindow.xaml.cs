using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
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

namespace Projekat_SIMS_IN_TIM3.ManagerWindows
{
    /// <summary>
    /// Interaction logic for BasicRenovationWindow.xaml
    /// </summary>
    public partial class BasicRenovationWindow : Window
    {
        public Room Room { get; set; }
        public RoomController roomController = new RoomController();
        public RenovationTermController renovationTermController = new();
        public int Duration { set; get; }

        public string Description { set; get; }

        public BasicRenovationWindow(Room room)
        {
            Room = room;
            this.DataContext = this;
            InitializeComponent();
        }

        public void Confirm_Button(object sender, RoutedEventArgs e)
        {
            if (StartDate.Text == "" || EndDate.Text == "")
            {
                MessageBox.Show("You must pick both starting and ending date!");
                return;
            }

            if (Duration <= 0)
            {
                MessageBox.Show("Duration cannot be value lower than 1!");
                return;
            }

            if (Description == "")
            {
                MessageBox.Show("Description field mustn't be empty!");
                return;
            }

            renovationsGrid.ItemsSource = new ObservableCollection<RenovationTerm>(
                this.renovationTermController.BasicRenovation(new RenovationTerm(Room.Id,
                    DateTime.Parse(StartDate.Text), DateTime.Parse(EndDate.Text), Duration, Description)));
        }

        public void Cancel_Button(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void Schedule_Click(object sender, RoutedEventArgs e)
        {
            RenovationTerm selected = (RenovationTerm)((Button)e.Source).DataContext;
            this.renovationTermController.ScheduleRenovation(new RenovationTerm(selected.RoomId, selected.Range.Start,
 selected.Range.End, Description));
            foreach (var room in RoomPage.Rooms)
            {
                if (room.Id == Room.Id && DateTime.Now >= selected.Range.Start &&
                    DateTime.Now <= DateRange.GetLastMoment(selected.Range.End))
                {
                    room.DisabledTxt = "Basic";
                }
            }

            Close();
        }
    }
}