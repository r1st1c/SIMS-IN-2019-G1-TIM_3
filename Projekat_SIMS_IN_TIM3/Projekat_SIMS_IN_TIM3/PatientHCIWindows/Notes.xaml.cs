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
using System.Collections.ObjectModel;

namespace Projekat_SIMS_IN_TIM3
{
    /// <summary>
    /// Interaction logic for Notes.xaml
    /// </summary>
    public partial class Notes : Page
    {
        string Username;
        public App application { get; set; }
        public Patient patient = new Patient();
        public static ObservableCollection<Note> notes { get; set; }
        public int patId { get; set; } = 1;
        UIElement parent = App.Current.MainWindow;
        public Notes(String Username)
        {
            InitializeComponent();

            this.DataContext = this;

            this.Username= Username;
            application = Application.Current as App;

            List<Patient> patients = application.patientController.GetAll();


            Patient patient = null;

            foreach (Patient pat in patients)
            {
                if (pat.User.Username == Username)
                {
                    patient = pat;
                    patId = pat.User.Id;
                    
                }
            }
            
            notes = new ObservableCollection<Note>(application.noteController.GetByPatientsId(patient.User.Id));

     
        }

        public void Add_Note_Click(object sender, RoutedEventArgs e)
        {
            MainWindowPatient parentWindow = Window.GetWindow(this) as MainWindowPatient;

         
            parentWindow.Notif.Content = new NotesAdd(Username, patId);
        }

        public void View_Note_Click(object sender, RoutedEventArgs e)
        {
            MainWindowPatient parentWindow = Window.GetWindow(this) as MainWindowPatient;

            Note note = (Note)((Button)e.Source).DataContext;
            int id = note.Id;
            
            parentWindow.Notif.Content = new NotesView(id, patId, Username);


        }

        public void Edit_Note_Click(object sender, RoutedEventArgs e)
        {
            MainWindowPatient parentWindow = Window.GetWindow(this) as MainWindowPatient;

            Note note = (Note)((Button)e.Source).DataContext;
            int id = note.Id;

            parentWindow.Notif.Content = new NotesEdit(id, Username, patId);
        }

        public void Delete_Note_Click(object sender, RoutedEventArgs e)
        {
            MainWindowPatient parentWindow = Window.GetWindow(this) as MainWindowPatient;

            Note note = (Note)((Button)e.Source).DataContext;
            int id = note.Id;

            parentWindow.Notif.Content = new NotesDelete(id, Username);
        }
    }

    
}
