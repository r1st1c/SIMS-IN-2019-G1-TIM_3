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
            readJson();
        }

        public void readJson()
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

        public void writeToJson()
        {
            string json = JsonConvert.SerializeObject(medicalRecords);
            File.WriteAllText(fileLocation, json);
        }

        public void createMedicalRecord(Model.MedicalRecord medicalRecord)
        {
            medicalRecords.Add(medicalRecord);
        }

        public void updateMedicalRecord(Model.MedicalRecord medicalRecord)
        {
            // to do
            return;

            
        }

        public void deleteMedicalRecord(int id)
        {
            readJson();
            int idx = medicalRecords.FindIndex(m => m.Id == id);
            medicalRecords.RemoveAt(idx);
            writeToJson();
        }

        public List<MedicalRecord> getAll()
        {
            readJson();
            return medicalRecords;
        }

        public MedicalRecord getByPatientId(int id)
        {
            readJson();
            return medicalRecords.Find(m => m.Id == id);
        }
    }
}
