using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Projekat_SIMS_IN_TIM3.ManagerWindows
{
    /// <summary>
    /// Interaction logic for IngredientsPage.xaml
    /// </summary>
    public partial class IngredientsPage : Page
    {
        public MedicineIngredientController medicineIngredientController { get; set; } = new MedicineIngredientController();
        public ObservableCollection<MedicineIngredient> Ingredients { get; set; }
        public IngredientsPage()
        {
            InitializeComponent();
            Ingredients = new ObservableCollection<MedicineIngredient>(this.medicineIngredientController.GetAll());
            this.DataContext = this;
        }

        private void Add_Ingredient_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrWhiteSpace(ingredientName.Text))
            {
                MessageBox.Show("Ingredient name can not be null!");
                return;
            }
            Ingredients.Add(this.medicineIngredientController.Create(new MedicineIngredient(ingredientName.Text)));
        }
    }
}
