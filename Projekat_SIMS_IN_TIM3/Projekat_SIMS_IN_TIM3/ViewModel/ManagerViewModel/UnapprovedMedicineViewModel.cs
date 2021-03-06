using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.Model;

namespace Projekat_SIMS_IN_TIM3.ViewModel.ManagerViewModel
{
    public class UnapprovedMedicineViewModel
    {
        public ObservableCollection<Medicine> Unapproved { get; set; } = new ObservableCollection<Medicine>();
        public UnapprovedMedicineViewModel(ObservableCollection<Medicine> unapproved)
        {

            this.Unapproved = unapproved;
        }
    }
    
}
