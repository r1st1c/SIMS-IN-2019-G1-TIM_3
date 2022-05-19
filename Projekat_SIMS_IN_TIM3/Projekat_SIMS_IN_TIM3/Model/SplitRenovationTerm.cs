using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class SplitRenovationTerm
    {
        public SplitRenovationTerm(
            DateTime start, 
            DateTime end, 
            int roomtosplitid, 
            int duration, 
            string newroomname1, 
            string newroomname2, 
            RoomType newroomtype1, 
            RoomType newroomtype2, 
            string newroomdescription1, 
            string newroomdescription2)
        {
            Range = new DateRange(start, end);
            Roomtosplitid = roomtosplitid;
            Duration = duration;
            Newroomname1 = newroomname1;
            Newroomname2 = newroomname2;
            Newroomtype1 = newroomtype1;
            Newroomtype2 = newroomtype2;
            Newroomdescription1 = newroomdescription1;
            Newroomdescription2 = newroomdescription2;
        }
        public SplitRenovationTerm(int id, int toSplitId, string roomName1, string roomName2, string roomDescription1, string roomDescription2, RoomType roomType1, RoomType roomType2, DateTime start, DateTime end)
        {
            Id = id;
            Roomtosplitid = toSplitId;
            Newroomname1 = roomName1;
            Newroomname2 = roomName2;
            Newroomdescription1 = roomDescription1;
            Newroomdescription2 = roomDescription2;
            Newroomtype1 = roomType1;
            Newroomtype2 = roomType2;
            Range = new DateRange(start, end);
        }
        public SplitRenovationTerm(int toSplitId, string roomName1, string roomName2, string roomDescription1, string roomDescription2, RoomType roomType1, RoomType roomType2, DateTime start, DateTime end)
        {
            Newroomname1 = roomName1;
            Newroomname2 = roomName2;
            Roomtosplitid = toSplitId;
            Newroomdescription1 = roomDescription1;
            Newroomdescription2 = roomDescription2;
            Newroomtype1 = roomType1;
            Newroomtype2 = roomType2;
            Range = new DateRange(start, end);
        }

        public int Id { get; set; }
        public DateRange Range { get; set; }
        public int Roomtosplitid { get; set; }
        public int Duration { get; set; }
        public string Newroomname1 { get; set; }    
        public string Newroomname2 { get; set; }
        public RoomType Newroomtype1 { get; set; }
        public RoomType Newroomtype2 { get; set; }
        public string Newroomdescription1 { get; set; }
        public string Newroomdescription2 { get; set; }

    }
}
