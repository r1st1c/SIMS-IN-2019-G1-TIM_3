using Projekat_SIMS_IN_TIM3.Model;
using System;
using System.Collections.Generic;
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

namespace Projekat_SIMS_IN_TIM3.SecretaryXAML
{
    /// <summary>
    /// Interaction logic for SecretaryAllergens.xaml
    /// </summary>
    public partial class SecretaryAllergens : Window
    {
        App application;
        List<Allergen> allergens = new List<Allergen>();
        Allergen selectedAllergen;
        int maxId = 0;
        public SecretaryAllergens()
        {
            InitializeComponent();
            application = Application.Current as App;
            allergens = application.allergenController.GetAll();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            maxId++;
            var newAllergen = new Allergen(maxId,Convert.ToInt32(txtPatientId.Text),txtName.Text,txtDetails.Text);
            application.allergenController.Save(newAllergen);

            txtAllergenId.Text = "";
            txtName.Text = "";
            txtDetails.Text = "";
            txtPatientId.Text = "";
            MessageBox.Show("Successfully");


        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            int allergenId = Convert.ToInt32(txtAllergenId.Text);
            application.allergenController.Delete(allergenId);
            var newAllergen = new Allergen(maxId+1, Convert.ToInt32(txtPatientId.Text), txtName.Text, txtDetails.Text);
            application.allergenController.Save(newAllergen);

            txtAllergenId.Text = "";
            txtName.Text = "";
            txtDetails.Text = "";
            txtPatientId.Text = "";
            MessageBox.Show("Successfully");
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            int patientId = Convert.ToInt32(txtPatientId.Text);
            allergens = application.allergenController.GetByPatientsId(patientId);
            List<Allergen> allergenList = new List<Allergen>();
            foreach(Allergen allergen in allergens)
            {
                if(allergen.patietId == patientId)
                {
                    allergenList.Add(allergen);
                }
            }
            
            DataBinding1.ItemsSource = allergenList;
        }
    }
}
