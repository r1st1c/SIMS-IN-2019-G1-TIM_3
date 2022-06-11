using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class Allergen
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public String Name { get; set; }
        public String Details { get; set; }

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

        public Allergen(int Id,int patietId, String Name, String Details)
        {
            this.Id = Id;
            this.PatientId = patietId;
            this.Name = Name;
            this.Details = Details;

        }

        ~Allergen()
        {
            // TODO: implement
        }

       

    }
}
