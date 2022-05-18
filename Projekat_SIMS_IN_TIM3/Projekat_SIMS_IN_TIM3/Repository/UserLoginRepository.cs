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
    public class UserLoginRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\usersLogin.json";//Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\usersLogin.json";
        public (Boolean,int) ValidLogin(UserLogin userLogin)
        {
            /*string[] cred = System.IO.File.ReadAllLines(fileLocation);
            foreach (string credStr in cred)
            {
                string[] arr = credStr.Split(';');

                if (credStr == "")
                {
                    continue;
                }

                if ( userLogin.Username == arr[0] && userLogin.Password == arr[1])
                {
                    return (true,Int32.Parse(arr[2]));
                }
            }*/

            foreach(UserLogin ul in logIns)
            {
                if(ul.Username == userLogin.Username && ul.Password==userLogin.Password)
                {
                    return (true, ul.Role);
                }
            }

            return (false,-1);
        }
        public UserLoginRepository()
        {
            ReadJson();
        }

        public List<UserLogin> logIns { get; set; } = new List<UserLogin>();

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
                    logIns = JsonConvert.DeserializeObject<List<UserLogin>>(json);
                }
            }
        }

        public void DeleteLogIn(string Username)
        {
            ReadJson();
            int index = logIns.FindIndex(obj => obj.Username == Username);
            logIns.RemoveAt(index);
            WriteToJson();
        }

        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(logIns);
            File.WriteAllText(fileLocation, json);
        }
    }
}
