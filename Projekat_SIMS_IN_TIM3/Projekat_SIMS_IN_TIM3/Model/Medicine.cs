using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class Medicine
    {
        public Medicine()
        {
            // TODO: implement
        }

        public Medicine(int Id, String Name, String Ingredients, bool IsVerified)
        {
            this.Id = Id;
            this.Name = Name;   
            this.Ingredients = Ingredients;
            this.IsVerified = IsVerified;
        }

        ~Medicine()
        {
            // TODO: implement
        }

        private int Id { get; set; }
        private String Name { get; set; }   
        private String Ingredients { get; set; }
        private bool IsVerified { get; set; }

    }
}
