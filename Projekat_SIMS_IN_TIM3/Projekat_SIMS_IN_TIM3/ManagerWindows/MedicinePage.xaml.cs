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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekat_SIMS_IN_TIM3.ManagerWindows
{
    /// <summary>
    /// Interaction logic for MedicinePage.xaml
    /// </summary>
    public partial class MedicinePage : Page
    {
        public MedicinePage()
        {
            InitializeComponent();
            MedicineFrame.Content = new UnapprovedMedicinePage();
            this.DataContext = this;
        }

        private void Unapproved_Click(object sender, RoutedEventArgs e)
        {
            MedicineFrame.Content = new UnapprovedMedicinePage();
        }

        private void Rejected_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
