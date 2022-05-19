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

        public List<int> RoomsGrades { get; set; }
        public List<int> StaffGrades { get; set; }
        public List<int> HospitalityGrades { get; set; }
        public List<int> LocationGrades { get; set; }
        public List<int> CleanlinessGrades { get; set; }

        public Hospital()
        { }

        public Hospital(string Name, string Address, string PhoneNumber)
        {
            this.Name = Name;
            this.Address = Address; 
            this.PhoneNumber = PhoneNumber;
            this.RoomsGrades = new List<int>();
            this.StaffGrades = new List<int>();     
            this.HospitalityGrades = new List<int>();
            this.LocationGrades = new List<int>();
            this.CleanlinessGrades = new List<int>();
        }
    }
}
