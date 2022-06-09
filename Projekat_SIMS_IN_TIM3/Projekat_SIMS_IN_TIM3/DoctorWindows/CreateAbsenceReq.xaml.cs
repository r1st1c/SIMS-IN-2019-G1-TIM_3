using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.IRepository;
using Projekat_SIMS_IN_TIM3.Repository;
using Projekat_SIMS_IN_TIM3.Service;
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
using static Projekat_SIMS_IN_TIM3.Model.AbsenceRequest;

namespace Projekat_SIMS_IN_TIM3.DoctorWindows
{
    /// <summary>
    /// Interaction logic for CreateAbsenceReq.xaml
    /// </summary>
    public partial class CreateAbsenceReq : Window
    {
        public int DoctorId { get; set; }
        public AbsenceRequestController absenceRequestController;
        public AppointmentController appointmentController;
        public DoctorController doctorController = new DoctorController();
        public AbsenceNotificationsController notificationsController;
        public String DoctorsNameAndSurname { get; set; }

        public CreateAbsenceReq(int doctorsId)
        {
            
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;

            this.doctorController = app.docController;
            this.appointmentController = app.appointmentController;
            this.absenceRequestController = app.absenceRequestController;
            this.notificationsController = app.AbsenceNotificationsController;
            DoctorId = doctorsId;
            DoctorsNameAndSurname = doctorController.GetById(DoctorId).User.Name.ToString() + " " + doctorController.GetById(DoctorId).User.Surname.ToString();
        }

        private void HomeBtn(object sender, RoutedEventArgs e)
        {
            MainPage mainPage = new MainPage(DoctorId);
            mainPage.Show();
        }

        private void CalendarPageBtn(object sender, RoutedEventArgs e)
        {
            Calendar calendar = new Calendar(DoctorId);
            calendar.Show();
            this.Close();
        }

        private void NotifBtn(object sender, RoutedEventArgs e)
        {
            Notifications notifications = new Notifications(DoctorId);
            notifications.Show();
            this.Close();
        }

        private void MedVerifBtn(object sender, RoutedEventArgs e)
        {
            MedVerif medVerif = new MedVerif(DoctorId);
            medVerif.Show();
            this.Close();
        }

        private void AbsenceReqBtn(object sender, RoutedEventArgs e)
        {
            CreateAbsenceReq createAbsenceReq = new CreateAbsenceReq(DoctorId);
            createAbsenceReq.Show();
            this.Close();
        }

        public void sendRequest(object sender, RoutedEventArgs e)
        {
            // startTime, endTime, urgentCb, explanation
            DateTime start = (DateTime)startTime.Value;
            DateTime end = (DateTime)endTime.Value;
            bool urgent = isUrgent();
            string addExpl = explanation.Text;
            RequestStatus status = AbsenceRequest.RequestStatus.OnHold;
            int id = (absenceRequestController.GetAll() == null) ? 0 : absenceRequestController.GetNextId();

            AbsenceRequest newRequest = new AbsenceRequest(
               id,
               start,
               end,
               addExpl,
               urgent,
               Convert.ToInt32(DoctorId));

            int notificationId = (absenceRequestController.GetAll() == null) ? 0 : absenceRequestController.GetNextId();
            AbsenceNotification notification = new AbsenceNotification(
                notificationId,
                newRequest,
                " "
                );

            // check if start time of wanted absence is set at least 2 days from today's day
            bool twoDaysRule = TwoDaysTimeRule();


            // check if doctors has scheduled appointments during chosen interval of time
            bool isFree = appointmentController.IsDoctorFree(DoctorId, start, end);

            // check if doctor with same specialization has already sent an absence request for the same interval of time
            bool equalRanges = absenceRequestController.EqualRanges(start, end, doctorController.GetById(Convert.ToInt32(DoctorId)).specializationType);
            bool containedInRange = absenceRequestController.ContainedInRange(start, end, doctorController.GetById(Convert.ToInt32(DoctorId)).specializationType);
            bool StartsInRange = absenceRequestController.StartsInRange(start, doctorController.GetById(Convert.ToInt32(DoctorId)).specializationType);
            bool EndsInRange = absenceRequestController.EndsInRange(end, doctorController.GetById(Convert.ToInt32(DoctorId)).specializationType);
            bool ContainsRange = absenceRequestController.ContainsRange(start, end, doctorController.GetById(Convert.ToInt32(DoctorId)).specializationType);


            if (twoDaysRule == false)
            {
                MessageBox.Show("Your first day of request absence must be at least 2 days from today's day!");
                return;
            } else 
            {
                if (isUrgent() == true)
                {
                    absenceRequestController.Create(newRequest);
                    notificationsController.Create(notification);
                    MessageBox.Show("You have successfully created urgent absence request", "Successful creation of absence request");

                    return;

                } else if (isUrgent() == false)
                {
                    if (isFree == true)
                    {
                        if ( isFree == true && equalRanges == false && containedInRange == false && StartsInRange == false &&  EndsInRange == false && ContainsRange == false)
                        {
                            absenceRequestController.Create(newRequest);
                            notificationsController.Create(notification);
                            MessageBox.Show("You have successfully created non-urgent absence request", "Successful creation of absence request");
                           
                        } else
                        {
                            MessageBox.Show("At least one doctor with same specialization has already sent absence request at this period of time!");
                            return;
                        }
                    } else
                    {
                        MessageBox.Show("You have scheduled appointments during chosen period of absence!");
                        return;
                    }
                }
            }



        }

        public bool TwoDaysTimeRule()
        {
            DateTime now = DateTime.Now;
            DateTime start = (DateTime)startTime.Value;
            TimeSpan timeSpan = start - now;

            return (timeSpan.Days >= 2) ? true : false; 
               
        }

        public bool isUrgent()
        {
            return (urgentCb.SelectedValue.ToString() == "YES") ? true : false;
           
        }

        public void cancelSendingRequest(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to CANCEL sending absence request?\n All prevously entered data won't be saved!","Cancel sending absence request", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MainPage mainPage = new MainPage(DoctorId);
                    mainPage.Show();
                    break;


                case MessageBoxResult.No:
                    return;
                    break;
            }
        }



    }
}
