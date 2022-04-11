using Projekat_SIMS_IN_TIM3.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Repository
{
    public class RoomRepository
   {
      public Room GetById(int id)
      {
         throw new NotImplementedException();
      }
      
      public List<Room> GetAll()
      {
            string[] csvLines = System.IO.File.ReadAllLines(@"W:\rooms.csv");
            List<Room> list = new List<Room>();
            for (int i = 0; i < csvLines.Length; i++)
            {
                string[] data = csvLines[i].Split(',');
                list.Add(new Room
                {
                    Name = data[0],
                    RoomType = Enum.Parse<RoomType>(data[1]),
                    Floor = Int32.Parse(data[2]),
                    Description = data[3]
                });
            }
            return list;
        }
      
      public bool Create(Room room)
      {
         throw new NotImplementedException();
      }
      
      public bool Update(Room room)
      {
         throw new NotImplementedException();
      }
      
      public bool DeleteById(int id)
      {
         throw new NotImplementedException();
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
