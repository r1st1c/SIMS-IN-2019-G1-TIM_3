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
        List<User> users = new List<User>();
        User selectedUser;
        public UpdateDelete()
        {
            InitializeComponent();
            application = Application.Current as App;
            users = application.userController.GetAll();
            DataBinding1.ItemsSource = users;
        }

        private void Update(object sender, RoutedEventArgs e)
        {

            int userId = selectedUser.Id;
            application.userController.Delete(userId);
            var newUser = new User(tb4.Text, tb3.Text, tb5.Text, tb1.Text, tb2.Text, tb6.Text, tb7.Text, tb8.Text, (DateTime)dataofbirth1.SelectedDate);
            newUser.Id = userId;
            application.userController.Update(newUser);
            MessageBox.Show("Uspesno edtovan korisnik");
        }

        private void Show(object sender, RoutedEventArgs e)
        {
            var usersNew = application.userController.GetAll();
            DataBinding1.ItemsSource = usersNew;
        }

        private void Select(object sender, RoutedEventArgs e)
        {
            selectedUser = (User)DataBinding1.SelectedItem;
            tb1.Text = selectedUser.Name;
            tb2.Text = selectedUser.Surname;
            tb3.Text = selectedUser.Username;
            tb4.Text = selectedUser.Jmbg;
            tb5.Text = selectedUser.Password;
            tb6.Text = selectedUser.Email;
            tb7.Text = selectedUser.Address;
            tb8.Text = selectedUser.Phone;
            dataofbirth1.SelectedDate = selectedUser.DateOfBirth;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            application.userController.Delete(selectedUser.Id);
        }
    }
}
