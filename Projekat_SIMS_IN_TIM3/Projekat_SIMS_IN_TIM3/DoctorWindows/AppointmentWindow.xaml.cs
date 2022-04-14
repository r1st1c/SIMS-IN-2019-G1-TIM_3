using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Projekat_SIMS_IN_TIM3.DoctorWindows
{
    /// <summary>
    /// Interaction logic for AppointmentWindow.xaml
    /// </summary>
    public partial class AppointmentWindow : Window, INotifyPropertyChanged
    {
        public AppointmentController appointmentController = new AppointmentController();
        public static ObservableCollection<Appointment> appointments { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;
        public AppointmentWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            appointments = new ObservableCollection<Appointment>(appointmentController.getAll());


        }

        

       

    }
}
