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
    public class MedicinePrescriptionRepository: MedicinePrescriptionIRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\medPrescriptions.json";
        public List<MedicinePrescription> prescriptions { get; set; } = new List<MedicinePrescription>();


        public MedicinePrescriptionRepository() { ReadJson();  }


        public int GetNextId()
        {
            return prescriptions.Count != 0 ? prescriptions.Max(x => x.Id) + 1 : 0;
        }
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
                    prescriptions = JsonConvert.DeserializeObject<List<MedicinePrescription>>(json);
                }
            }
        }

        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(prescriptions);
            File.WriteAllText(fileLocation, json);
        }

        public void Create(MedicinePrescription mp)
        {
            prescriptions.Add(mp);
            WriteToJson();
        }

        public void Update(MedicinePrescription mp)
        {
            ReadJson();
            int idx = prescriptions.FindIndex(obj => obj.Id == mp.Id);
            prescriptions[idx] = mp;
            WriteToJson();
        }

        public List<MedicinePrescription> GetAll()
        {
            ReadJson();
            return prescriptions;
        }

        public void Delete(int id)
        {
            ReadJson();
            prescriptions.RemoveAt(prescriptions.FindIndex(obj => obj.Id == id));
            WriteToJson();
        }

        public List<MedicinePrescription> GetAllById(int id)
        {
            ReadJson();
            return prescriptions.FindAll(obj => obj.PatientId == id);
        }

        public MedicinePrescription GetById(int id)
        {
            ReadJson();
            return prescriptions.Find(obj => obj.Id == id);
        }
    }
}
