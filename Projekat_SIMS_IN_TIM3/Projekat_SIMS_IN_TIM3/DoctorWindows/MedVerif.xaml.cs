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
    /// Interaction logic for MedVerif.xaml
    /// </summary>
    public partial class MedVerif : Window
    {
        MedicineController medicineController;
        public static ObservableCollection<Medicine> UnverifiedMedicines { get; set; }

        public int DoctorId { get; set; }
        public MedVerif(int doctorId)
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;
            this.medicineController = app.medicineController;
            DoctorId = doctorId;
            UnverifiedMedicines = new ObservableCollection<Medicine>(medicineController.GetUnverified());
        }

        public void verifyClick(object sender, RoutedEventArgs e)
        {
            Medicine medicine = (Medicine)((Button)e.Source).DataContext;
            int medId = medicine.Id;

            MessageBoxResult result = MessageBox.Show("Are you sure you want to verify "   +  medicine.Name + "?", "Verify medicine", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Medicine updatedMed = new Medicine();
                    updatedMed.Id = medId;
                    updatedMed.Name = medicine.Name;
                    updatedMed.Ingredients = medicine.Ingredients;
                    updatedMed.IsVerified = MedicineStatus.approved;
                    medicineController.Update(updatedMed);
                    MessageBox.Show("You have successfully verified " + medicine.Name);
                    break;

                case MessageBoxResult.No:
                    Close();
                    break;
            }

            this.Close();
        }

        public void rejectClick(object sender, RoutedEventArgs e)
        {
            Medicine medicine = (Medicine)((Button)e.Source).DataContext;
            medicine.IsVerified = MedicineStatus.rejected;
            medicineController.Update(medicine);
            int medId = medicine.Id;
            MessageBoxResult result1 = MessageBox.Show("Are you sure you want to reject verifying " + medicine.Name, "Reject medicine", MessageBoxButton.YesNo);
            switch (result1)
            {
                case MessageBoxResult.Yes:
                    RejectMedForm rejectMed = new RejectMedForm(medId);
                    rejectMed.Show();
                    break;

                case MessageBoxResult.No:
                    Close();
                    break;
            }
            this.Close();
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
    }
}
