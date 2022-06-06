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
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Model;

namespace Projekat_SIMS_IN_TIM3.ManagerWindows
{
    /// <summary>
    /// Interaction logic for PollPage.xaml
    /// </summary>
    public partial class PollPage : Page
    {
        public DoctorController doctorController = new DoctorController();
        public ObservableCollection<Doctor> Doctors { get; set; } = new ObservableCollection<Doctor>();
        public List<HospitalGradeDTO> HospitalGrades { get; set; } = new List<HospitalGradeDTO>();
        public SeriesCollection DoctorAverageGrades { get; set; }

        public HospitalGradeController hospitalGradeController;

        public DoctorGradeController doctorGradeController;

        /*public ObservableValue DoctorKnowledge { get; set; }
        public ObservableValue DoctorHelpfulness { get; set; }
        public ObservableValue DoctorPunctuality { get; set; }
        public ObservableValue DoctorPleasantness { get; set; }*/
        public string[] Labels { get; set; } = new[] { "Knowledge", "Helpfulness", "Punctuality", "Pleasantness" };


        public PollPage()
        {
            var app = Application.Current as App;
            this.hospitalGradeController = app.hospitalGradeController;
            this.doctorGradeController = app.doctorGradeController;
            InitializeComponent();
            DoctorAverageGrades = new SeriesCollection
            {
            };

            this.DataContext = this;
            this.Doctors = new ObservableCollection<Doctor>(this.doctorController.GetAll());
        }

        private void Show_Stats_Click(object sender, RoutedEventArgs e)
        {
            Doctor doctor = (Doctor)((Button)e.Source).DataContext;
            List<DoctorGrade> DoctorGrades = this.doctorGradeController.GetAllByDoctorId(doctor.User.Id);
            DoctorGrade averageDoctorGrade = new DoctorGrade(doctor.User.Id, 0, 0, 0, 0);
            int i;
            for (i = 0; i < DoctorGrades.Count; i++)
            {
                averageDoctorGrade.knowledgeGrade += DoctorGrades[i].knowledgeGrade;
                averageDoctorGrade.helpfulnessGrade += DoctorGrades[i].helpfulnessGrade;
                averageDoctorGrade.punctualityGrade += DoctorGrades[i].punctualityGrade;
                averageDoctorGrade.pleasantnessGrade += DoctorGrades[i].pleasantnessGrade;
            }

            if (i == 0)
            {
                MessageBox.Show("Doctor doesn't have any grades!");
                return;
            }
            averageDoctorGrade.knowledgeGrade = averageDoctorGrade.knowledgeGrade /= i;
            averageDoctorGrade.helpfulnessGrade = averageDoctorGrade.helpfulnessGrade /= i;
            averageDoctorGrade.punctualityGrade = averageDoctorGrade.punctualityGrade /= i;
            averageDoctorGrade.pleasantnessGrade = averageDoctorGrade.pleasantnessGrade /= i;
            var add = new ColumnSeries
            {
                Title = doctor.User.Name,
                Values = new ChartValues<ObservableValue>
                {
                    new ObservableValue(averageDoctorGrade.knowledgeGrade),
                    new ObservableValue(averageDoctorGrade.helpfulnessGrade),
                    new ObservableValue(averageDoctorGrade.punctualityGrade),
                    new ObservableValue(averageDoctorGrade.pleasantnessGrade)
                }
            };
            this.DoctorGradeChart.Series.Add(add);
        }

        private void Clear_Doctor_Chart_Click(object sender, RoutedEventArgs e)
        {
            this.DoctorGradeChart.Series.Clear();
        }
    }
}