using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Model;
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
        AbsenceRequestController absenceRequestController = new AbsenceRequestController();
        AppointmentController appointmentController = new AppointmentController();
        DoctorController doctorController = new DoctorController();

        public CreateAbsenceReq(int doctorsId)
        {
            
            InitializeComponent();
            DoctorId = doctorsId;
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
            Notifications notifications = new Notifications();
            notifications.Show();
            this.Close();
        }

        private void ListOfMedBtn(object sender, RoutedEventArgs e)
        {
            ListOfMedicines listOfMedicines = new ListOfMedicines();
            listOfMedicines.Show();
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

            AbsenceRequest newRequest = new AbsenceRequest(
               absenceRequestController.getNextId(),
               start,
               end,
               addExpl,
               urgent,
               Convert.ToInt32(DoctorId));

            


            // provera da li je poslat 2 dana pre zeljenog pocetka
            bool twoDaysRule = absenceRequestController.checkTimeOfSendingRequest(start);

            // check if doctors has scheduled appointments during chosen interval of time
            int num = appointmentController.numOfScheduledAppointmentsDuringPeriod(DoctorId, start, end);
            bool isFree = appointmentController.isDoctorFree(DoctorId, start, end);

            // check if doctor with same specialization has already sent an absence request for the same interval of time
            int numOfDocs = absenceRequestController.CheckDoctorSpecialization(
                    doctorController.GetById(DoctorId).specializationType,
                    start,
                    end);
            bool isThereDoctor = absenceRequestController.isThereDoctorWithSameSpecialization(
                doctorController.GetById(DoctorId).specializationType,
                start,
                end);
    /*
            if (isThereDoctor == true)
            {
                MessageBox.Show("At least one doctor with same specialization has already sent absence request at this period of time!");
                return;
            }

            if (isFree == false)
            {
                MessageBox.Show("You have scheduled appointments during chosen period of absence!");
                return;
            }
    */
            if (twoDaysRule == false)
            {
                MessageBox.Show("Your first day of request absence must be at least 2 days from today's day!");
                return;
            } else if(twoDaysRule == true)
            {
                if(isUrgent() == true)
                {
                    absenceRequestController.createAbsenceRequest(newRequest);
                    MessageBox.Show("You have successfully created urgent absence request", "Successful creation of absence request");

                    return;

                } else if(isUrgent() == false)
                {
                    if(isFree == true)
                    {
                        if(isThereDoctor == false)
                        {
                            absenceRequestController.createAbsenceRequest(newRequest);
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



            // check if doctors has scheduled operations during chosen interval of time

          


        }

        public bool isUrgent()
        {
            if(urgentCb.SelectedValue.ToString() == "YES")
            {
                return true;
            } else
            {
                return false;
            }
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
