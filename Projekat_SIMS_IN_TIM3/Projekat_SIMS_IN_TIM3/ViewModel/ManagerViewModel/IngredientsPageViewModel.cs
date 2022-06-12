using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Projekat_SIMS_IN_TIM3.Commands;
using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Model;

namespace Projekat_SIMS_IN_TIM3.ViewModel.ManagerViewModel
{
    public class IngredientsPageViewModel
    {
        public MedicineIngredientController medicineIngredientController;
        public ObservableCollection<MedicineIngredient> Ingredients { get; set; }
        public string IngredientName { get; set; }
        public RelayCommand AddCommand { get; set; }

        public IngredientsPageViewModel()
        {
            var app = Application.Current as App;
            this.medicineIngredientController = app.medicineIngredientController;
            Ingredients = new ObservableCollection<MedicineIngredient>(this.medicineIngredientController.GetAll());
            this.AddCommand = new(Add_Ingredient);
        }

        public void Add_Ingredient(object parameter)
        {
            if (String.IsNullOrWhiteSpace(IngredientName))
            {
                MessageBox.Show("Ingredient name can not be null!");
                return;
            }
            Ingredients.Add(this.medicineIngredientController.Create(new MedicineIngredient(IngredientName)));
        }
    }
}
