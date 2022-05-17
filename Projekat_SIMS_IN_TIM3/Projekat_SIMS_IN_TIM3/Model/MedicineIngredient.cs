using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class MedicineIngredient : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public MedicineIngredient(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public MedicineIngredient(string name)
        {
            Name = name;
        }

        private int id;
        private string name;
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
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

    }
}
