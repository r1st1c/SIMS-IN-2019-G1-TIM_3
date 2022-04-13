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
    /// Interaction logic for UpdateDelete.xaml
    /// </summary>
    public partial class UpdateDelete : Window
    {
        App application;
        List<Patient> patients = new List<Patient>();
        Patient selectedPatient;
        public UpdateDelete()
        {
            InitializeComponent();
            application = Application.Current as App;
            patients = application.patientController.GetAll();
            DataBinding1.ItemsSource = patients;
        }

        private void Update(object sender, RoutedEventArgs e)
        {

            string patientId = selectedPatient.User.Id;
            application.patientController.Delete(patientId);
            var newPatient = new Patient(tb4.Text, tb3.Text, tb5.Text, tb1.Text, tb2.Text, tb6.Text, tb7.Text, tb8.Text, (DateTime)dataofbirth1.SelectedDate);
            newPatient.User.Id = patientId;
            application.patientController.Save(newPatient);
            MessageBox.Show("SuSuccessfully updated user");
        }

        private void Show(object sender, RoutedEventArgs e)
        {
            var usersNew = application.patientController.GetAll();
            DataBinding1.ItemsSource = usersNew;
        }

        private void Select(object sender, RoutedEventArgs e)
        {
            selectedPatient = (Patient)DataBinding1.SelectedItem;
            tb1.Text = selectedPatient.User.Name;
            tb2.Text = selectedPatient.User.Surname;
            tb3.Text = selectedPatient.User.Username;
            tb4.Text = selectedPatient.User.Jmbg;
            tb5.Text = selectedPatient.User.Password;
            tb6.Text = selectedPatient.User.Email;
            tb7.Text = selectedPatient.User.Address;
            tb8.Text = selectedPatient.User.Phone;
            dataofbirth1.SelectedDate = selectedPatient.User.DateOfBirth;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            application.patientController.Delete(selectedPatient.User.Id);
        }
    }
}
