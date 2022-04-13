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
            // TODO: implement
            return null;
        }

        public User GetById(String id)
        {
            // TODO: implement
            return null;
        }

        public bool Create(User user)
        {
            // TODO: implement
            return false;
        }

        public bool Update(String newEmail, String newPhoneNumber, String newAddress)
        {
            // TODO: implement
            return false;
        }

        public bool Delete(int id)
        {
            // TODO: implement
            return false;
        }

        public UserService userService;

    }
}
