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
    /// Interaction logic for AvailableOperations.xaml
    /// </summary>
    public partial class AvailableOperations : Window
    {
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public AppointmentType AppType { get; set; }
        public int Duration { get; set; }

        OperationNotificationController operationNotificationController { get; set; } = new OperationNotificationController();
        OperationController operationController = new OperationController();
        public static ObservableCollection<Operation> Operations { get; set; }
        public AvailableOperations(DateTime dt, DateTime dt1, AppointmentType at,int dur, int patientId, int DoctorId)
        {
            InitializeComponent();
            this.DataContext = this;
            StartTime = dt;
            FinishTime = dt1;
            PatientId = patientId;
            DoctorId = DoctorId;
            Duration = dur;
            AppType = at;
            Operations = new ObservableCollection<Operation>(operationController.GetAll());
        }

        public void chooseAppointment(object sender, RoutedEventArgs e)
        {
            Operation operation = (Operation)((Button)e.Source).DataContext;


            operation.RoomNumber = 0;
            operation.Type = AppType;
            operation.PatientId = Convert.ToInt32(PatientId);
            operation.DoctorId = Convert.ToInt32(DoctorId);

            Operations.Remove(operation);

            this.operationController.Create(operation);

            OperationNotification notification = new OperationNotification(
                0, StartTime, PatientId, AppType, Duration);
            operationNotificationController.Create(notification);

            MessageBox.Show("You have successfully created new operation term!", "Creation of new operation term");

        }
    }
}
