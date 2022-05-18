using Newtonsoft.Json;
using Projekat_SIMS_IN_TIM3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Repository
{
    public class AbsenceRequestRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\absenceRequests.json";
        public List<AbsenceRequest> requests { get; set; } = new List<AbsenceRequest>();
        

        public DoctorRepository doctorRepository = new DoctorRepository();
        public AppointmentRepository appointmentRepository = new AppointmentRepository();

        public AbsenceRequestRepository() { }

        public void ReadJson()
        {
            if (!File.Exists(fileLocation))
            {
                File.Create(fileLocation).Close();
            }

            using (StreamReader r = new StreamReader(fileLocation))
            {
                string json = r.ReadToEnd();
                if (json != "")
                {
                    requests = JsonConvert.DeserializeObject<List<AbsenceRequest>>(json);
                }
            }
        }

        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(requests);
            File.WriteAllText(fileLocation, json);
        }

        public void createAbsenceRequest(AbsenceRequest request)
        {
            ReadJson();
            // inicijalno svi su na cekanju
            if(request.requestStatus != AbsenceRequest.RequestStatus.OnHold)
            {
                request.requestStatus = AbsenceRequest.RequestStatus.OnHold;
            }

            // provera da li je poslat 2 dana pre zeljenog pocetka
            bool checkTime = checkTimeOfSendingRequest(request.StartDate);

            // provera ima li zakazanih pregleda/operacija u tom periodu
            int checkTerms = checkScheduledTerms(request.StartDate, request.EndDate, request.DoctorId);

            // provera ima li vise od 1 lekara iste specijalizacije da su poslali zahtev u istom periodu
            int checkSpecialization = CheckDoctorSpecialization(doctorRepository.getById(request.DoctorId).specializationType);

                if(checkTime == true && checkTerms < 0 && checkSpecialization <1 )
            {
                requests.Add(request);
            }

            
        }

        public bool checkTimeOfSendingRequest(DateTime startDate)
        {
            DateTime now = DateTime.Now;
            TimeSpan timeSpan = startDate - now;

                if(timeSpan.Days >= 2)
            {
                return true;
            } else
                return false;
        }

        public int CheckDoctorSpecialization(String specialization)
        {
            ReadJson();
            var requestBySameSpecialization = 0;

            foreach (var request in requests)
            {
                string SpecializationInRequests = doctorRepository.getById(request.DoctorId).specializationType;

                    if(SpecializationInRequests == specialization)
                {
                    requestBySameSpecialization++;
                }
              
            }
            return requestBySameSpecialization;
        }

        
        public int checkScheduledTerms(DateTime startDate, DateTime endDate, int doctorsId)
        {
            var appointments = appointmentRepository.GetByDoctorsId(doctorsId);
            var scheduledTerms = 0;
            foreach (var appointment in appointments)
            {
                if(appointment.StartTime.Date > startDate.Date && appointment.StartTime.Date < endDate.Date)
                {
                    scheduledTerms++;
                }
            }
            return scheduledTerms;
        }
        

        public List<AbsenceRequest> getAll()
        {
            ReadJson();
            return requests;
        }

        public List<AbsenceRequest> getAllByDoctorsId(int doctorsId)
        {
            ReadJson();
            return requests.FindAll(obj => obj.DoctorId == doctorsId);
        }

        
       


    }
}
