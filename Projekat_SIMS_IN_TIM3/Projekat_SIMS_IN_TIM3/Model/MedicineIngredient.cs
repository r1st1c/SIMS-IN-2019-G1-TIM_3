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
        public MedicineIngredient()
        {

        }
        ~MedicineIngredient()
        {

        }
        private int _id;
        private string _name;
        public int Id
        {
            get
            { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        public string Name
        {
            get
            { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public override string? ToString()
        {
            return this.Name;
        }
    }
}
