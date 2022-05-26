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
    /// Interaction logic for GradeHospital.xaml
    /// </summary>
    public partial class GradeHospital : Window
    {
        public App application { get; set; }
        public GradeHospital()
        {
            InitializeComponent();
            this.DataContext = this;

            application = Application.Current as App;
        }


        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            HospitalGradeDTO gradeDTO = makeGradeDTO();

            this.application.hospitalController.addGrade(gradeDTO);

            MessageBox.Show("Succesfully submitted grade!");
        }

        private HospitalGradeDTO makeGradeDTO()
        {
            HospitalGradeDTO gradeDTO = new HospitalGradeDTO(Convert.ToInt32(RoomGrade.Text), Convert.ToInt32(StaffGrade.Text),
                Convert.ToInt32(HospitalityGrade.Text), Convert.ToInt32(LocationGrade.Text), Convert.ToInt32(CleanlinessGrade.Text));

            return gradeDTO;
        }
    }
}
