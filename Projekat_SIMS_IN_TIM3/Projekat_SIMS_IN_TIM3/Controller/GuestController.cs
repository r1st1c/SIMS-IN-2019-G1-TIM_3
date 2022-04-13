using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class GuestController
    {
        public bool Create(Guest guest)
        {
            return guestService.Create(guest);
        }
        private GuestService guestService = new GuestService();

    }
}
