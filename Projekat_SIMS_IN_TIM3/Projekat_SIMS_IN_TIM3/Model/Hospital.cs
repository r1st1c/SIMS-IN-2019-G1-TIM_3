using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class Hospital
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

      

        public Hospital()
        { }

        public Hospital(string Name, string Address, string PhoneNumber)
        {
            this.Name = Name;
            this.Address = Address; 
            this.PhoneNumber = PhoneNumber;
        }
    }
}
