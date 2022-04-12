using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class UserController
    {
        public List<User> GetAll()
        {
            return this.userService.GetAll();
        }

        public User GetById(int id)
        {
            return this.GetById(id);
        }

        public bool Create(User user)
        {
            return this.userService.Create(user);
        }
        
        public bool Update(User user)
        {
            return this.userService.Update(user);
        }

        public bool Delete(int id)
        {
            return this.userService.Delete(id);
        }

        public UserService userService = new UserService();

    }
}
