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
using Projekat_SIMS_IN_TIM3.Controller;

namespace Projekat_SIMS_IN_TIM3.ManagerWindows
{
    /// <summary>
    /// Interaction logic for EditMedicineWindow.xaml
    /// </summary>
    public partial class EditMedicineWindow : Window
    {
        private Medicine selected { get; set; }

        public ObservableCollection<MedicineIngredient> Ingredients { get; set; } =
            new ObservableCollection<MedicineIngredient>();

        public ObservableCollection<Medicine> MedicineList { get; set; } = new ObservableCollection<Medicine>();
        public MedicineController MedicineController { get; set; } = new MedicineController();

        public MedicineIngredientController MedicineIngredientController { get; set; } =
            new MedicineIngredientController();

        public EditMedicineWindow(Medicine selected)
        {
            InitializeComponent();
            this.DataContext = this;
            this.selected = selected;
            this.MedicineList = new ObservableCollection<Medicine>(this.MedicineController.GetAll());
            this.Ingredients = new ObservableCollection<MedicineIngredient>(this.MedicineIngredientController.GetAll());

            this.medName.Text = selected.Name;

            //Medicine can only have one replacement
            int index = -1;
            for (int i = 0; i < MedicineList.Count; i++)
            {
                if (MedicineList[i].Name.Equals(selected.Replacement))
                {
                    index = i;
                    break;
                }
            }
            this.repMed.SelectedIndex = index;

            for (index = 0; index < Ingredients.Count; index++)
            {
                foreach (var ingredient in selected.Ingredients)
                {
                    if (ingredient.Name.Equals(Ingredients[index].Name))
                    {
                        selIngr.SelectedIndex = index;
                    }
                }
            }
        }

        private void Confirm_Button(object sender, RoutedEventArgs e)
        {
            this.selected.Name = this.medName.Text;
            List<MedicineIngredient> selectedIngredients = new List<MedicineIngredient>();
            foreach (var ingredientname in this.selIngr.SelectedItems)
            {
                selectedIngredients.Add(this.MedicineIngredientController.GetByName(ingredientname.ToString()));
            }

            this.selected.Ingredients = selectedIngredients;
            Medicine replacement = new Medicine();
            if (ReplacementIsSelected())
            {
                replacement = this.MedicineController.GetByName(repMed.SelectedValue.ToString());
            }

            this.selected.Replacement = replacement.Name;
            this.selected.IsVerified = MedicineStatus.unapproved;
            this.selected.ReasonOfRejection = "";
            this.MedicineController.Update(selected);
            Close();
        }

        private bool ReplacementIsSelected()
        {
            return repMed.SelectedIndex != -1;
        }

        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}