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
using Projekat_SIMS_IN_TIM3.Model;

namespace Projekat_SIMS_IN_TIM3
{
    /// <summary>
    /// Interaction logic for NotesAdd.xaml
    /// </summary>
    /// 
    
    public partial class NotesAdd : Page
    {

        public App application { get; set; }

        public Note note { get; set; }
        public List<Note> notes { get; set; }
        public String Username { get; set; }
        public int noteId { get; set; }
        public int patientId { get; set; }
        public NotesAdd(String Username, int patientId)
        {
            InitializeComponent();
           
            this.ErrorBoth.Visibility = Visibility.Collapsed;
           
            
            this.ErrorTitle.Visibility = Visibility.Collapsed;
             
            
            this.ErrorText.Visibility = Visibility.Collapsed;
            

            this.patientId = patientId;
            this.DataContext = this;
       
            this.Username = Username;
            application = Application.Current as App;
        }


        public void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindowPatient parentWindow = Window.GetWindow(this) as MainWindowPatient;


            parentWindow.Notif.Content = new Notes(Username);


        }

        public void Confirm_Click(object sender, RoutedEventArgs e)
        {
            MainWindowPatient parentWindow = Window.GetWindow(this) as MainWindowPatient;

            string title = this.Title.Text;
            string text = this.Text.Text;

            if(title.Length==0 && text.Length==0)
            {
                this.ErrorText.Visibility= Visibility.Collapsed;
                this.ErrorTitle.Visibility= Visibility.Collapsed;
                this.ErrorBoth.Visibility = Visibility.Visible;
                return;
            }
            if (title.Length==0)
            {
                this.ErrorText.Visibility = Visibility.Collapsed;
                this.ErrorTitle.Visibility = Visibility.Visible;
                this.ErrorBoth.Visibility = Visibility.Collapsed;
                return;
            }
            if (text.Length == 0)
            {
                this.ErrorText.Visibility = Visibility.Visible;
                this.ErrorTitle.Visibility = Visibility.Collapsed;
                this.ErrorBoth.Visibility = Visibility.Collapsed;
                return;
            }


            note = new Note(this.application.noteController.getNextId(), patientId, this.Title.Text, this.Text.Text, DateTime.Now);

            this.application.noteController.CreateNote(note);
            parentWindow.Notif.Content = new Notes(Username);


        }
    }
}
