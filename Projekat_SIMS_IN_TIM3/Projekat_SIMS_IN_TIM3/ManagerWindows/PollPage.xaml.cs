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

        public PollPage()
        {
            InitializeComponent();
            //this.DoctorGrades = this.DoctorGradeController.GetAll();
            DoctorGrades.Add(new DoctorGrade(0,5, 1, 5, 5));
            DoctorGrades.Add(new DoctorGrade(0,4, 2, 3, 5));
            DoctorGrades.Add(new DoctorGrade(0,2, 3, 1, 5));
            DoctorGrades.Add(new DoctorGrade(0,5, 4, 3, 5));
            DoctorGrades.Add(new DoctorGrade(0,1, 5, 5, 5));

            DoctorGrade averageDoctorGrade = new DoctorGrade(0, 0, 0, 0, 0);
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

            DoctorAverageGrades = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Elena",
                    Values = new ChartValues<double>
                    {
                        averageDoctorGrade.knowledgeGrade, averageDoctorGrade.helpfulnessGrade,
                        averageDoctorGrade.punctualityGrade, averageDoctorGrade.pleasantnessGrade
                    }
                }
            };

            this.DataContext = this;
            this.Doctors = new ObservableCollection<Doctor>(this.doctorController.GetAll());
        }
        private void Show_Stats_Click(object sender, RoutedEventArgs e)
        {
            /*Doctor doctor = (Doctor)((Button)e.Source).DataContext;
            Debug.WriteLine(doctor.User.Id + " " + doctor.User.Name + " " + doctor.User.Surname);
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
            averageDoctorGrade.knowledgeGrade /= i;
            averageDoctorGrade.helpfulnessGrade /= i;
            averageDoctorGrade.punctualityGrade /= i;
            averageDoctorGrade.pleasantnessGrade /= i;

            Debug.WriteLine(averageDoctorGrade.knowledgeGrade + " " + averageDoctorGrade.helpfulnessGrade);

            DoctorAverageGrades = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = doctor.User.Name,
                    Values = new ChartValues<double>
                    {
                        averageDoctorGrade.knowledgeGrade, averageDoctorGrade.helpfulnessGrade,
                        averageDoctorGrade.punctualityGrade, averageDoctorGrade.pleasantnessGrade
                    }
                }
            };*/
        }
    }
}
