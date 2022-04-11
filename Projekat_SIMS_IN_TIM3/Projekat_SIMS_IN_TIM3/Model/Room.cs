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
            if(PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(name));}
        }

        private string name;
        private RoomType roomType;
        private int floor;
        private string description;

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
        public int Floor
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
