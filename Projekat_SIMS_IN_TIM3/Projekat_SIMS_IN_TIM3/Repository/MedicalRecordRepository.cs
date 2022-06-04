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
    public class MedicalRecordRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\medicalRecords.json";
        public List<MedicalRecord> medicalRecords = new List<MedicalRecord>();

        public MedicalRecordRepository()
        {
            ReadJson();
        }

        public void ReadJson()
        {
            if(!File.Exists(fileLocation))
            {
                File.Create(fileLocation).Close();
            }

            using (var reader = new StreamReader(fileLocation))
            {
                string json = reader.ReadToEnd();
                    if(json != "")
                {
                    medicalRecords = JsonConvert.DeserializeObject<List<MedicalRecord>>(json);
                }
            }
        }

        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(medicalRecords);
            File.WriteAllText(fileLocation, json);
        }

        public void Create(MedicalRecord mr) => medicalRecords.Add(mr);

        public void Delete(int id)
        {
            ReadJson();
            medicalRecords.RemoveAt(medicalRecords.FindIndex(m => m.Id == id));
            WriteToJson();
        }

        public List<MedicalRecord> GetAll()
        {
            ReadJson();
            return medicalRecords;
        }

        public MedicalRecord GetByPatientId(int id)
        {
            ReadJson();
            return medicalRecords.Find(m => m.Id == id);
        }
    }
}
