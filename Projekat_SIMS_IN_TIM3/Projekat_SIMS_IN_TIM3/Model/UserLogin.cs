using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class UserLogin
    {
        public String Username { get; set; }
        public String Password { get; set; }

        public UserLogin(string usname, string psw)
        {
            this.Password = psw;
            this.Username = usname;
        }
    }
}
