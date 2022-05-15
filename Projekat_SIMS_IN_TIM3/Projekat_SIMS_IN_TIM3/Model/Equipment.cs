using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public enum EquipmentType
    {
        static_equipment,
        dynamic_equipment
    }
    public class Equipment : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private int id;
        private string equipmentName;
        private string manufacturer;
        private EquipmentType equipmenttype;
        private int roomId;
        private int amount;
        private string roomName;

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
        public string Equipmentname
        {
            get
            { return equipmentName; }
            set
            {
                if (value != equipmentName)
                {
                    equipmentName = value;
                    OnPropertyChanged("Equipmentname");
                }
            }
        }
        public string Manufacturer
        {
            get
            { return manufacturer; }
            set
            {
                if (value != manufacturer)
                {
                    manufacturer = value;
                    OnPropertyChanged("Manufacturer");
                }
            }
        }
        public EquipmentType Equipmenttype
        {
            get
            { return equipmenttype; }
            set
            {
                if (value != equipmenttype)
                {
                    equipmenttype = value;
                    OnPropertyChanged("Equipmenttype");
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
        public int Amount
        {
            get
            { return amount; }
            set
            {
                if (value != amount)
                {
                    amount = value;
                    OnPropertyChanged("Amount");
                }
            }
        }
        public string RoomName
        {
            get
            { return roomName; }
            set
            {
                if (value != roomName)
                {
                    roomName = value;
                    OnPropertyChanged("RoomName");
                }
            }
        }


        public Equipment(int id,string equipmentname,string manufacturer, EquipmentType equipmentType,int amount, int roomId)
        {
            Id = id;
            Equipmentname = equipmentname;
            Manufacturer = manufacturer;
            Equipmenttype = equipmentType;
            Amount = amount;
            RoomId = roomId;
        }


    }
}
