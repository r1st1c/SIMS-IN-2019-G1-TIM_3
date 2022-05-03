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
        public int id;
        public string startDate;
        public string endDate;

        public RenovationTerm(int id, string startDate, string endDate)
        {
            this.Id = id;
            this.StartDate = startDate;
            this.EndDate = endDate;
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

        public string StartDate
        {
            get
            { return startDate; }
            set
            {
                if (value != startDate)
                {
                    startDate = value;
                    OnPropertyChanged("StartDate");
                }
            }
        }
        public string EndDate
        {
            get
            { return endDate; }
            set
            {
                if (value != endDate)
                {
                    endDate = value;
                    OnPropertyChanged("EndDate");
                }
            }
        }
    }
}
