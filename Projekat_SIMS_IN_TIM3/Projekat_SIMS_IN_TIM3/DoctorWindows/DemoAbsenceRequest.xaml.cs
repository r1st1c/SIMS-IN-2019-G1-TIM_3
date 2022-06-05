using Projekat_SIMS_IN_TIM3.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Projekat_SIMS_IN_TIM3.DoctorWindows
{
    /// <summary>
    /// Interaction logic for DemoAbsenceRequest.xaml
    /// </summary>
    public partial class DemoAbsenceRequest : Window, INotifyPropertyChanged
    {
        public int DoctorId { get; set; }
        public string DoctorsNameAndSurname { get; set; }
        DoctorController doctorController = new DoctorController();
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public DemoAbsenceRequest(int doctorId)
        {
            InitializeComponent();
            this.DataContext = this;
            DoctorId = doctorId;
            DoctorsNameAndSurname = doctorController.GetById(DoctorId).User.Name.ToString() + " " + doctorController.GetById(DoctorId).User.Surname.ToString();
        }


        public void StartDemoButtonClick(object sender, RoutedEventArgs e)
        {
            StartDemoMode();

        }

        public void sendRequest(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You have successfully sent an absence request!");
            CreateAbsenceReq create = new CreateAbsenceReq(DoctorId);
            create.Show();
        }

        #region DEMO
        public Thread DemoThread { get; set; }


        public void StartDemoMode()
        {
            DemoThread = new Thread(CallDemoMethods);
            DemoThread.Start();
        }

        public void CallDemoMethods()
        {
            while (true)
            {
                toggleStopVisibility();
                disableComponents();



                datepickerDemoStart();
                Thread.Sleep(250);
                datepickerDemoEnd();
                Thread.Sleep(250);
                comboboxDemo(urgentCb);
                //Thread.Sleep(250);
                textBoxDemo(explanation, "Odustvo neophodno zbog poslovnog puta.");
                Thread.Sleep(250);
                buttonDemo();
                Thread.Sleep(1000);



                clearComponents();

                Thread.EndCriticalRegion();
            }
        }


        private void disableComponents()
        {
            try
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    startTime.IsEnabled = false;
                    endTime.IsEnabled = false;
                    explanation.IsReadOnly = true;
                    urgentCb.IsEnabled = false;
                    //saveBtnName.IsEnabled = false;
                }));
            }
            catch (Exception ex) { }
        }

        private void clearComponents()
        {
            try
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    startTime.SelectedDate = null;
                    endTime.SelectedDate = null;
                    urgentCb.SelectedIndex = -1;
                    explanation.Text = " ";
                    

                }));
            }
            catch (Exception ex) { }
        }


        private void textBoxDemo(TextBox textBox, string value)
        {
            try
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    textBox.BorderBrush = new SolidColorBrush(Colors.Red);
                }));
                for (int i = 1; i <= value.Length; i++)
                {
                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        textBox.Text = value.Substring(0, i);
                    }));
                    Thread.Sleep(250);
                }
                this.Dispatcher.Invoke((Action)(() =>
                {
                    textBox.BorderBrush = new SolidColorBrush(Colors.Gray);
                }));
            }
            catch (Exception ex) { }
        }

        private void comboboxDemo(ComboBox comboBox)
        {
            try
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    comboBox.BorderBrush = new SolidColorBrush(Colors.Red);
                    comboBox.IsDropDownOpen = true;
                }));
                Thread.Sleep(450);
                this.Dispatcher.Invoke((Action)(() =>
                {
                    comboBox.SelectedIndex = 1;
                    comboBox.IsDropDownOpen = false;
                    comboBox.BorderBrush = new SolidColorBrush(Colors.Gray);
                }));
            }
            catch (Exception ex) { }

        }

        private void datepickerDemoStart()
        {
            try
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    startTime.BorderBrush = new SolidColorBrush(Colors.Red);
                    startTime.IsEnabled = true;
                    startTime.IsDropDownOpen = true;
                    startTime.Text = new DateTime(2022, 5, 5).ToString();



                }));
                Thread.Sleep(450);
                this.Dispatcher.Invoke((Action)(() =>
                {
                    startTime.BorderBrush = new SolidColorBrush(Colors.Gray);
                    startTime.IsDropDownOpen = false;
                    startTime.IsEnabled = false;


                }));
            }
            catch (Exception ex)
            {

            }

        }

        private void datepickerDemoEnd()
        {
            try
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    endTime.BorderBrush = new SolidColorBrush(Colors.Red);
                    endTime.IsEnabled = true;
                    endTime.IsDropDownOpen = true;
                    endTime.Text = new DateTime(2022, 5, 15).ToString();

                }));
                Thread.Sleep(450);
                this.Dispatcher.Invoke((Action)(() =>
                {


                    endTime.BorderBrush = new SolidColorBrush(Colors.Gray);
                    endTime.IsDropDownOpen = false;
                    endTime.IsEnabled = false;
                }));
            }
            catch (Exception ex)
            {

            }
        }

      

        private void toggleStopVisibility()
        {
            try
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    StopDemoButton.Visibility = Visibility.Visible;
                    StartDemoButton.Visibility = Visibility.Hidden;

                }));
            }
            catch (Exception ex) { }

        }

        private void buttonDemo()
        {
            try
            {

                this.Dispatcher.Invoke((Action)(() =>
                {
                    saveBtnName.IsEnabled = true;
                    saveBtnName.Background = Brushes.Red;
                }));
                Thread.Sleep(300);
                this.Dispatcher.Invoke((Action)(() =>
                {
                    BrushConverter bc = new BrushConverter();
                    saveBtnName.Background = (Brush)bc.ConvertFrom("#4267B2");
                    saveBtnName.IsEnabled = false;
                }));
                Thread.Sleep(450);
            }
            catch (Exception ex) { }

        }

        private void StopDemoButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                DemoThread.Abort();
            }
            catch (Exception ex) { }

            NavigationService navigationService = NavigationService.GetNavigationService(new CreateAbsenceReq(DoctorId));
            return;

        }

        #endregion
    }
}
