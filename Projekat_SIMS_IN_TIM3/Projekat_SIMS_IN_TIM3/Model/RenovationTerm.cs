using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class RenovationTerm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int id;
        private int roomId;
        private DateRange range;
        private int duration;
        private string description;

        public RenovationTerm(int roomId, DateTime start, DateTime end, int duration, string description)
        {
            this.RoomId = roomId;
            this.Range = new DateRange(start, end);
            this.Duration = duration;
            this.Description = description;
        }
        public RenovationTerm(int roomId, DateTime start, DateTime end, string description)
        {
            this.RoomId = roomId;
            this.Range = new DateRange(start, end);
            this.Description = description;
        }
        public RenovationTerm(int id, int roomId, DateTime start, DateTime end, string description)
        {
            this.Id = id;
            this.RoomId = roomId;
            this.Range = new DateRange(start, end);
            this.Description = description;
        }



        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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
        public int RoomId
        {
            get
            { return roomId; }
            set
            {
                if (value != roomId)
                {
                    roomId = value;
                    OnPropertyChanged("RoomId");
                }
            }
        }

        public DateRange Range
        {
            get
            { return range; }
            set
            {
                if (value != range)
                {
                    range = value;
                    OnPropertyChanged("Range");
                }
            }
        }
        public int Duration
        {
            get
            { return duration; }
            set
            {
                if (value != duration)
                {
                    duration = value;
                    OnPropertyChanged("Duration");
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
