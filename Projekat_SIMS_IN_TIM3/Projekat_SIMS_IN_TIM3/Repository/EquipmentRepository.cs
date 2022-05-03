using Projekat_SIMS_IN_TIM3.ManagerWindows;
using Projekat_SIMS_IN_TIM3.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Repository
{
    public class EquipmentRepository
   {
        public RoomRepository roomRepository = new RoomRepository();
      public Equipment GetById(int id)
      {
            List<Equipment> allEquipment = this.GetAll();
            foreach(Equipment equipment in allEquipment)
            {
                if(equipment.Id == id)
                {
                    return equipment;
                }
            }
            return null;
      }
      
      public List<Equipment> GetAll()
      {
            string[] csvLines = File.ReadAllLines(@"C:\Users\Ristic\Documents\equipment.csv");
            List<Equipment> list = new List<Equipment>();
            for (int i = 0; i < csvLines.Length; i++)
            {
                if (csvLines[i] == "")
                {
                    continue;
                }
                string[] data = csvLines[i].Split(',');
                var roomId = Int32.Parse(data[4]);
                string roomName;
                if (roomId == -1)
                {
                    roomName = "No room (static)";
                }
                else
                {
                    roomName = this.roomRepository.GetById(roomId).Name;
                }
                list.Add(
                            new Equipment(
                            Int32.Parse(data[0]),
                            data[1],
                            data[2],
                            Enum.Parse<EquipmentType>(data[3]),
                            Int32.Parse(data[4]),
                            roomName
                            )
                        );
            }
            return list;
        }
        public bool Move(int equipmentId, int targetRoomId)
        {
            string[] csvLines = File.ReadAllLines(@"C:\Users\Ristic\Documents\equipment.csv");
            Equipment equipment = GetById(equipmentId);
            csvLines[equipmentId] = equipment.Id + "," + equipment.Equipmentname + "," + equipment.Manufacturer + "," + equipment.Equipmenttype + "," + targetRoomId;
            File.WriteAllLines(@"C:\Users\Ristic\Documents\equipment.csv", csvLines);
            return true;
        }

        public bool scheduleFutureMove(int equipmentId, int targetRoomId, DateTime date)
        {

            string fileName = @"C:\Users\Ristic\Documents\equipment_future_move.csv";
            if (File.Exists(fileName))
            {
                //RoomWindow.Rooms.Add(room);
                string data = equipmentId + "," + targetRoomId + "," + date.ToShortDateString() + "\n";
                File.AppendAllText(fileName, data);
                return true;
            }
            Debug.Write("Csv file doesnt exist");
            return false;
        }

        public List<EquipmentMoveOrder> GetAvailableForMoving() {
            string[] csvLines = File.ReadAllLines(@"C:\Users\Ristic\Documents\equipment_future_move.csv");
            List<EquipmentMoveOrder> list = new List<EquipmentMoveOrder>();
            for (int i = 0; i < csvLines.Length; i++)
            {
                if (csvLines[i] == "")
                {
                    continue;
                }
                string[] data = csvLines[i].Split(',');
                var date = DateTime.ParseExact(data[2],"dd-MMM-yy",null);
                if (DateTime.Compare(date.Date, DateTime.Now.Date) <= 0) 
                {
                    list.Add(new EquipmentMoveOrder(
                    Int32.Parse(data[0]),
                    Int32.Parse(data[1])));
                    csvLines[i] = "";
                }
                File.WriteAllLines(@"C:\Users\Ristic\Documents\equipment_future_move.csv", csvLines);
            }
            return list;
        }
    }
}
