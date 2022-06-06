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
    public class HospitalGradeRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\hospitalgrades.json";
        private List<HospitalGrade> hospitalGrades = new List<HospitalGrade>();

        public HospitalGradeRepository()
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
                    hospitalGrades = JsonConvert.DeserializeObject<List<HospitalGrade>>(jsonData);
                }
            }
        }

        public void writeToJson()
        {
            string jsonData = JsonConvert.SerializeObject(hospitalGrades);
            File.WriteAllText(fileLocation, jsonData);
        }

        public List<HospitalGrade> GetAll()
        {
            readJson();
            return hospitalGrades;
        }

        
        public void Create(HospitalGrade hospitalGrade)
        {
            hospitalGrades.Add(hospitalGrade);
            writeToJson();
        }

    }
}
