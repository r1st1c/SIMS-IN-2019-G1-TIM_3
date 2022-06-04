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
    public class DoctorRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\doctors.json";
        private List<Doctor> doctors = new List<Doctor>();

        public DoctorRepository()
        {
            ReadJson();
        }

        public void ReadJson()
        {
            if(!File.Exists(fileLocation))
            {
                File.Create(fileLocation).Close();            }
            using (StreamReader stream = new StreamReader(fileLocation))
            {
                string jsonData = stream.ReadToEnd();
                    if(jsonData != "")
                {
                    doctors = JsonConvert.DeserializeObject<List<Doctor>>(jsonData);
                }
            }
        }

        public void WriteToJson()
        {
            string jsonData = JsonConvert.SerializeObject(doctors);
            File.WriteAllText(fileLocation, jsonData);
        }

        public List<Doctor> GetAll()
        {
            ReadJson();
            return doctors;
        }

        public Doctor GetById(int id)
        {
            ReadJson();
            return doctors.Find(x => x.User.Id == id);
        }

        public int GetIdByNameAndSurname(string name, string surname)
        {
            ReadJson();
            int id = int.MinValue;
            id = doctors.FindIndex(obj => obj.User.Name == name && obj.User.Surname == surname);
            return id;
        }

        public int GetIdByUsername(string usname)
        {
            ReadJson();
            return doctors.Find(obj => obj.User.Username == usname).User.Id;
        }

        public bool SaveAndUpdate(Doctor d)
        {
            doctors.Add(d);
            WriteToJson();
            return true;
        }

        public bool Delete(int id)
        {
            ReadJson();
            int idx = doctors.FindIndex(x => x.User.Id == id);
            doctors.RemoveAt(idx);
            WriteToJson();

            return true;
        }

        public List<string> NameSurnameSpec()
        {
            ReadJson();
            List<string> spec = new List<string>();

           foreach (Doctor doctor in doctors)
            {
                string retVal = doctor.User.Name + " " + doctor.User.Surname + " " + doctor.specializationType;
                spec.Add(retVal);
            }
               return spec;
                
        }

        
        
   }
}
