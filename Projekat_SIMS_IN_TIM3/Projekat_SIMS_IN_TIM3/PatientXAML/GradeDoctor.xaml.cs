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
using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Model;

namespace Projekat_SIMS_IN_TIM3.PatientXAML
{
    /// <summary>
    /// Interaction logic for GradeDoctor.xaml
    /// </summary>
    public partial class GradeDoctor : Window
    {
        public App application { get; set; }
        public List<Doctor> doctors { get; set; } = new List<Doctor>();
        public Doctor selectedDoctor { get; set; }

        public int doctorId;
        public int patientId { get; set; } = 1;

        public String Username { get; set; }

        public List<Appointment> appointments = new List<Appointment>();
        public GradeDoctor(String Username)
        {
            InitializeComponent();

            this.DataContext = this;
            this.Username = Username;
            application = Application.Current as App;

            fillDoctorsGrid(Username);

        }
        public void Submit_Click(object sender, RoutedEventArgs e)
        {
            DoctorGradeDTO gradeDTO = makeGradeDTO();

            this.application.docController.addGrade(gradeDTO, doctorId);

        }

        public DoctorGradeDTO makeGradeDTO()
        {
            DoctorGradeDTO gradeDTO = new DoctorGradeDTO(Convert.ToInt32(KnowledgeGrade.Text), Convert.ToInt32(HelpfulnessGrade.Text),
                Convert.ToInt32(PunctualityGrade.Text), Convert.ToInt32(PleasantnessGrade.Text));

            return gradeDTO;
        }

        

        public void fillDoctorsGrid(String Username)
        {
            patientId = getIdByUsername(Username);
            appointments = this.application.appointmentController.GetByPatientsId(patientId);
            doctors = getDoctorsByAppointments(appointments);

            Doctor doc = this.application.docController.GetById(2);
            DoctorsBinding.ItemsSource = doctors;
        }



        public List<Doctor> getDoctorsByAppointments(List<Appointment> appointments)
        {
            List<Doctor> doctors = new List<Doctor>();

            foreach (Appointment app in appointments)
            {
                Doctor doctor = this.application.docController.GetById(app.DoctorId);
                if(!doctorAlreadyExists(doctor, doctors))
                {
                    doctors.Add(doctor);
                }
            }

            return doctors;

        }

        public Boolean doctorAlreadyExists(Doctor doctor, List<Doctor> doctors)
        {
            foreach(Doctor doc in doctors)
            {
                if(doc.User.Id==doctor.User.Id)
                {
                    return true;
                }
            }

            return false;
        }


        public int getIdByUsername(String Username)
        {
            List<Patient> patients = this.application.patientController.GetAll();

            foreach(Patient pat in patients)
            {
                if(pat.User.Username==Username)
                {
                    return pat.User.Id;
                }
            }

            return -1;
        }


        public void Select(object sender, RoutedEventArgs e)
        {
            selectedDoctor = (Doctor)DoctorsBinding.SelectedItem;
            doctorId = selectedDoctor.User.Id;

        }
    }
}
