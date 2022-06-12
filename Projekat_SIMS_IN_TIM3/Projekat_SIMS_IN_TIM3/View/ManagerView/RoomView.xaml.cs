using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.ManagerWindows;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.ViewModel.ManagerViewModel;

namespace Projekat_SIMS_IN_TIM3.View.ManagerView
{
    /// <summary>
    /// Interaction logic for RoomPage.xaml
    /// </summary>
    public partial class RoomView : Page
    {
        public RoomView()
        {
            InitializeComponent();
            this.DataContext = new RoomPageViewModel();
        }
    }
}