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

namespace Projekat_SIMS_IN_TIM3.PatientHCIWindows
{
    /// <summary>
    /// Interaction logic for AppointmentsView.xaml
    /// </summary>
    public partial class AnamnesisView : Page
    {
        public App application { get; set; }

        public List<Anamnesis> anamnesisList = new List<Anamnesis>();
        public String Username { get; set; }
        public Anamnesis anamnesis { get; set; }

        public AnamnesisDTO anamnesisDTO { get; set; }
        public AnamnesisView(int Id, int patientId, String Username)
        {
            InitializeComponent();
            this.DataContext = this;
            this.Username = Username;

            application = Application.Current as App;

            anamnesisList = this.application.anamnesisController.GetByPatientsId(patientId);

            getAnamnesis(Id);

            anamnesisDTO = makeDTO(anamnesis);

            fillAnamnesisInfo();

        }

        public void getAnamnesis(int Id)
        {
            foreach (Anamnesis anam in anamnesisList)
            {
                if (anam.Id == Id)
                {
                    anamnesis=anam;
                    break;
                }
            }
        }

        public AnamnesisDTO makeDTO(Anamnesis anam)
        {
            Doctor doctor = this.application.docController.GetById(anam.DoctorId);

            string name = doctor.User.Name + " " + doctor.User.Surname;

            return new AnamnesisDTO(anam.Id, name, Convert.ToString(anam.DateAndTime), anam.PerceivedDifficulties, anam.GeneralConclusion);
        }

        public void fillAnamnesisInfo()
        {
            this.Doctor.Text = anamnesisDTO.DoctorName;
            this.Time.Text = anamnesisDTO.DateAndTime.ToString();
            this.Anamnesis.Text = anamnesisDTO.GeneralConclusion;
        }

        public void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindowPatient parentWindow = Window.GetWindow(this) as MainWindowPatient;

            

            parentWindow.Notif.Content = new Anamnesiss(Username);


        }
    }
}
