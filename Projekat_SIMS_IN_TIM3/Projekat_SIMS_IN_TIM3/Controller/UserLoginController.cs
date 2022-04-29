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
        private UserLoginService user1 = new UserLoginService();
        public Boolean ValidLogin(UserLogin user)
        {
            return user1.ValidLogin(user);
        }
        
           
        
    }
}
