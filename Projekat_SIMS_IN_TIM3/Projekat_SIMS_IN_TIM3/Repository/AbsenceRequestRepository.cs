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

        public int GetNextId()
        {
            return requests.Count!=0 ? requests.Max(x => x.Id)+1 : 0;
        }

        public void Create(AbsenceRequest request)
        {
            ReadJson();
            // inicijalno svi su na cekanju
            if(request.requestStatus != AbsenceRequest.RequestStatus.OnHold)
            {
                request.requestStatus = AbsenceRequest.RequestStatus.OnHold;
            }

           requests.Add(request);
           WriteToJson();
             
        }

        // da li je pocetak odmora zakazan bar za 2 dana posle danasnjeg dana
        public bool CheckTimeOfSendingRequest(DateTime startDate)
        {
            DateTime now = DateTime.Now;
            TimeSpan timeSpan = startDate - now;

                if(timeSpan.Days >= 2)
            {
                return true;
            } else
                return false;
        }

        // provera da li postoji lekar koji je podneo zahtev za odsustvo u istom periodu
        public int CheckDoctorSpecialization(String specialization, DateTime start, DateTime end)
        {
            ReadJson();
            var requestBySameSpecialization = 0;

            foreach (var request in requests)
            {
                string SpecializationInRequests = doctorRepository.GetById(request.DoctorId).specializationType;

                if (SpecializationInRequests == specialization)
                {
                    if ((start.Date < request.StartDate.Date && end == request.StartDate.Date) ||
                        (start.Date < request.EndDate.Date && end <= request.EndDate.Date) ||
                        (start.Date >= request.StartDate.Date && end <= request.EndDate.Date) ||
                        (start.Date >= request.StartDate.Date && end > request.EndDate.Date))
                    {
                        requestBySameSpecialization++;
                    }
                }
              
            }
            return requestBySameSpecialization;
        }

        public bool IsThereDoctorWithSameSpecialization(String specialization, DateTime start, DateTime end)
        {
            int numOfAlreadySentReqs = CheckDoctorSpecialization(specialization, start, end); 
                if(numOfAlreadySentReqs != 0)
            {
                return true;
            } else 
                return false;
        }
 
  
        public List<AbsenceRequest> GetAll()
        {
            ReadJson();
            return requests;
        }

        public List<AbsenceRequest> GetRequestsByDoctorsId(int id)
        {
            ReadJson();
            return requests.FindAll(obj => obj.DoctorId == id);
        }

        
       


    }
}
