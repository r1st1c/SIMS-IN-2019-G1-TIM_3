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
    public class GuestRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\guests.json";
        public List<Guest> guests = new List<Guest>();

        public GuestRepository()
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
                    guests = JsonConvert.DeserializeObject<List<Guest>>(json);
                }
            }
        }

        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(guests);
            File.WriteAllText(fileLocation, json);
        }
      
        public bool Create(Guest guest)
        {
            ReadJson();
            guests.Add(guest);
            WriteToJson();
            return true;
        }

    }
}
