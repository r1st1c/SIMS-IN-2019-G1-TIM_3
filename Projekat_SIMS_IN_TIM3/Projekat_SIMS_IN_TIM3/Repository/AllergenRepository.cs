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
    public class AllergenRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\allergen.json";//Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\doctors.json";
        private List<Allergen> allergens = new List<Allergen>();

        public AllergenRepository()
        {
            ReadJson();
        }

        public void ReadJson()
        {
            if (!File.Exists(fileLocation))
            {
                File.Create(fileLocation).Close();
            }

            using (StreamReader sr = new StreamReader(fileLocation))
            {
                string json = sr.ReadToEnd();
                if(json != "")
                {
                    allergens = JsonConvert.DeserializeObject<List<Allergen>>(json);
                }
            }
        }

        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(allergens);
            File.WriteAllText(fileLocation, json);
        }

        public void Save(Allergen allergen)
        {
            ReadJson();
            allergens.Add(allergen);
            WriteToJson();
        }

        public void Update(Allergen allergen)
        {
            ReadJson();
            int index = allergens.FindIndex(obj => obj.Id == allergen.Id);
            allergens[index] = allergen;
            WriteToJson();
        }

        public void Delete(int id)
        {
            ReadJson();
            int index = allergens.FindIndex(obj => obj.Id == id);
            allergens.RemoveAt(index);
            WriteToJson();
        }

        public List<Allergen> GetByPatientsId(int id)
        {
            ReadJson();
            return allergens.FindAll(obj => obj.PatientId == id);

        }

        public List<Allergen> GetById(int id)
        {
            return allergens.FindAll(obj => obj.Id == id);
        }

        public List<Allergen> GetAll()
        {
            ReadJson();
            return allergens;
        }
    }
}
