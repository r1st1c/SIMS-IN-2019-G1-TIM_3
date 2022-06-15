using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public enum MedicineStatus
    {
        unapproved,
        approved,
        rejected
    }

    public class Medicine : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private int _id;
        private string _name;
        private List<MedicineIngredient> _ingredients;
        private MedicineStatus _isVerified;
        private string _reasonOfRejection;
        private string _replacement;

        public Medicine()
        {
            // TODO: implement
        }

        public Medicine(int id, string name, List<MedicineIngredient> ingredients, MedicineStatus isVerified,
            string replacement, string reasonOfRejection)
        {
            Id = id;
            Name = name;
            Ingredients = ingredients;
            IsVerified = isVerified;
            Replacement = replacement;
            ReasonOfRejection = reasonOfRejection;
        }

        ~Medicine()
        {
            // TODO: implement
        }


        public int Id
        {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public String Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public List<MedicineIngredient> Ingredients
        {
            get { return _ingredients; }
            set
            {
                if (value != _ingredients)
                {
                    _ingredients = value;
                    OnPropertyChanged("Ingredients");
                }
            }
        }

        public MedicineStatus IsVerified
        {
            get { return _isVerified; }
            set
            {
                if (value != _isVerified)
                {
                    _isVerified = value;
                    OnPropertyChanged("IsVerified");
                }
            }
        }

        public String ReasonOfRejection
        {
            get { return _reasonOfRejection; }
            set
            {
                if (value != _reasonOfRejection)
                {
                    _reasonOfRejection = value;
                    OnPropertyChanged("ReasonOfRejection");
                }
            }
        }

        public string Replacement
        {
            get { return _replacement; }
            set
            {
                if (value != _replacement)
                {
                    _replacement = value;
                    OnPropertyChanged("Replacement");
                }
            }
        }

        public override string? ToString()
        {
            return this.Name;
        }
    }
}