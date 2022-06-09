using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class AnamnesisDTO
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string DateAndTime { get; set; }

        public string PerceivedDifficulties { get; set; }

        public string GeneralConclusion { get; set; }

        public AnamnesisDTO(int Id, string DoctorName, string DateAndTime, string PerceivedDifficulties, string GeneralConclusion)
        {
            this.Id = Id;
            this.DoctorName = DoctorName;
            this.DateAndTime = DateAndTime;
            this.PerceivedDifficulties = PerceivedDifficulties;
            this.GeneralConclusion = GeneralConclusion;
        }

    }
}
