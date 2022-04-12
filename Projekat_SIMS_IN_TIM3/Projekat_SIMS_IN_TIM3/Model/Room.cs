using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public enum RoomType
    {
        operatingRoom,
        ordination,
        storage
    }

    public class Room
    {
        private String name;
        private RoomType roomType;
        private int floor;
        private String description;

        public String Name { get; set; }
        public RoomType RoomType { get; set; }
        public int Floor { get; set; }
        public String Description { get; set; }

    }
}
