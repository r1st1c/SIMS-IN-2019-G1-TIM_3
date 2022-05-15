using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class AdvancedRenovationTerm
    {
        public int Id { get; set; }
        public string StartingDate { get; set; }
        public string EndingDate { get; set; }
        public string Description { get; set; }

        public AdvancedRenovationTerm(int id, string start, string end, string description)
        {
            this.Id = id;
            this.StartingDate = start;
            this.EndingDate = end;
            this.Description = description;
        }
    }
}
