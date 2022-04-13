using Projekat_SIMS_IN_TIM3.Model;
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
    /// Interaction logic for ChangeRoomType.xaml
    /// </summary>
    public partial class ChangeRoomType : Window
    {
        public ObservableCollection<RoomType> RoomTypes
        {
            get; set;
        }


        public ChangeRoomType()
        {

            InitializeComponent();
            this.DataContext = this;
            RoomTypes = new ObservableCollection<RoomType>(Enum.GetValues(typeof(RoomType)).Cast<RoomType>().ToList());  
        }
    }
}
