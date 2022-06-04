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
    /// Interaction logic for anamnesisPrescriptions.xaml
    /// </summary>
    public partial class anamnesisPrescriptions : Window
    {
        MedicinePrescriptionController pc = new MedicinePrescriptionController();
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public static ObservableCollection<MedicinePrescription> Prescriptions { get; set; }
        public anamnesisPrescriptions(int id, int id1)
        {
            InitializeComponent();
            this.DataContext = this;
            PatientId = id;
            DoctorId = id1;
            Prescriptions = new ObservableCollection<MedicinePrescription>(pc.getAllById(PatientId));
        
        }

        public void editPre(object sender, RoutedEventArgs e)
        {
            MedicinePrescription prescription = (MedicinePrescription)((Button)e.Source).DataContext;
            int editId = prescription.Id;
            EditPrescription editPrescription = new EditPrescription(editId);
            editPrescription.Show();

        }

        public void deletePre(object sender, RoutedEventArgs e)
        {
            MedicinePrescription mp = (MedicinePrescription)((Button)e.Source).DataContext;
            Prescriptions.Remove(mp);
            this.pc.delete(mp.Id);
        }

        private void HomeBtn(object sender, RoutedEventArgs e)
        {
            MainPage mainPage = new MainPage(DoctorId);
            mainPage.Show();
            this.Close();
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
