using Newtonsoft.Json;
using Projekat_SIMS_IN_TIM3.IRepository;
using Projekat_SIMS_IN_TIM3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Repository
{
    public class AbsenceRequestRepository: AbsenceRequestIRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\absenceRequests.json";
        public List<AbsenceRequest> requests { get; set; } = new List<AbsenceRequest>();
        

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
