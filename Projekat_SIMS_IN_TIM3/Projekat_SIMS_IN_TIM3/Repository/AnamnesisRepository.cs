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
    public class AnamnesisRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\anamnesis.json";//Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\doctors.json";
        private List<Anamnesis> anamnesis = new List<Anamnesis>();

        public AnamnesisRepository()
        {
            ReadJson();
        }

        public void ReadJson()
        {
            if (!File.Exists(fileLocation))
            {
                File.Create(fileLocation).Close();
            }

            using (StreamReader sr = new StreamReader(fileLocation))
            {
                string json = sr.ReadToEnd();
                if (json != "")
                {
                    anamnesis = JsonConvert.DeserializeObject<List<Anamnesis>>(json);
                }
            }
        }

        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(anamnesis);
            File.WriteAllText(fileLocation, json);
        }

        
        public List<Anamnesis> GetByPatientsId(int id)
        {
            ReadJson();
            return anamnesis.FindAll(obj => obj.PatientId == id);

        }

        public Anamnesis GetById(int id)
        {
            return anamnesis.Find(obj => obj.Id == id);
        }

        public List<Anamnesis> GetAll()
        {
            ReadJson();
            return anamnesis;
        }
    }
}