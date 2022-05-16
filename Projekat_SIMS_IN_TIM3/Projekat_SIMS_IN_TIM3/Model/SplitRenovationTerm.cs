using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class SplitRenovationTerm
    {
        public SplitRenovationTerm(int id,int toSplitId, string roomName1, string roomName2, string roomDescription1, string roomDescription2, RoomType roomType1, RoomType roomType2, string startingDate, string endingDate)
        {
            Id = id;
            RoomToSplitId = toSplitId;
            RoomName1 = roomName1;
            RoomName2 = roomName2;
            RoomDescription1 = roomDescription1;
            RoomDescription2 = roomDescription2;
            RoomType1 = roomType1;
            RoomType2 = roomType2;
            StartingDate = startingDate;
            EndingDate = endingDate;
        }
        public SplitRenovationTerm(int toSplitId, string roomName1, string roomName2, string roomDescription1, string roomDescription2, RoomType roomType1, RoomType roomType2, string startingDate, string endingDate)
        {
            RoomName1 = roomName1;
            RoomName2 = roomName2;
            RoomToSplitId = toSplitId;
            RoomDescription1 = roomDescription1;
            RoomDescription2 = roomDescription2;
            RoomType1 = roomType1;
            RoomType2 = roomType2;
            StartingDate = startingDate;
            EndingDate = endingDate;
        }

        public int Id { get; set; }
        public int RoomToSplitId { get; set; }
        public string RoomName1 { get; set; }
        public string RoomName2 { get; set; }
        public string RoomDescription1 { get; set; }
        public string RoomDescription2 { get; set; }
        public RoomType RoomType1 { get; set; }
        public RoomType RoomType2 { get; set; }
        public string StartingDate { get; set; }
        public string EndingDate { get; set; }

    }
}
