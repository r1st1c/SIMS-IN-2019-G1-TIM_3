using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class HospitalGradeDTO
    {

        /* this.RoomsGrades = new List<int>();
             this.StaffGrades = new List<int>();     
             this.HospitalityGrades = new List<int>();
             this.LocationGrades = new List<int>();
             this.CleanlinessGrades = new List<int>();*/

        public int RoomGrade { get; set; }
        public int StaffGrade { get; set; }
        public int HospitalityGrade { get; set; }
        public int LocationGrade { get; set; }
        public int CleanlinessGrade { get; set; }


        public HospitalGradeDTO(int RoomGrade, int StaffGrade, int HospitalityGrade, int LocationGrade, int CleanlinessGrade)
        {
            this.RoomGrade = RoomGrade;
            this.StaffGrade = StaffGrade;   
            this.HospitalityGrade = HospitalityGrade;
            this.LocationGrade = LocationGrade;
            this.CleanlinessGrade = CleanlinessGrade;
        }
    }
}
