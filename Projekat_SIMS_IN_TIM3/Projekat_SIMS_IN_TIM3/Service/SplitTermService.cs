using System;
using System.Collections.Generic;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;

namespace Projekat_SIMS_IN_TIM3.Service;

public class SplitTermService
{
    private SplitTermRepository SplitTermRepository;
    private AppointmentRepository AppointmentRepository;
    private RoomRepository RoomRepository;

    public SplitTermService(SplitTermRepository splitTermRepository, AppointmentRepository appointmentRepository,
        RoomRepository roomRepository)
    {
        this.SplitTermRepository = splitTermRepository;
        this.AppointmentRepository = appointmentRepository;
        this.RoomRepository = roomRepository;
    }
    public List<SplitRenovationTerm> GetSplitRenovationAvailableTerms(SplitRenovationTerm splitRenovationQuery)// 1/4 Main Function
    {
        var dates = new List<DateTime>();

        FillInAllDays(splitRenovationQuery, dates);

        List<Appointment> appointments = AppointmentRepository.GetAll();

        FindAvailableDays(splitRenovationQuery, dates, appointments);

        var available = new List<SplitRenovationTerm>();
        FindAvailableTerms(splitRenovationQuery, dates, available);
        return available;
    }

    private static void FindAvailableTerms(SplitRenovationTerm splitRenovationQuery, List<DateTime> dates,
        List<SplitRenovationTerm> available)
    {
        splitRenovationQuery
            .Duration--; //first day is already included so we subtract that day from total amount of days
        int renovationId = 0;

        for (int i = 0; i < dates.Count - splitRenovationQuery.Duration; i++)
        {
            if (StartDayPlusDurationIsEndDay(splitRenovationQuery, dates, i))
            {
                renovationId = AddAvailableTerm(splitRenovationQuery, dates, available, renovationId, i);
            }
        }
    }

    private static int AddAvailableTerm(SplitRenovationTerm splitRenovationQuery, List<DateTime> dates,
        List<SplitRenovationTerm> available,
        int renovationId, int i)
    {
        available.Add(new SplitRenovationTerm(
            renovationId++,
            splitRenovationQuery.RoomToSplitId,
            splitRenovationQuery.NewRoomName1,
            splitRenovationQuery.NewRoomName2,
            splitRenovationQuery.NewRoomDescription1,
            splitRenovationQuery.NewRoomDescription2,
            splitRenovationQuery.NewRoomType1,
            splitRenovationQuery.NewRoomType2,
            dates[i],
            dates[i + splitRenovationQuery.Duration]
        ));
        return renovationId;
    }

    private static void FindAvailableDays(SplitRenovationTerm splitRenovationQuery, List<DateTime> dates,
        List<Appointment> appointments)
    {
        for (int i = 0; i < dates.Count; i++)
        {
            foreach (var appointment in appointments)
            {
                if (RoomHasAppointmentAtGivenDate(splitRenovationQuery, dates, i, appointment))
                {
                    dates.RemoveAt(i);
                }
            }
        }
    }

    private static bool StartDayPlusDurationIsEndDay(SplitRenovationTerm splitRenovationQuery,
        List<DateTime> dates, int i)
    {
        return dates[i].AddDays(splitRenovationQuery.Duration) == dates[i + splitRenovationQuery.Duration];
    }

    private static void FillInAllDays(SplitRenovationTerm splitRenovationQuery, List<DateTime> dates)
    {
        for (var dt = splitRenovationQuery.Range.Start; dt <= splitRenovationQuery.Range.End; dt = dt.AddDays(1))
        {
            dates.Add(dt);
        }
    }

    private static bool RoomHasAppointmentAtGivenDate(SplitRenovationTerm splitRenovationQuery,
        List<DateTime> dates, int i, Appointment appointment)
    {
        return dates[i] == appointment.StartTime.Date &&
               splitRenovationQuery.RoomToSplitId == appointment.RoomNumber;
    }

    public bool ScheduleSplit(SplitRenovationTerm splitRenovationTerm)// 2/4 Main Function
    {
        var room = RoomRepository.GetById(splitRenovationTerm.RoomToSplitId);
        if (DateIsBetweenStartAndEnd(splitRenovationTerm))
        {
            room.Disabled = 3;
            RoomRepository.Update(room);
        }
        return SplitTermRepository.ScheduleSplit(splitRenovationTerm);
    }

    private static bool DateIsBetweenStartAndEnd(SplitRenovationTerm splitRenovationTerm)
    {
        return DateTime.Now >= splitRenovationTerm.Range.Start
               && DateTime.Now <= DateRange.GetLastMoment(splitRenovationTerm.Range.End);
    }

    public void DisableSplittingRooms()// 3/4 Main Function
    {
        List<SplitRenovationTerm> splitRenovations = SplitTermRepository.GetSplitSchedules();
        List<Room> existing = RoomRepository.GetAll();
        foreach (var room in existing)
        {
            foreach (var renovationTerm in splitRenovations)
            {
                if (StartingDayPassed(renovationTerm) && RoomFound(room, renovationTerm))
                {
                    DisableAndUpdateSplittingRoom(room);
                }
            }
        }
    }

    private void DisableAndUpdateSplittingRoom(Room room)
    {
        room.Disabled = 3;
        RoomRepository.Update(room);
    }

    private static bool RoomFound(Room room, SplitRenovationTerm renovationTerm)
    {
        return room.Id == renovationTerm.RoomToSplitId;
    }

    private static bool StartingDayPassed(SplitRenovationTerm renovationTerm)
    {
        return DateTime.Now >= renovationTerm.Range.Start;
    }

    public void ExecuteSplitting()// 4/4 Main Function
    {
        List<SplitRenovationTerm> splitRenovationTerms = SplitTermRepository.GetSplitSchedules();
        List<Room> existing = RoomRepository.GetAll();
        foreach (var renovationTerm in splitRenovationTerms)
        {
            foreach (var room in existing)
            {
                if (EndingDateHasPassed(renovationTerm) && RoomFound(room, renovationTerm))
                {
                    CreateNewRooms(renovationTerm, room);
                    DeleteRoomAndItsSchedule(room, renovationTerm);
                }
            }
        }
    }

    private void DeleteRoomAndItsSchedule(Room room, SplitRenovationTerm renovationTerm)
    {
        RoomRepository.DeleteById(room.Id);
        SplitTermRepository.DeleteSplitScheduling(renovationTerm);
    }

    private void CreateNewRooms(SplitRenovationTerm renovationTerm, Room room)
    {
        RoomRepository.Create(new Room(RoomRepository.NextId(), renovationTerm.NewRoomName1,
            renovationTerm.NewRoomType1, room.Floor, renovationTerm.NewRoomDescription1, "No"));
        RoomRepository.Create(new Room(RoomRepository.NextId(), renovationTerm.NewRoomName2,
            renovationTerm.NewRoomType2, room.Floor, renovationTerm.NewRoomDescription2, "No"));
    }

    private static bool EndingDateHasPassed(SplitRenovationTerm renovationTerm)
    {
        return DateTime.Now >
               DateRange.GetLastMoment(renovationTerm.Range.End);
    }
}