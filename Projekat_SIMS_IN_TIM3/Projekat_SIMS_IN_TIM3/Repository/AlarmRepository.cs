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
    public class AlarmRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\alarms.json";
        private List<Alarm> alarms = new List<Alarm>();

        public AlarmRepository()
        {
            readJson();
        }

        public void readJson()
        {
            if (!File.Exists(fileLocation))
            {
                File.Create(fileLocation).Close();
            }
            using (StreamReader stream = new StreamReader(fileLocation))
            {
                string jsonData = stream.ReadToEnd();
                if (jsonData != "")
                {
                    alarms = JsonConvert.DeserializeObject<List<Alarm>>(jsonData);
                }
            }
        }

        public void writeToJson()
        {
            string jsonData = JsonConvert.SerializeObject(alarms);
            File.WriteAllText(fileLocation, jsonData);
        }

        public List<Alarm> GetAll()
        {
            readJson();
            return alarms;
        }

        public List<Alarm> GetByPatientId(int patientId)
        {
            readJson();
            return alarms.FindAll(x => x.PatientId == patientId);
        }

        public void Create(Alarm alarm)
        {
            alarms.Add(alarm);
            writeToJson();
        }
    }
}
