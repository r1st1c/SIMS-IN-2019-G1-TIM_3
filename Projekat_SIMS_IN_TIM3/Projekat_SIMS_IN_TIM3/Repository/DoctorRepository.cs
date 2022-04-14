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

        public List<Doctor> getAll()
        {
            readJson();
            return doctors;
        }

        public Doctor getById(int id)
        {
            readJson();
            return doctors.Find(x => x.Id == id);
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
            int idx = doctors.FindIndex(x => x.Id == id);
            doctors.RemoveAt(idx);
            writeToJson();

            return true;
        }

        
   }
}
