using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class GuestService
    {
        public bool Create(Guest guest)
        {
            guestRepository.Create(guest);
            return true;
        }

        public GuestRepository guestRepository = new GuestRepository();
    }
}
