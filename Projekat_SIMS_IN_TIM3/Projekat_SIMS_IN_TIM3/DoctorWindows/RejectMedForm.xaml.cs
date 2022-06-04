using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Model;
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

namespace Projekat_SIMS_IN_TIM3.DoctorWindows
{
    /// <summary>
    /// Interaction logic for RejectMedForm.xaml
    /// </summary>
    public partial class RejectMedForm : Window
    {
        public int MedicineId { get; set; } 
        public string MedicineName { get; set; }

        MedicineController medicineController = new MedicineController();
        RejectedMedicineNotificationController rmnc = new RejectedMedicineNotificationController();

        public RejectMedForm(int medId)
        {
            InitializeComponent();
            this.DataContext = this;
            MedicineId = medId;
            MedicineName = medicineController.GetById(medId).Name;
        }

        private void Send(object sender, RoutedEventArgs e)
        {
            RejectedMedicineNotification notification = new RejectedMedicineNotification();
            notification.Id += 1;
            notification.MedicineId = MedicineId;
            notification.Explanation = explanation.Text;
            notification.MedicineName = MedicineName;

            if(notification.Explanation == " ")
            {
                MessageBox.Show("Explanation box is necessary!");
                return;
            } else
            {
                rmnc.Create(notification);
                MessageBox.Show("You have successfully sent rejecting explanation to a manager!");
                this.Close();
            }

           

        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result1 = MessageBox.Show("Are you sure you want to cancel sending rejecting explanation? " , "Cancel sending rejecting explanation", MessageBoxButton.YesNo);
            switch (result1)
            {
                case MessageBoxResult.Yes:
                    return;
         
                    break;

                case MessageBoxResult.No:
                    Close();
                    break;
            }
            this.Close();
        }

        
    }
}
