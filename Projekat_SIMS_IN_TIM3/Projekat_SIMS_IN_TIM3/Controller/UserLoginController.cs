using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class UserLoginController
    {
        private AuthService user1 = new AuthService();
        public (Boolean,int) ValidLogin(UserLogin user)
        {
            return user1.ValidLogin(user);
        }

        public void DeleteLogIn(String Username)
        {
            user1.DeleteLogIn(Username);
        }

    }
}
