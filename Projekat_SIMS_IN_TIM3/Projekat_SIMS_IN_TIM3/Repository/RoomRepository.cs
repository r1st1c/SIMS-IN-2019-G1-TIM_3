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
        private readonly string roomspath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName +
                                            "\\Data\\rooms.csv";

        private readonly string roombasicrenovationpath =
            Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName +
            "\\Data\\room_basic_renovation.csv";
        
        /// PATHS
        /// 
        ///////////////////////////////////////////////////////////////////////////////// 
        /// 
        /// CRUD
        public int NextId()
        {
            string[] csvLines = File.ReadAllLines(roomspath);
            return csvLines.Length;
        }

        public Room GetById(int id)
        {
            List<Room> allRooms = this.GetAll();
            foreach (Room room in allRooms)
            {
                if (room.Id == id)
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
                if (csvLines[i] == "")
                {
                    continue;
                }

                string[] data = csvLines[i].Split(',');

                string renovating;
                if (Int32.Parse(data[5]) == 0)
                {
                    renovating = "No";
                }
                else if (Int32.Parse(data[5]) == 1)
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
                string data = NextId() + "," + room.Name + "," + room.RoomType + "," + room.Floor + "," +
                              room.Description + "," + "0" + "\n";
                File.AppendAllText(fileName, data);
                return true;
            }

            Debug.Write("Csv file doesnt exist");
            return false;
        }

        public bool Update(Room room)
        {
            string[] csvLines = File.ReadAllLines(roomspath);
            csvLines[room.Id] = room.Id + "," + room.Name + "," + room.RoomType + "," + room.Floor + "," +
                                room.Description + "," + room.Disabled;
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
        /// BASIC RENOVATION
        public bool ScheduleRenovation(int roomId, string start, string end, string description)
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
                if (Int32.Parse(data[0]) == renovationTerm.id && renovationTerm.startDate == data[1] &&
                    renovationTerm.endDate == data[2])
                {
                    csvLines[i] = "";
                }
            }

            File.WriteAllLines(roombasicrenovationpath, csvLines);
        }
    }
}