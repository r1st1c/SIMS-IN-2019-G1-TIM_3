using System.Collections.ObjectModel;
using System.Windows.Controls;
using Projekat_SIMS_IN_TIM3.ViewModel.ManagerViewModel;
using Medicine = Projekat_SIMS_IN_TIM3.Model.Medicine;

namespace Projekat_SIMS_IN_TIM3.View.ManagerView
{
    /// <summary>
    /// Interaction logic for MedicinePage.xaml
    /// </summary>
    public partial class UnapprovedMedicineView : Page
    {
        public UnapprovedMedicineView(ObservableCollection<Medicine> unapproved)
        {
            InitializeComponent();
            this.DataContext = new UnapprovedViewModel(unapproved);
        }
    }
}
