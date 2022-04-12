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
    public class UserRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\users.json";
        private List<User> users = new List<User>();
        public UserRepository()
        {
            ReadJson();
        }

        private void ReadJson()
        {
            if (!File.Exists(fileLocation))
            {
                File.Create(fileLocation).Close();
            }
            
            using (StreamReader sr = new StreamReader(fileLocation))
            {
                string line = sr.ReadLine();
                if(line != "")
                {
                    users = JsonConvert.DeserializeObject<List<User>>(line);
                }
            }
        }

        public void WriteJson()
        {
            string json = JsonConvert.SerializeObject(users);
            File.WriteAllText(fileLocation, json);
        }

        public List<User> GetAll()
        {
            ReadJson();
            return users;
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Create(User user)
        {
            users.Add(user);
            WriteJson();

            return true;
        }
        
        public bool Update(User user)
        {
            users.Add(user);
            WriteJson();
            
            return true;
        }

        public bool Delete(int id)
        {
            ReadJson();
            int index  = users.FindIndex(obj => obj.Id == id);
            users.RemoveAt(index);
            WriteJson();

            return true;
        }

    }
}
