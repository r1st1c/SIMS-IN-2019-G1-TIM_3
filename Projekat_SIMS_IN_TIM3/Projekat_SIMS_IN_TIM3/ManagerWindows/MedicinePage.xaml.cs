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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekat_SIMS_IN_TIM3.ManagerWindows
{
    /// <summary>
    /// Interaction logic for MedicinePage.xaml
    /// </summary>
    public partial class MedicinePage : Page
    {
        public ObservableCollection<Medicine> all { get; set; } = new ObservableCollection<Medicine>();
        public MedicineController medicineController = new MedicineController();
        public MedicinePage()
        {
            /*List<MedicineIngredient> brufenIngredients = new List<MedicineIngredient>();
            brufenIngredients.Add(new MedicineIngredient("Ibuprofen"));
            Medicine toAdd = new Medicine(0, "Brufen", brufenIngredients,true,null);
            this.medicineController.Create(toAdd);*/
            InitializeComponent();
            this.DataContext = this;
            var list = this.medicineController.GetAll();
            all = new ObservableCollection<Medicine>(list);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var add = new AddMedicineWindow(all);
            add.ShowDialog();
        }
    }
}
