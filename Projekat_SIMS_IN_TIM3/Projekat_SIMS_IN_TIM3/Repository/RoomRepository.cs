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

        private readonly string roomspath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\rooms.csv";
        private readonly string roombasicrenovationpath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\room_basic_renovation.csv";
        private readonly string roommergepath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\room_merge.csv";
        private readonly string roomsplitpath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\room_split.csv";

        /// PATHS
        /// 
        ///////////////////////////////////////////////////////////////////////////////// 
        /// 
        /// CRUD
        public int next_id()
        {
            string[] csvLines = File.ReadAllLines(roomspath);
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
            string[] csvLines = File.ReadAllLines(roomspath);
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
                    renovating = "Merging";
                }
                else if (Int32.Parse(data[5]) == 3)
                {
                    renovating = "Splitting";
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
            string fileName = roomspath;
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
            string[] csvLines = File.ReadAllLines(roomspath);
            csvLines[room.Id] = room.Id + "," + room.Name + "," + room.RoomType + "," + room.Floor + "," + room.Description + "," + room.Disabled;
            File.WriteAllLines(roomspath, csvLines);
            return true;
        }
      
      public bool DeleteById(int id)
      {
            string[] csvLines = File.ReadAllLines(roomspath);
            csvLines[id] = "";
            File.WriteAllLines(roomspath, csvLines);
            return true;
        }
        /// CRUD
        /// 
        ///////////////////////////////////////////////////////////////////////////////// 
        /// 
        /// LOGIC BEHIND BASIC RENOVATION

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
            string fileName = roombasicrenovationpath;
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
            string[] csvLines = File.ReadAllLines(roombasicrenovationpath);
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
            string[] csvLines = File.ReadAllLines(roombasicrenovationpath);
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
            File.WriteAllLines(roombasicrenovationpath, csvLines);

        }


        /// LOGIC BEHIND BASIC RENOVATION
        /// 
        ///////////////////////////////////////////////////////////////////////////////// 
        /// 
        /// LOGIC BEHIND MERGING
        public bool ScheduleMerge(MergeRenovationTerm mergeRenovationTerm)
      {
          var room1 = this.GetById(mergeRenovationTerm.RoomId1);
          var room2 = this.GetById(mergeRenovationTerm.RoomId2);
          if (DateTime.Now >= DateTime.ParseExact(mergeRenovationTerm.StartingDate, "dd-MMM-yy", null) 
              && DateTime.Now <= DateTime.ParseExact(mergeRenovationTerm.EndingDate, "dd-MMM-yy", null))
          {
              room1.Disabled = 2;
              room2.Disabled = 2;
              this.Update(room1);
              this.Update(room2);
          }
          string fileName = roommergepath;
          if (File.Exists(fileName))
          {
              string data = mergeRenovationTerm.RoomId1 + "," + mergeRenovationTerm.RoomId2 + "," + mergeRenovationTerm.StartingDate + 
                            "," + mergeRenovationTerm.EndingDate + "," + mergeRenovationTerm.Name +"," + mergeRenovationTerm.RoomType + "," + mergeRenovationTerm.Description + "\n";
              File.AppendAllText(fileName, data);
              return true;
          }
          Debug.Write("Csv file doesnt exist");
          return false;
        }

      public List<MergeRenovationTerm> GetMergeSchedules()
      {
          string[] csvLines = File.ReadAllLines(roommergepath);
          List<MergeRenovationTerm> list = new List<MergeRenovationTerm>();
          for (int i = 0; i < csvLines.Length; i++)
          {
              if (csvLines[i] == "")
              {
                  continue;
              }
              string[] data = csvLines[i].Split(',');
              list.Add(new MergeRenovationTerm(
                  Int32.Parse(data[0]),
                  Int32.Parse(data[1]),
                  data[2],
                  data[3],
                  data[6],
                  data[4], 
                  Enum.Parse<RoomType>(data[5])
              ));
          }
          return list;
      }
      public void DeleteMergeScheduling(MergeRenovationTerm renovationTerm)
      {
          string[] csvLines = File.ReadAllLines(roommergepath);
          for (int i = 0; i < csvLines.Length; i++)
          {
              if (csvLines[i] == "")
              {
                  continue;
              }
              string[] data = csvLines[i].Split(',');
              if (Int32.Parse(data[0]) == renovationTerm.RoomId1 && renovationTerm.RoomId2 == Int32.Parse(data[1]) && renovationTerm.StartingDate == data[2] && renovationTerm.EndingDate == data[3])
              {
                  csvLines[i] = "";
              }
          }
          File.WriteAllLines(roommergepath, csvLines);
      }
        /// LOGIC BEHIND MERGING
        /// 
        /////////////////////////////////////////////////////////////////////////////////
        /// 
        /// LOGIC BEHIND SPLITTING
        public bool ScheduleSplit(SplitRenovationTerm splitRenovationTerm)
        {
            var room = this.GetById(splitRenovationTerm.RoomToSplitId);
            if (DateTime.Now >= DateTime.ParseExact(splitRenovationTerm.StartingDate, "dd-MMM-yy", null)
                && DateTime.Now <= DateTime.ParseExact(splitRenovationTerm.EndingDate, "dd-MMM-yy", null))
            {
                room.Disabled = 3;
                this.Update(room);
            }
            string fileName = roomsplitpath;
            if (File.Exists(fileName))
            {
                string data = splitRenovationTerm.RoomToSplitId + "," + 
                    splitRenovationTerm.RoomName1 + "," + 
                    splitRenovationTerm.RoomName2 + "," + 
                    splitRenovationTerm.RoomDescription1 + "," +
                    splitRenovationTerm.RoomDescription2 + "," +
                    splitRenovationTerm.RoomType1 + "," +
                    splitRenovationTerm.RoomType2 + "," +
                    splitRenovationTerm.StartingDate + "," +
                    splitRenovationTerm.EndingDate + 
                    "\n";
                File.AppendAllText(fileName, data);
                return true;
            }
            Debug.Write("Csv file doesnt exist");
            return false;
        }
        
        public List<SplitRenovationTerm> GetSplitSchedules()
        {
            string[] csvLines = File.ReadAllLines(roomsplitpath);
            List<SplitRenovationTerm> list = new List<SplitRenovationTerm>();
            for (int i = 0; i < csvLines.Length; i++)
            {
                if (csvLines[i] == "")
                {
                    continue;
                }
                string[] data = csvLines[i].Split(',');
                list.Add(new SplitRenovationTerm(
                    Int32.Parse(data[0]),
                    data[1],
                    data[2],
                    data[3],
                    data[4],
                    Enum.Parse<RoomType>(data[5]),
                    Enum.Parse<RoomType>(data[6]),
                    data[7],
                    data[8]
                    ));
            }
            return list;
        }
        
        public void DeleteSplitScheduling(SplitRenovationTerm splitRenovationTerm)
        {
            string[] csvLines = File.ReadAllLines(roomsplitpath);
            for (int i = 0; i < csvLines.Length; i++)
            {
                if (csvLines[i] == "")
                {
                    continue;
                }
                string[] data = csvLines[i].Split(',');
                if (Int32.Parse(data[0]) == splitRenovationTerm.RoomToSplitId && splitRenovationTerm.StartingDate == data[2] && splitRenovationTerm.EndingDate == data[3])
                {
                    csvLines[i] = "";
                }
            }
            File.WriteAllLines(roomsplitpath, csvLines);
        }
    }
    
}

