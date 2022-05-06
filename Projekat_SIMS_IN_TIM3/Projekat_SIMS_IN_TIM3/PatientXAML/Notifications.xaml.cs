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
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Controller;

namespace Projekat_SIMS_IN_TIM3.PatientXAML
{
    /// <summary>
    /// Interaction logic for Notifications.xaml
    /// </summary>
    public partial class Notifications : Window
    {
        public App application { get; set; }
        public List<MedicinePrescription> prescriptions { get; set; }

        // da li medical record ili list<medicine prescription>
        public Notifications()
        {
            InitializeComponent();

            this.DataContext = this;

            application = Application.Current as App;
            //prescriptions = application.medPrescriptionController.getAll();

            /*DataBinding1.ItemsSource = prescriptions;*/
        }
    }
}
