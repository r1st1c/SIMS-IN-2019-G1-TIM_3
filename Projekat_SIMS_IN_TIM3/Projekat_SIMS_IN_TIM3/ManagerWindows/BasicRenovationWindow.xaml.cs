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
    /// Interaction logic for BasicRenovationWindow.xaml
    /// </summary>
    public partial class BasicRenovationWindow : Window
    {
        public Room Room { get; set; }
        public RoomController roomController= new RoomController();
        public int Duration { set; get; }
        public BasicRenovationWindow(Room room)
        {
            Room = room;
            this.DataContext = this;
            InitializeComponent();
        }

        public void Confirm_Button(object sender, RoutedEventArgs e)
        {
            if(StartDate.Text=="" || EndDate.Text == "")
            {
                MessageBox.Show("You must pick both start and end date!");
                return;
            }

            this.roomController.BasicRenovation(Room.Id, DateTime.Parse(StartDate.Text), DateTime.Parse(EndDate.Text),Duration);
        }

        public void Cancel_Button(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
