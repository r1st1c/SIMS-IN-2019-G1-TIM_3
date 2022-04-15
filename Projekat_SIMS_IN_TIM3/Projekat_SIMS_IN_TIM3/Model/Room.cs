using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    public class Room : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private int id;
        private string name;
        private RoomType roomType;
        private uint floor;
        private string description;

        public Room(int id, string name, RoomType roomType, uint floor, string description)
        {
            this.id = id;
            this.name = name;
            this.roomType = roomType;
            this.floor = floor;
            this.description = description;

        }




        public int Id
        {
            get
            { return id; }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        public string Name
        {
            get
            { return name; }
            set
            {
                if(value != name)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public RoomType RoomType
        {
            get
            { return roomType; }
            set
            {
                if (value != roomType)
                {
                    roomType = value;
                    OnPropertyChanged("RoomType");
                }
            }

        }
        public uint Floor
        {
            get
            { return floor; }
            set
            {
                if (value != floor)
                {
                    floor = value;
                    OnPropertyChanged("Floor");
                }
            }

        }
        public string Description
        {
            get
            { return description; }
            set
            {
                if (value != description)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }

        }

 

    }
}
