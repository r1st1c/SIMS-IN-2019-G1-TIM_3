using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace Projekat_SIMS_IN_TIM3.ManagerWindows
{
    /// <summary>
    /// Interaction logic for AddMedicineWindow.xaml
    /// </summary>
    public partial class AddMedicineWindow : Window
    {
        public ObservableCollection<MedicineIngredient> Ingredients { get; set; } = new ObservableCollection<MedicineIngredient>();
        public ObservableCollection<Medicine> Medicines { get; set; } = new ObservableCollection<Medicine>();
        public ObservableCollection<Medicine> MedicinePageList { get; set; } = new ObservableCollection<Medicine>();
        public MedicineController medicineController { get; set; } = new MedicineController();
        public MedicineIngredientController medicineIngredientController { get; set; } = new MedicineIngredientController();

        public AddMedicineWindow(ObservableCollection<Medicine> medicinePageList)
        {
            InitializeComponent();
            this.DataContext = this;
            Ingredients = new ObservableCollection<MedicineIngredient>(this.medicineIngredientController.GetAll());
            Medicines = new ObservableCollection<Medicine>(this.medicineController.getAll());
            MedicinePageList = medicinePageList;
        }

        private void Confirm_Button(object sender, RoutedEventArgs e)
        {
            if (NoIngredientsAreSelected())
            {
                MessageBox.Show("You must chose at least one ingredient");
                return;
            }

            List<MedicineIngredient> selected = new List<MedicineIngredient>();
            foreach (var ingredientname in this.selIngr.SelectedItems)
            {
                selected.Add(this.medicineIngredientController.GetByName(ingredientname.ToString()));
            }

            Medicine toCreate = new Medicine(
                this.medicineController.GetNextId(), 
                medName.Text, 
                selected, 
                false, 
                this.medicineController.GetByName(repMed.SelectedValue.ToString())
                );

            this.medicineController.createMedicine(toCreate);

            MedicinePageList.Add(toCreate);

            Close();
        }

        private bool NoIngredientsAreSelected()
        {
            return this.selIngr.SelectedIndex<0;
        }

        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
