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
        private readonly string equipmentpath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\equipment.csv";
        private readonly string equipmentfuturemovepath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\equipment_future_move.csv";

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
            string[] csvLines = File.ReadAllLines(equipmentpath);
            List<Equipment> list = new List<Equipment>();
            for (int i = 0; i < csvLines.Length; i++)
            {
                if (csvLines[i] == "")
                {
                    continue;
                }
                string[] data = csvLines[i].Split(',');
                list.Add(
                            new Equipment(
                            Int32.Parse(data[0]),
                            data[1],
                            data[2],
                            Enum.Parse<EquipmentType>(data[3]),
                            Int32.Parse(data[4]),
                            Int32.Parse(data[5])
                            )
                        );
            }
            return list;
        }
        public bool Move(int equipmentId, int targetRoomId)
        {
            string[] csvLines = File.ReadAllLines(equipmentpath);
            Equipment equipment = GetById(equipmentId);
            csvLines[equipmentId] = equipment.Id + "," + equipment.Equipmentname + "," + equipment.Manufacturer + "," + equipment.Equipmenttype + "," + equipment.Amount + "," + targetRoomId;
            File.WriteAllLines(equipmentpath, csvLines);
            return true;
        }

        public bool scheduleFutureMove(int equipmentId, int targetRoomId, DateTime date)
        {

            string fileName = equipmentfuturemovepath;
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
            string[] csvLines = File.ReadAllLines(equipmentfuturemovepath);
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
                File.WriteAllLines(equipmentfuturemovepath, csvLines);
            }
            return list;
        }
        public void MoveEquipmentToDefaultRoomAfterDeletingRoom(int roomId)
        {
            string[] csvLines = File.ReadAllLines(equipmentpath);
            for (int i = 0; i < csvLines.Length; i++)
            {
                string[] data = csvLines[i].Split(',');
                int csv_equipment_roomid = Int32.Parse(data[5]);
                if (csv_equipment_roomid == roomId)
                {
                    csvLines[i] = data[0] + "," + data[1] + "," + data[2] + "," + data[3] + "," + data[4] + "," + "0";
                }
            }
            File.WriteAllLines(equipmentpath, csvLines);
        }
    }
}
