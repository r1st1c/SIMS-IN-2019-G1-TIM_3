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
            readJson();
        }

        public void readJson()
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

        public void writeToJson()
        {
            string jsonData = JsonConvert.SerializeObject(doctors);
            File.WriteAllText(fileLocation, jsonData);
        }

        public List<Doctor> GetAll()
        {
            readJson();
            return doctors;
        }

        public Doctor getById(int id)
        {
            readJson();
            return doctors.Find(x => x.User.Id == id);
        }

        public int getIdByNameAndSurname(string name, string surname)
        {
            readJson();
            int id = int.MinValue;
            id = doctors.FindIndex(obj => obj.User.Name == name && obj.User.Surname == surname);
            return id;
        }

        public bool saveAndUpdate(Doctor doctor)
        {
            doctors.Add(doctor);
            writeToJson();
            return true;
        }

        public bool delete(int id)
        {
            readJson();
            int idx = doctors.FindIndex(x => x.User.Id == id);
            doctors.RemoveAt(idx);
            writeToJson();

            return true;
        }

        public List<string> nameSurnameSpec()
        {
            readJson();
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
