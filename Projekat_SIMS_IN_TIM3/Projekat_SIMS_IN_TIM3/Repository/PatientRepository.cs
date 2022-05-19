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
    public class PatientRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\patients.json";//Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\doctors.json";
        private List<Patient> patients = new List<Patient>();

        public PatientRepository()
        {
            ReadJson();
        }

        public void ReadJson()
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
                    patients = JsonConvert.DeserializeObject<List<Patient>>(json);
                }
            }
        }
        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(patients);
            File.WriteAllText(fileLocation, json);
        }

        public List<Patient> GetAll()
        {
            ReadJson();
            return patients;
        }

        public Patient GetById(int id)
        {
            ReadJson();
            return patients.Find(obj => obj.User.Id == id);
        }

        public int getIdByNameAndSurname(string name, string surname)
        {
            ReadJson();
            int id = int.MinValue;
           // id = patients.FindIndex(obj => obj.User.Name == name && obj.User.Surname == surname);
            id = patients.Find(obj => obj.User.Name == name && obj.User.Surname == surname).User.Id;
            return id;
        }

        public bool Save(Patient patient)
        {

            patients.Add(patient);
            WriteToJson();
            return true;
        }

        public bool Delete(int id)
        {
            ReadJson();
            int index = patients.FindIndex(obj => obj.User.Id == id);
            patients.RemoveAt(index);
            WriteToJson();
            return true;
        }

        public List<string> nameSurname()
        {
            ReadJson();
            List<string> ls = new List<string>();

                foreach(Patient pat in patients)
            {
                string retVal = pat.User.Name + " " + pat.User.Surname;
                ls.Add(retVal);
            }

                return ls;
        }

        public string getName(int id)
        {
            ReadJson();
            return patients.Find(obj => obj.User.Id == id).User.Name;   
        }

        public string getSurname(int id)
        {
            ReadJson();
            return patients.Find(obj => obj.User.Id ==id).User.Surname;
        }

        public DateTime getDateOfBirth(int id)
        {
            ReadJson();
            return patients.Find(obj => obj.User.Id ==id).User.DateOfBirth;
        }

        public string getJMBG(int id)
        {
            ReadJson();
            return patients.Find(obj => obj.User.Id == id).User.Jmbg;
        }

        public string getAddress(int id)
        {
            ReadJson();
            return patients.Find(obj => obj.User.Id == id).User.Address;
        }

        public string getEmail(int id)
        {
            ReadJson();
            return patients.Find(obj => obj.User.Id == id).User.Email;
        }

        public string getTelNumber(int id)
        {
            ReadJson();
            return patients.Find(obj => obj.User.Id == id).User.Phone;
        }

      

    }
}
