using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Projekat_SIMS_IN_TIM3.Model;

namespace Projekat_SIMS_IN_TIM3.Repository
{
    public class HospitalRepository
    {

        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\hospital.json";
        public Hospital hospital;

        public HospitalRepository()
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
                    hospital = JsonConvert.DeserializeObject<Hospital>(json);
                }
            }
        }

        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(hospital);
            File.WriteAllText(fileLocation, json);
        }

        public void CreateHospital(Hospital hospital)
        {
            this.hospital = hospital;
            WriteToJson();
        }

        
        public void DeleteHospital()
        {

            hospital = null;
            File.Create(fileLocation).Close();
        }

        public Hospital Get()
        {
            ReadJson();
            return hospital;
        }

    }
}
