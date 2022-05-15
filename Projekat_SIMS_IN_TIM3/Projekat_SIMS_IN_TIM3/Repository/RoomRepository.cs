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

                string renovating;
                if(Int32.Parse(data[5]) == 0)
                {
                    renovating = "No";
                }
                else if(Int32.Parse(data[5]) == 1)
                {
                    renovating = "Basic";
                }
                else if (Int32.Parse(data[5]) == 2)
                {
                    renovating = "Advanced";
                }
                else
                {
                    renovating = "?";
                }

                list.Add(new Room(
                    Int32.Parse(data[0]),
                    data[1],
                    Enum.Parse<RoomType>(data[2]),
                    UInt32.Parse(data[3]),
                    data[4],
                    renovating
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
                string data = next_id() + "," + room.Name + "," + room.RoomType + "," + room.Floor + "," + room.Description + "," + "0" +   "\n";
                File.AppendAllText(fileName, data);
                return true;
            }
            Debug.Write("Csv file doesnt exist");
            return false;
        }
      
      public bool Update(Room room)
      {
            string[] csvLines = File.ReadAllLines(@"C:\Users\Ristic\Documents\rooms.csv");
            csvLines[room.Id] = room.Id + "," + room.Name + "," + room.RoomType + "," + room.Floor + "," + room.Description + "," + room.Disabled;
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

        public bool ScheduleRenovation(int roomId, string start, string end,string description)
        {
            var room = this.GetById(roomId);
            DateTime dateStart = DateTime.ParseExact(start, "dd-MMM-yy", null);
            DateTime dateEnd = DateTime.ParseExact(start, "dd-MMM-yy", null);
            dateEnd = dateEnd.AddHours(23);
            dateEnd = dateEnd.AddMinutes(59);
            dateEnd = dateEnd.AddSeconds(59);
            if (DateTime.Now >= dateStart && DateTime.Now <= dateEnd)
            {
                room.Disabled = 1;
                this.Update(room);
            }
            string fileName = @"C:\Users\Ristic\Documents\room_basic_renovation.csv";
            if (File.Exists(fileName))
            {
                string data = roomId + "," + start + "," + end + "," + description + "\n";
                File.AppendAllText(fileName, data);
                return true;
            }
            Debug.Write("Csv file doesnt exist");
            return false;
        }
        public List<RenovationTerm> GetRenovationSchedules()
        {
            string[] csvLines = File.ReadAllLines(@"C:\Users\Ristic\Documents\room_basic_renovation.csv");
            List<RenovationTerm> list = new List<RenovationTerm>();
            for (int i = 0; i < csvLines.Length; i++)
            {
                if (csvLines[i] == "")
                {
                    continue;
                }
                string[] data = csvLines[i].Split(',');
                list.Add(new RenovationTerm(
                    Int32.Parse(data[0]),
                    data[1],
                    data[2]
                ));
            }
            return list;
        }

        public void DeleteScheduling(RenovationTerm renovationTerm)
        {
            string[] csvLines = File.ReadAllLines(@"C:\Users\Ristic\Documents\room_basic_renovation.csv");
            for (int i = 0; i < csvLines.Length; i++)
            {
                if (csvLines[i] == "")
                {
                    continue;
                }
                string[] data = csvLines[i].Split(',');
                if (Int32.Parse(data[0])==renovationTerm.id  &&  renovationTerm.startDate==data[1]  && renovationTerm.endDate == data[2])
                {
                    csvLines[i] = "";
                }
            }
            File.WriteAllLines(@"C:\Users\Ristic\Documents\room_basic_renovation.csv", csvLines);

        }

        public bool Split(int id)
      {
         throw new NotImplementedException();
      }
      
      public bool ScheduleMerge(AdvancedRenovationTerm advancedRenovationTerm)
      {
          var room1 = this.GetById(advancedRenovationTerm.RoomId1);
          var room2 = this.GetById(advancedRenovationTerm.RoomId2);
          if (DateTime.Now >= DateTime.ParseExact(advancedRenovationTerm.StartingDate, "dd-MMM-yy", null) 
              && DateTime.Now <= DateTime.ParseExact(advancedRenovationTerm.EndingDate, "dd-MMM-yy", null))
          {
              room1.Disabled = 2;
              room2.Disabled = 2;
              this.Update(room1);
              this.Update(room2);
          }
          string fileName = @"C:\Users\Ristic\Documents\room_merge.csv";
          if (File.Exists(fileName))
          {
              string data = advancedRenovationTerm.RoomId1 + "," + advancedRenovationTerm.RoomId2 + "," + advancedRenovationTerm.StartingDate + 
                            "," + advancedRenovationTerm.EndingDate + "," + advancedRenovationTerm.Description + "\n";
              File.AppendAllText(fileName, data);
              return true;
          }
          Debug.Write("Csv file doesnt exist");
          return false;
        }

       
   
   }
}
