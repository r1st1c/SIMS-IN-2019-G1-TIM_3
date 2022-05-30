using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Projekat_SIMS_IN_TIM3.Model;

namespace Projekat_SIMS_IN_TIM3.Repository;

public class MergeTermRepository
{
    private readonly string roommergepath =
        Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\room_merge.csv";

    /// 
    /// MERGING
    public bool ScheduleMerge(MergeRenovationTerm mergeRenovationTerm)
    {
        string fileName = roommergepath;
        if (File.Exists(fileName))
        {
            string data = mergeRenovationTerm.RoomId1 + "," + mergeRenovationTerm.RoomId2 + "," +
                          mergeRenovationTerm.Range.Start.ToShortDateString() +
                          "," + mergeRenovationTerm.Range.End.ToShortDateString() + "," + mergeRenovationTerm.Name +
                          "," + mergeRenovationTerm.RoomType + "," + mergeRenovationTerm.Description + "\n";
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
                DateTime.ParseExact(data[2], "dd-MMM-yy", null),
                DateTime.ParseExact(data[3], "dd-MMM-yy", null),
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
            if (Int32.Parse(data[0]) == renovationTerm.RoomId1 && renovationTerm.RoomId2 == Int32.Parse(data[1]) &&
                renovationTerm.Range.Start.ToShortDateString() == data[2] &&
                renovationTerm.Range.End.ToShortDateString() == data[3])
            {
                csvLines[i] = "";
            }
        }

        File.WriteAllLines(roommergepath, csvLines);
    }
}