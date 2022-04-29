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
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\patients.json";//Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\usersLogin.txt";
        public Boolean ValidLogin(UserLogin userLogin)
        {
            string[] cred = System.IO.File.ReadAllLines(fileLocation);
            foreach (string credStr in cred)
            {
                string[] arr = credStr.Split(';');

                if (credStr == "")
                {
                    continue;
                }

                if ( userLogin.Username == arr[0] && userLogin.Password == arr[1])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
