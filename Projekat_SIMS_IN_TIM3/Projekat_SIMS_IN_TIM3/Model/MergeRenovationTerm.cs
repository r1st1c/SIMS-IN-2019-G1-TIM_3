using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class MergeRenovationTerm
    {
        public int Id { get; set; }
        public DateRange Range { get; set; }
        public int RoomId1 { get; set; }
        public int RoomId2 { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public RoomType RoomType { get; set; }

        public MergeRenovationTerm(DateTime start, DateTime end, int id1, int id2, int duration, string description,string name, RoomType roomType)
        {
            this.Range = new DateRange(start, end);
            this.RoomId1 = id1;
            this.RoomId2 = id2;
            this.Duration = duration;
            this.Description = description;
            this.Name = name;
            this.RoomType = roomType;
        }
        public MergeRenovationTerm(int id, int room1id, int room2id, DateTime start, DateTime end, string description, string name, RoomType roomType)
        {
            this.Id = id;
            this.Range = new DateRange(start, end);
            this.Description = description;
            this.RoomId1 = room1id;
            this.RoomId2 = room2id;
            this.Name = name;
            this.RoomType = roomType;
        }

        public MergeRenovationTerm(int room1id, int room2id, DateTime start, DateTime end, string description, string name, RoomType roomType)
        {
            this.Range = new DateRange(start, end);
            this.Description = description;
            this.RoomId1 = room1id;
            this.RoomId2 = room2id;
            this.Name = name;
            this.RoomType = roomType;
        }
    }
}
