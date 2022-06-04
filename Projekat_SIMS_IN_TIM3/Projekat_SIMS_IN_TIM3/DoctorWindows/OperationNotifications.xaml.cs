using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Model;
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

namespace Projekat_SIMS_IN_TIM3.DoctorWindows
{
    /// <summary>
    /// Interaction logic for OperationNotifications.xaml
    /// </summary>
    public partial class OperationNotifications : Window
    {
        public int DoctorId { get; set; }
        public static ObservableCollection<OperationNotification> NotificationList { get; set; }
        OperationNotificationController notificationController = new OperationNotificationController();
        public OperationNotifications(int doctorsId)
        {
            InitializeComponent();
            this.DataContext = this;
            DoctorId = doctorsId;
            NotificationList = new ObservableCollection<OperationNotification>(notificationController.GetAll());
        }
    }
}
