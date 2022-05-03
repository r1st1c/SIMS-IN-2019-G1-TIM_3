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
                string retVal = pat.User.Name + "" + pat.User.Surname;
                ls.Add(retVal);
            }

                return ls;
        }

        public string getName(int id)
        {
            ReadJson();
            string retVal = "";
            foreach(Patient pat in patients)
            {
                retVal = pat.User.Name;
            }

            return retVal;
        }

        public string getSurname(int id)
        {
            ReadJson();
            string retVal = "";
            foreach (Patient pat in patients)
            {
                retVal = pat.User.Surname;
            }

            return retVal;
        }

        public DateTime getDateOfBirth(int id)
        {
            ReadJson();
            DateTime retVal = DateTime.MinValue;
            foreach (Patient pat in patients)
            {
                retVal = pat.User.DateOfBirth;
            }

            return retVal;
        }

        public string getJMBG(int id)
        {
            ReadJson();
            string retVal = "";
            foreach (Patient pat in patients)
            {
                retVal = pat.User.Jmbg;
            }

            return retVal;
        }

        public string getAddress(int id)
        {
            ReadJson();
            string retVal = "";
            foreach (Patient pat in patients)
            {
                retVal = pat.User.Address;
            }

            return retVal;
        }

        public string getEmail(int id)
        {
            ReadJson();
            string retVal = "";
            foreach (Patient pat in patients)
            {
                retVal = pat.User.Email;
            }

            return retVal;
        }

        public string getTelNumber(int id)
        {
            ReadJson();
            string retVal = "";
            foreach (Patient pat in patients)
            {
                retVal = pat.User.Phone;
            }

            return retVal;
        }

    }
}
