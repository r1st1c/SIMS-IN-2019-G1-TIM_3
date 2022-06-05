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
    /// Interaction logic for RejectedMedicinePage.xaml
    /// </summary>
    public partial class RejectedMedicinePage : Page
    {
        public ObservableCollection<Medicine> Rejected { get; set; } = new ObservableCollection<Medicine>();
        public MedicineController medicineController = new MedicineController();
        public RejectedMedicinePage()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Rejected = new ObservableCollection<Medicine>(medicineController.GetRejected());
        }
        private void Edit_Medicine_Click(object sender, RoutedEventArgs e)
        {
            Medicine selected = (Medicine)((Button)e.Source).DataContext;
            var change = new EditMedicineWindow(selected,this.Rejected);
            change.ShowDialog();
        }
    }
}
