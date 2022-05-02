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
    public class RoomRepository
   {

        

        public int next_id()
        {
            string[] csvLines = File.ReadAllLines(@"C:\Users\Ristic\Documents\rooms.csv");
            return csvLines.Length;
        }

        public Room GetById(int id)
      {
            List<Room> allRooms = this.GetAll();
            foreach(Room room in allRooms)
            {
                if(room.Id == id)
                {
                    return room;
                }
            }
            return null;
      }
      
      public List<Room> GetAll()
      {
            string[] csvLines = File.ReadAllLines(@"C:\Users\Ristic\Documents\rooms.csv");
            List<Room> list = new List<Room>();
            for (int i = 0; i < csvLines.Length; i++)
            {
                if(csvLines[i] == "")
                {
                    continue;
                }
                string[] data = csvLines[i].Split(',');
                list.Add(new Room(
                    Int32.Parse(data[0]),
                    data[1],
                    Enum.Parse<RoomType>(data[2]),
                    UInt32.Parse(data[3]),
                    data[4]
                ));
                
            }
            return list;
        }
      
      public bool Create(Room room)
      {
            string fileName = @"C:\Users\Ristic\Documents\rooms.csv";
            if (File.Exists(fileName))
            {
                //RoomWindow.Rooms.Add(room);
                string data = next_id() + "," + room.Name + "," + room.RoomType + "," + room.Floor + "," + room.Description + "\n";
                File.AppendAllText(fileName, data);
                return true;
            }
            Debug.Write("Csv file doesnt exist");
            return false;
        }
      
      public bool Update(Room room)
      {
            string[] csvLines = File.ReadAllLines(@"C:\Users\Ristic\Documents\rooms.csv");
            csvLines[room.Id] = room.Id + "," + room.Name + "," + room.RoomType + "," + room.Floor + "," + room.Description;
            File.WriteAllLines(@"C:\Users\Ristic\Documents\rooms.csv", csvLines);
            return true;
        }
      
      public bool DeleteById(int id)
      {
            string[] csvLines = File.ReadAllLines(@"C:\Users\Ristic\Documents\rooms.csv");
            csvLines[id] = "";
            File.WriteAllLines(@"C:\Users\Ristic\Documents\rooms.csv", csvLines);
            return true;
        }
      
      public bool Split(int id)
      {
         throw new NotImplementedException();
      }
      
      public bool Merge(int firstId, int secondId)
      {
         throw new NotImplementedException();
      }

       
   
   }
}
