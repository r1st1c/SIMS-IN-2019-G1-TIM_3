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



    }
}
