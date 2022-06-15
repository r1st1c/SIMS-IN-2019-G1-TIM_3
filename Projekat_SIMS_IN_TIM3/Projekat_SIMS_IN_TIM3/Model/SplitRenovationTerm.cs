using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class SplitRenovationTerm
    {
        public int Id { get; set; }
        public DateRange Range { get; set; }
        public int RoomToSplitId { get; set; }
        public int Duration { get; set; }
        public string NewRoomName1 { get; set; }
        public string NewRoomName2 { get; set; }
        public RoomType NewRoomType1 { get; set; }
        public RoomType NewRoomType2 { get; set; }
        public string NewRoomDescription1 { get; set; }
        public string NewRoomDescription2 { get; set; }

        public SplitRenovationTerm(
            DateTime start,
            DateTime end,
            int roomToSplitId,
            int duration,
            string newRoomName1,
            string newRoomName2,
            RoomType newRoomType1,
            RoomType newRoomType2,
            string newRoomDescription1,
            string newRoomDescription2)
        {
            Range = new DateRange(start, end);
            RoomToSplitId = roomToSplitId;
            Duration = duration;
            NewRoomName1 = newRoomName1;
            NewRoomName2 = newRoomName2;
            NewRoomType1 = newRoomType1;
            NewRoomType2 = newRoomType2;
            NewRoomDescription1 = newRoomDescription1;
            NewRoomDescription2 = newRoomDescription2;
        }

        public SplitRenovationTerm(int id, int toSplitId, string roomName1, string roomName2, string roomDescription1,
            string roomDescription2, RoomType roomType1, RoomType roomType2, DateTime start, DateTime end)
        {
            Id = id;
            RoomToSplitId = toSplitId;
            NewRoomName1 = roomName1;
            NewRoomName2 = roomName2;
            NewRoomDescription1 = roomDescription1;
            NewRoomDescription2 = roomDescription2;
            NewRoomType1 = roomType1;
            NewRoomType2 = roomType2;
            Range = new DateRange(start, end);
        }

        public SplitRenovationTerm(int toSplitId, string roomName1, string roomName2, string roomDescription1,
            string roomDescription2, RoomType roomType1, RoomType roomType2, DateTime start, DateTime end)
        {
            NewRoomName1 = roomName1;
            NewRoomName2 = roomName2;
            RoomToSplitId = toSplitId;
            NewRoomDescription1 = roomDescription1;
            NewRoomDescription2 = roomDescription2;
            NewRoomType1 = roomType1;
            NewRoomType2 = roomType2;
            Range = new DateRange(start, end);
        }
    }
}