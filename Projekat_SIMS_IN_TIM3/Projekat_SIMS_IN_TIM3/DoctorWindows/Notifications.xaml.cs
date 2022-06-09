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
    /// Interaction logic for Notifications.xaml
    /// </summary>
    public partial class Notifications : Window
    {
        public int DoctorId { get; set; }
        
        OperationNotificationController notificationController = new OperationNotificationController();
        public Notifications(int doctorsId)
        {
            InitializeComponent();
            this.DataContext = this;
            DoctorId = doctorsId;
            
        }

        private void HomeBtn(object sender, RoutedEventArgs e)
        {
            MainPage mainPage = new MainPage(DoctorId);
            mainPage.Show();
        }

        private void CalendarPageBtn(object sender, RoutedEventArgs e)
        {
            Calendar calendar = new Calendar(DoctorId);
            calendar.Show();
            this.Close();
        }

        private void NotifBtn(object sender, RoutedEventArgs e)
        {
            Notifications notifications = new Notifications(DoctorId);
            notifications.Show();
            this.Close();
        }

        private void MedVerifBtn(object sender, RoutedEventArgs e)
        {
            MedVerif medVerif = new MedVerif(DoctorId);
            medVerif.Show();
            this.Close();
        }

        private void AbsenceReqBtn(object sender, RoutedEventArgs e)
        {
            CreateAbsenceReq createAbsenceReq = new CreateAbsenceReq(DoctorId);
            createAbsenceReq.Show();
            this.Close();
        }

        private void operationNotificationBtn(object sender, RoutedEventArgs e)
        {
            OperationNotifications notification = new OperationNotifications(DoctorId);
            notification.Show();
            this.Close();
        }

        private void absenceRequestNoticificationBtn(object sender, RoutedEventArgs e)
        {
            AbsenceRequestNotifications notifications = new AbsenceRequestNotifications(DoctorId);
            notifications.Show();
            this.Close();
        }

        private void appointmentNotificationBtn(object sender, RoutedEventArgs e)
        {
            AppointmentsNotification notification = new AppointmentsNotification(DoctorId);
            notification.Show();
            this.Close();
        }
    }
}
