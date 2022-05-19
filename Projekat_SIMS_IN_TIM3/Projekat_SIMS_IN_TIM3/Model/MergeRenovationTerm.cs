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
        public int RoomId1 { get; set; }
        public int RoomId2 { get; set; }
        public string StartingDate { get; set; }
        public string EndingDate { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public RoomType RoomType { get; set; }

        public MergeRenovationTerm(int id,int room1id, int room2id, string start, string end, string description,string name, RoomType roomType)
        {
            this.Id = id;
            this.StartingDate = start;
            this.EndingDate = end;
            this.Description = description;
            this.RoomId1 = room1id;
            this.RoomId2 = room2id;
            this.Name = name;
            this.RoomType = roomType;
        }

        public MergeRenovationTerm( int room1id, int room2id, string start, string end, string description, string name, RoomType roomType)
        {
            this.StartingDate = start;
            this.EndingDate = end;
            this.Description = description;
            this.RoomId1 = room1id;
            this.RoomId2 = room2id;
            this.Name = name;
            this.RoomType = roomType;
        }

    }
}
