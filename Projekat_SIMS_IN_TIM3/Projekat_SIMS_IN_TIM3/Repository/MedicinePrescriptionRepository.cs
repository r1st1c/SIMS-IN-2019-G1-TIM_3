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
    public class MedicinePrescriptionRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\medPrescriptions.json";
        public List<MedicinePrescription> prescriptions { get; set; } = new List<MedicinePrescription>();


        public MedicinePrescriptionRepository() { readJson();  }


        public int getNextId()
        {
            int lastId = int.MinValue;
            readJson();
            foreach (MedicinePrescription prescription in prescriptions)
            {
                lastId = prescriptions.Last().Id;
            }
            return lastId;
        }
        public void readJson()
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

        public void create(MedicinePrescription mp)
        {
            prescriptions.Add(mp);
            WriteToJson();
        }

        public void update(MedicinePrescription mp)
        {
            readJson();
            int idx = prescriptions.FindIndex(obj => obj.Id == mp.Id);
            prescriptions[idx] = mp;
            WriteToJson();
        }

        public List<MedicinePrescription> getAll()
        {
            readJson();
            return prescriptions;
        }

        public void delete(int pId)
        {
            readJson();
            int index = prescriptions.FindIndex(obj => obj.Id == pId);
            prescriptions.RemoveAt(index);
            WriteToJson();
        }

        public List<MedicinePrescription> getAllById(int id)
        {
            readJson();
            return prescriptions.FindAll(obj => obj.PatientId == id);
        }

        public MedicinePrescription getById(int id)
        {
            readJson();
            return prescriptions.Find(obj => obj.Id == id);
        }
    }
}
