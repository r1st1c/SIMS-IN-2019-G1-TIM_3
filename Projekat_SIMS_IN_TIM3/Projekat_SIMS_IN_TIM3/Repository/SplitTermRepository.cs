using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Projekat_SIMS_IN_TIM3.Model;

namespace Projekat_SIMS_IN_TIM3.Repository;

public class SplitTermRepository
{
    private readonly string roomsplitpath =
        Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\room_split.csv";

    /// 
    /// SPLITTING
    public bool ScheduleSplit(SplitRenovationTerm splitRenovationTerm)
    {
        string fileName = roomsplitpath;
        if (File.Exists(fileName))
        {
            string data = splitRenovationTerm.RoomToSplitId + "," +
                          splitRenovationTerm.NewRoomName1 + "," +
                          splitRenovationTerm.NewRoomName2 + "," +
                          splitRenovationTerm.NewRoomDescription1 + "," +
                          splitRenovationTerm.NewRoomDescription2 + "," +
                          splitRenovationTerm.NewRoomType1 + "," +
                          splitRenovationTerm.NewRoomType2 + "," +
                          splitRenovationTerm.Range.Start.ToShortDateString() + "," +
                          splitRenovationTerm.Range.End.ToShortDateString() +
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
                DateTime.ParseExact(data[7], "dd-MMM-yy", null),
                DateTime.ParseExact(data[8], "dd-MMM-yy", null)
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
            if (Int32.Parse(data[0]) == splitRenovationTerm.RoomToSplitId &&
                splitRenovationTerm.Range.Start.ToShortDateString() == data[7] &&
                splitRenovationTerm.Range.End.ToShortDateString() == data[8])
            {
                csvLines[i] = "";
            }
        }

        File.WriteAllLines(roomsplitpath, csvLines);
    }
}