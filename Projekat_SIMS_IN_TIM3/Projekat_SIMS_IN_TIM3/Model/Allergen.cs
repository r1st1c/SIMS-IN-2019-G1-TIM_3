using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class Allergen
    {
        public Allergen()
        {
            // TODO: implement
        }
        public Allergen(int Id, String Name, String Details)
        {
            this.Id = Id;
            this.Name = Name;   
            this.Details = Details;
        }

        ~Allergen()
        {
            // TODO: implement
        }

        private int Id { get; set; }
        private String Name { get; set; }
        private String Details { get; set; }

    }
}
