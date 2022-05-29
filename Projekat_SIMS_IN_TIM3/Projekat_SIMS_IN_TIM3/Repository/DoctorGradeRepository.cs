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
    public class DoctorGradeRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\doctorgrades.json";
        private List<DoctorGrade> doctorGrades = new List<DoctorGrade>();

        public DoctorGradeRepository()
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
                    doctorGrades = JsonConvert.DeserializeObject<List<DoctorGrade>>(jsonData);
                }
            }
        }

        public void writeToJson()
        {
            string jsonData = JsonConvert.SerializeObject(doctorGrades);
            File.WriteAllText(fileLocation, jsonData);
        }

        public List<DoctorGrade> GetAll()
        {
            readJson();
            return doctorGrades;
        }

        public DoctorGrade GetByDoctorId(int doctorId)
        {
            readJson();
            return doctorGrades.Find(x => x.doctorId == doctorId);
        }

        public void Create(DoctorGrade doctorGrade)
        {
            doctorGrades.Add(doctorGrade);
            writeToJson();
        }

       
       

        

     
    }
}
