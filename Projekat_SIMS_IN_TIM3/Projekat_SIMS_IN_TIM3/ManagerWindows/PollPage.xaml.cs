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
        public List<DoctorGrade> DoctorGrades { get; set; } = new List<DoctorGrade>();

        public SeriesCollection DoctorAverageGrades { get; set; }

        /*public ObservableValue DoctorKnowledge { get; set; }
        public ObservableValue DoctorHelpfulness { get; set; }
        public ObservableValue DoctorPunctuality { get; set; }
        public ObservableValue DoctorPleasantness { get; set; }*/
        public string[] Labels { get; set; } = new[] { "Knowledge", "Helpfulness", "Punctuality", "Pleasantness" };


        public PollPage()
        {
            InitializeComponent();
            //this.DoctorGrades = this.DoctorGradeController.GetAllByDoctorId();
            DoctorGrades.Add(new DoctorGrade(0, 5, 1, 5, 5));
            DoctorGrades.Add(new DoctorGrade(0, 4, 2, 3, 5));
            DoctorGrades.Add(new DoctorGrade(0, 2, 3, 1, 5));
            DoctorGrades.Add(new DoctorGrade(0, 5, 4, 3, 5));
            DoctorGrades.Add(new DoctorGrade(0, 1, 5, 5, 5));
            /*this.DoctorKnowledge = new ObservableValue(0);
            this.DoctorHelpfulness = new ObservableValue(0);
            this.DoctorPunctuality = new ObservableValue(0);
            this.DoctorPleasantness = new ObservableValue(0);*/

            /*DoctorGrade averageDoctorGrade = new DoctorGrade(0, 0, 0, 0, 0);
            int i;
            for (i = 0; i < DoctorGrades.Count; i++)
            {
                if (DoctorGrades[i].doctorId == 0)
                {
                    averageDoctorGrade.knowledgeGrade += DoctorGrades[i].knowledgeGrade;
                    averageDoctorGrade.helpfulnessGrade += DoctorGrades[i].helpfulnessGrade;
                    averageDoctorGrade.punctualityGrade += DoctorGrades[i].punctualityGrade;
                    averageDoctorGrade.pleasantnessGrade += DoctorGrades[i].pleasantnessGrade;
                }
            }
            averageDoctorGrade.knowledgeGrade /= i;
            averageDoctorGrade.helpfulnessGrade /= i;
            averageDoctorGrade.punctualityGrade /= i;
            averageDoctorGrade.pleasantnessGrade /= i;

            Debug.WriteLine(averageDoctorGrade.knowledgeGrade + " " + averageDoctorGrade.helpfulnessGrade);
            */
            DoctorAverageGrades = new SeriesCollection
            {
            };

            this.DataContext = this;
            this.Doctors = new ObservableCollection<Doctor>(this.doctorController.GetAll());
        }

        private void Show_Stats_Click(object sender, RoutedEventArgs e)
        {
            Doctor doctor = (Doctor)((Button)e.Source).DataContext;
            DoctorGrade averageDoctorGrade = new DoctorGrade(doctor.User.Id, 0, 0, 0, 0);
            int i;
            for (i = 0; i < DoctorGrades.Count; i++)
            {
                if (DoctorGrades[i].doctorId == doctor.User.Id)
                {
                    averageDoctorGrade.knowledgeGrade += DoctorGrades[i].knowledgeGrade;
                    averageDoctorGrade.helpfulnessGrade += DoctorGrades[i].helpfulnessGrade;
                    averageDoctorGrade.punctualityGrade += DoctorGrades[i].punctualityGrade;
                    averageDoctorGrade.pleasantnessGrade += DoctorGrades[i].pleasantnessGrade;
                }
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