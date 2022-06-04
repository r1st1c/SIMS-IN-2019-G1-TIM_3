using Projekat_SIMS_IN_TIM3.Controller;
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

namespace Projekat_SIMS_IN_TIM3.DoctorWindows
{
    /// <summary>
    /// Interaction logic for AddAllergen.xaml
    /// </summary>
    public partial class AddAllergen : Window
    {
        DoctorController doctorController = new DoctorController();
        PatientController patientController = new PatientController();

        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public String DoctorNameAndSurname { get; set; }
        public String PatientNameAndSurname {get; set;}
        public AddAllergen(int doctorId, int patientId)
        {
            InitializeComponent();
            this.DataContext = this;
            DoctorId = doctorId;
            PatientId = patientId;

            DoctorNameAndSurname = doctorController.GetById(DoctorId).User.Name.ToString() + " " + doctorController.GetById(DoctorId).User.Surname.ToString();
            PatientNameAndSurname = patientController.GetById(PatientId).User.Name.ToString() + " " + patientController.GetById(PatientId).User.Surname.ToString();

        }

        public void cancelAddingAllergen(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel adding new allergen?\n" + "By canceling it, all previously enterd data will disappear!", "Cancelation of adding allergen", MessageBoxButton.YesNo);
            switch(result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("You have succesfully added " + allergenName.Text + " to the medical record of patient " + PatientNameAndSurname);
                    break;

                case MessageBoxResult.No:
                    return;
                    break;
            }
                

        }

        public void saveAllergen(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel adding new allergen? \n" + "By canceling it, all entered data will disappear!", "Cancelation of adding new allergen", MessageBoxButton.YesNo);
      
                
        }
    }
}
