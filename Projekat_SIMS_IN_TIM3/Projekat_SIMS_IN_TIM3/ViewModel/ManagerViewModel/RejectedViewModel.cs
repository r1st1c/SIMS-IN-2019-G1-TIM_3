using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Projekat_SIMS_IN_TIM3.Commands;
using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.ManagerWindows;
using Projekat_SIMS_IN_TIM3.Model;

namespace Projekat_SIMS_IN_TIM3.ViewModel.ManagerViewModel
{
    public class RejectedViewModel
    {
        
        public ObservableCollection<Medicine> Rejected { get; set; }
        public MedicineController medicineController;
        public RelayCommand EditCommand { get; set; }
        public RejectedViewModel()
        {
            var app = Application.Current as App;
            this.medicineController = app.medicineController;
            this.Rejected = new ObservableCollection<Medicine>(medicineController.GetRejected());
            this.EditCommand = new RelayCommand(Edit_Medicine);
        }
        public void Edit_Medicine(object parameter)
        {
            Medicine selected = this.medicineController.GetById((int)parameter);
            var change = new EditMedicineWindow(selected, this.Rejected);
            change.ShowDialog();
        }

    }
}
