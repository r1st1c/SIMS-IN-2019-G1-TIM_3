using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class UserService
    {
        public List<User> GetAll()
        {
            return this.userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return this.userRepository.GetById(id);
        }

        public bool Create(User user)
        {
            return this.userRepository.Create(user);
        }
        
        public bool Update(User user)
        {
            return this.userRepository.Update(user);   
        }

        public bool Delete(int id)
        {
            return this.userRepository.Delete(id);
        }

        public UserRepository userRepository = new UserRepository();

    }
}
