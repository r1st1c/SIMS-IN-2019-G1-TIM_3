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
    /// Interaction logic for AppointmentsSearch.xaml
    /// </summary>
    public partial class AppointmentsSearch : Page
    {
        string Username { get; set; }
        public App application { get; set; }

        public Patient patient = new Patient();
   
        int DoctorId { get; set; }

        public static List<Doctor> doctors { get; set; } = new List<Doctor>();

        public static List<String> doctorNames { get; set; } = new List<String>();

        

        UIElement parent = App.Current.MainWindow;
        public AppointmentsSearch(string Username)
        {
            InitializeComponent();
            this.DataContext = this;

            this.Username = Username;
            application = Application.Current as App;

            doctors.Clear();
            doctorNames.Clear();

            FillDoctorsList();
        }

        public void FillDoctorsList()
        {
            
            doctors = this.application.docController.GetAll();

            GetDoctorNames();
            
            DoctorList.ItemsSource = doctorNames;
        }

        public void GetDoctorNames()
        {
            foreach(Doctor doctor in doctors)
            {
                doctorNames.Add(doctor.User.Name + " " + doctor.User.Surname);

            }

        }

        public int GetDoctorId(String DoctorName)
        {
            String[] DocName = DoctorName.Split(' ');

            return application.docController.GetIdByNameAndSurname(DocName[0], DocName[1]);
        }

        public void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindowPatient parentWindow = Window.GetWindow(this) as MainWindowPatient;


            parentWindow.Notif.Content = new Appointments(Username);

        }


        public void Search_Click(object sender, RoutedEventArgs e)
        {
            MainWindowPatient parentWindow = Window.GetWindow(this) as MainWindowPatient;

            DoctorId = GetDoctorId(this.DoctorList.Text);

            SearchAppointmentDTO searchDTO = MakeDTO();

            parentWindow.Notif.Content = new AppointmentsAdd(searchDTO);

        }

        
        public SearchAppointmentDTO MakeDTO()
        {
         
            return new SearchAppointmentDTO(DoctorId, Username, (DateTime) this.StartTime.SelectedDate, (DateTime) this.EndTime.SelectedDate, this.PriorityList.Text);
        }

        
    }
}
