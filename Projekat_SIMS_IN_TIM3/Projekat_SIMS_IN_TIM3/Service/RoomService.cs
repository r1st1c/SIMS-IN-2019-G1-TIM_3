using Projekat_SIMS_IN_TIM3.ManagerWindows;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Service
{
    public class RoomService
    {
        public int GetMaxId()
        {
            return this.roomRepository.NextId();
        }

        public Room GetById(int id)
        {
            return this.roomRepository.GetById(id);
        }

        public Room GetByName(string name)
        {
            var list = this.roomRepository.GetAll();
            foreach (var item in list)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }

            Debug.WriteLine("Room not found!");
            return null;
        }

        public List<Room> GetAll()
        {
            return this.roomRepository.GetAll();
        }

        public (bool, bool) Create(Room room)
        {
            var list = this.roomRepository.GetAll();
            foreach (var existingRoom in list)
            {
                if (existingRoom.Name == room.Name)
                {
                    return (false, false);
                }
            }

            return (this.roomRepository.Create(room), true);
        }

        public bool UpdateUsingSameName(Room room)
        {
            return this.roomRepository.Update(room);
        }

        public bool UpdateUsingNewName(Room room)
        {
            var list = this.roomRepository.GetAll();
            foreach (var existingRoom in list)
            {
                if (existingRoom.Name == room.Name)
                {
                    return false;
                }
            }

            return this.roomRepository.Update(room);
        }

        public bool DeleteById(int id)
        {
            this.equipmentRepository.MoveEquipmentToDefaultRoomAfterDeletingRoom(id);
            return this.roomRepository.DeleteById(id);
        }

        private RoomRepository roomRepository;
        private EquipmentRepository equipmentRepository;

        public RoomService(RoomRepository roomRepository, EquipmentRepository equipmentRepository)
        {
            this.roomRepository = roomRepository;
            this.equipmentRepository = equipmentRepository;
        }
    }
}