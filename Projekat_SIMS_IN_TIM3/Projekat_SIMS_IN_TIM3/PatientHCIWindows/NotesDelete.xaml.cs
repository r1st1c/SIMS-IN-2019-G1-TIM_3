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

namespace Projekat_SIMS_IN_TIM3
{
    /// <summary>
    /// Interaction logic for NotesDelete.xaml
    /// </summary>
    public partial class NotesDelete : Page
    {
        public App application { get; set; }

        public List<Note> notes = new List<Note>();
        public String Username { get; set; }

        public int noteId { get; set; }
        public NotesDelete(int Id, String Username)
        {
            InitializeComponent();
            this.DataContext = this;
            this.noteId = Id;
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

            

            this.application.noteController.DeleteNode(noteId);

            parentWindow.Notif.Content = new Notes(Username);


        }
    }
}
