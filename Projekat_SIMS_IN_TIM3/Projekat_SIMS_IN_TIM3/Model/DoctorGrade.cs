using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class DoctorGrade
    {
    
        public int doctorId { get; set; }

        public int knowledgeGrade { get; set; }

        public int helpfulnessGrade { get; set; }

        public int punctualityGrade { get; set; }

        public int pleasantnessGrade { get ; set; }

        public DoctorGrade( int doctorId, int knowledgeGrade, int helpfulnessGrade, int punctualityGrade,
            int pleasantnessGrade)
        {
            this.doctorId= doctorId;
            this.knowledgeGrade= knowledgeGrade;
            this.helpfulnessGrade= helpfulnessGrade;
            this.punctualityGrade= punctualityGrade;
            this.pleasantnessGrade = pleasantnessGrade;
        }
    }
}
