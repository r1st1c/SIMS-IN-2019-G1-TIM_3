using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class DoctorGradeDTO
    {
       /*  "KnowledgeGrades": [],
        "HelpfulnessGrades": [],
        "PunctualityGrades": [],
        "PleasantnessGrades": []*/
        public int KnowledgeGrade { get; set; }
        public int HelpfulnessGrade { get; set; }
        public int PunctualityGrade { get; set; }
        public int PleasantnessGrade { get; set; }
        


        public DoctorGradeDTO(int KnowledgeGrade, int HelpfulnessGrade, int PunctualityGrade, int PleasantnessGrade)
        {
            this.KnowledgeGrade = KnowledgeGrade;
            this.HelpfulnessGrade = HelpfulnessGrade;
            this.PunctualityGrade = PunctualityGrade;
            this.PleasantnessGrade = PleasantnessGrade;
        }
    }
}
