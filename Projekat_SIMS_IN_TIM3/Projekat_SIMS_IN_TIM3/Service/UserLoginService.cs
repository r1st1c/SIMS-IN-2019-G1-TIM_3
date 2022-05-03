using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class UserLoginService
    {
        private UserLoginRepository user1 = new UserLoginRepository();

        public (Boolean,int) ValidLogin(UserLogin user)
        {
            return user1.ValidLogin(user);
        }
    }
}
