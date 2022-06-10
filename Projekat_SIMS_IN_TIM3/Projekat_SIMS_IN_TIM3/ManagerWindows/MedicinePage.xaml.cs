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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Model;

namespace Projekat_SIMS_IN_TIM3.ManagerWindows
{
    /// <summary>
    /// Interaction logic for MedicinePage.xaml
    /// </summary>
    public partial class MedicinePage : Page
    {
        public ObservableCollection<Medicine> unapproved { get; set; } = new ObservableCollection<Medicine>();
        public MedicineController medicineController;
        public MedicinePage()
        {
            InitializeComponent();
            this.unapproved = new ObservableCollection<Medicine>(this.medicineController.GetUnverified());
            MedicineFrame.Content = new UnapprovedMedicinePage(unapproved);
            UnapprovedButton.Background = Brushes.Aqua;
            RejectedButton.Background = (Brush)ManagerMainWindow.brushConverter.ConvertFrom("#FFDDDDDD");
            this.AddMedicine.Visibility = Visibility.Visible;
            this.DataContext = this;
        }

        private void Unapproved_Click(object sender, RoutedEventArgs e)
        {
            this.unapproved = new ObservableCollection<Medicine>(this.medicineController.GetUnverified());
            this.AddMedicine.Visibility = Visibility.Visible;
            MedicineFrame.Content = new UnapprovedMedicinePage(unapproved);
            UnapprovedButton.Background = Brushes.Aqua;
            RejectedButton.Background = (Brush)ManagerMainWindow.brushConverter.ConvertFrom("#FFDDDDDD");
        }

        private void Rejected_Click(object sender, RoutedEventArgs e)
        {
            this.AddMedicine.Visibility = Visibility.Hidden;
            MedicineFrame.Content = new RejectedMedicinePage();
            UnapprovedButton.Background = (Brush)ManagerMainWindow.brushConverter.ConvertFrom("#FFDDDDDD");
            RejectedButton.Background = Brushes.Aqua;

        }

        private void Add_Med_Click(object sender, RoutedEventArgs e)
        {
            var add = new AddMedicineWindow(unapproved);
            add.ShowDialog();
        }
    }
}
