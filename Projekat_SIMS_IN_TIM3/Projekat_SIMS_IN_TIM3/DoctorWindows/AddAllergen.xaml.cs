using Projekat_SIMS_IN_TIM3.Controller;
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

namespace Projekat_SIMS_IN_TIM3.DoctorWindows
{
    /// <summary>
    /// Interaction logic for AddAllergen.xaml
    /// </summary>
    public partial class AddAllergen : Window
    {
        DoctorController doctorController = new DoctorController();
        PatientController patientController = new PatientController();
        AllergenController allergenController;

        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public String DoctorNameAndSurname { get; set; }
        public String PatientNameAndSurname {get; set;}
        public AddAllergen(int patientId, int doctorId)
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;

            this.doctorController = app.docController;
            this.patientController = app.patientController;
            this.allergenController = app.allergenController;


            DoctorId = doctorId;
            PatientId = patientId;

            DoctorNameAndSurname = doctorController.GetById(Convert.ToInt32(DoctorId)).User.Name.ToString() + " " + doctorController.GetById(Convert.ToInt32(DoctorId)).User.Surname.ToString();
            PatientNameAndSurname = patientController.GetById(PatientId).User.Name.ToString() + " " + patientController.GetById(PatientId).User.Surname.ToString();

        }

        public void cancelAddingAllergen(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel adding new allergen?\n" + "By canceling it, all previously enterd data will disappear!", "Cancelation of adding allergen", MessageBoxButton.YesNo);
            switch(result)
            {
                case MessageBoxResult.Yes:
                    MedicalRecord medicalRecord = new MedicalRecord(PatientId, DoctorId);
                    medicalRecord.Show();
                    break;

                case MessageBoxResult.No:
                    return;
                    break;
            }
                

        }

        public void saveAllergen(object sender, RoutedEventArgs e)
        {
            int allergenId = (allergenController.GetAll() == null) ? 0 : allergenController.GetNextId(); 
            int patientId = Convert.ToInt32(PatientId);
            String detailsData = details.Text;
            String name = allergenName.Text;
            Allergen newAllergen = new Allergen(
                allergenId, patientId,  name, detailsData);
            allergenController.Save(newAllergen);
                
            MessageBox.Show("You have succesfully added " + allergenName.Text + " to the medical record of patient " + PatientNameAndSurname);
            
      
                
        }
    }
}
