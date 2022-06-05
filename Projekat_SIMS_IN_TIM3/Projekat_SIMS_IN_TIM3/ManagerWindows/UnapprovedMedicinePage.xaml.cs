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
using Medicine = Projekat_SIMS_IN_TIM3.Model.Medicine;

namespace Projekat_SIMS_IN_TIM3.ManagerWindows
{
    /// <summary>
    /// Interaction logic for MedicinePage.xaml
    /// </summary>
    public partial class UnapprovedMedicinePage : Page
    {
        public ObservableCollection<Medicine> Unapproved { get; set; } = new ObservableCollection<Medicine>();
        public UnapprovedMedicinePage(ObservableCollection<Medicine> unapproved)
        {
            InitializeComponent();
            this.DataContext = this;
            this.Unapproved = unapproved;
        }
    }
}
