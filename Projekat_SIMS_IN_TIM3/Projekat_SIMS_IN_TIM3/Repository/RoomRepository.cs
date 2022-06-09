using Projekat_SIMS_IN_TIM3.ManagerWindows;
using Projekat_SIMS_IN_TIM3.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.IRepository;

namespace Projekat_SIMS_IN_TIM3.Repository
{
    public class RoomRepository : RoomIRepository
    {
        private readonly string roomspath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName +
                                            "\\Data\\rooms.csv";
        

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
                string data = NextId() + "," + room.Name + "," + room.RoomType + "," + room.Floor + "," +
                              room.Description + "," + "0" + "\n";
                File.AppendAllText(fileName, data);
                return true;
            }

            Debug.Write("Csv file doesn't exist");
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
    }
}