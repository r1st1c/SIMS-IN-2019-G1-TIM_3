using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.MainWindows;
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
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Projekat_SIMS_IN_TIM3.PatientHCIWindows
{
    /// <summary>
    /// Interaction logic for Anamnesis.xaml
    /// </summary>
    public partial class Anamnesiss : Page
    {

        string Username;
        public App application { get; set; }
        public Patient patient = new Patient();
        public static List<Anamnesis> anamnesis { get; set; } = new List<Anamnesis>();
        public static List<AnamnesisDTO> anamnesisList { get; set; } = new List<AnamnesisDTO>();

        public static ObservableCollection<AnamnesisDTO> anamnesisCollection { get; set; }
        public int patId { get; set; } = 1;

        UIElement parent = App.Current.MainWindow;
        public Anamnesiss(string Username)
        {
            InitializeComponent();

            this.DataContext = this;

            this.Username = Username;
            application = Application.Current as App;

            getPatient(Username);

            anamnesis.Clear();
            anamnesisList.Clear();

            anamnesis = application.anamnesisController.GetByPatientsId(patient.User.Id);

            makeDTOs(anamnesis);

            anamnesisCollection = new ObservableCollection<AnamnesisDTO>(anamnesisList);
        }

        public void makeDTOs(List<Anamnesis> anamnesis)
        {
            foreach (Anamnesis anam in anamnesis)
            {
                anamnesisList.Add(makeDTO(anam));
            }
        }

        public AnamnesisDTO makeDTO(Anamnesis anam)
        {
            Doctor doctor = this.application.docController.GetById(anam.DoctorId);

            string name = doctor.User.Name + " " + doctor.User.Surname;

            return new AnamnesisDTO(anam.Id, name, Convert.ToString(anam.DateAndTime), anam.PerceivedDifficulties, anam.GeneralConclusion);
        }

        public void getPatient(String Username)
        {
            List<Patient> patients = application.patientController.GetAll();

            foreach (Patient pat in patients)
            {
                if (pat.User.Username == Username)
                {
                    patient = pat;
                    patId = pat.User.Id;

                }
            }
        }

        public void View_Anamnesis_Click(object sender, RoutedEventArgs e)
        {
            MainWindowPatient parentWindow = Window.GetWindow(this) as MainWindowPatient;

            AnamnesisDTO anamDTO = (AnamnesisDTO)((Button)e.Source).DataContext;
            int id = anamDTO.Id;
            parentWindow.Notif.Content = new AnamnesisView(id, patId, Username);
        }
    }
}
