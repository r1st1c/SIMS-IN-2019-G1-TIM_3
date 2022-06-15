using System;
using System.Collections.Generic;
using System.Linq;
using Projekat_SIMS_IN_TIM3.IRepository;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Repository;

namespace Projekat_SIMS_IN_TIM3.Service;

public class MergeTermService
{
    public MergeTermIRepository mergeTermRepository;
    public RoomIRepository roomRepository;
    public AppointmentRepository appointmentRepository;

    public MergeTermService(MergeTermIRepository mergeTermRepository, RoomIRepository roomRepository,
        AppointmentRepository appointmentRepository)
    {
        this.mergeTermRepository = mergeTermRepository;
        this.roomRepository = roomRepository;
        this.appointmentRepository = appointmentRepository;
    }
    public List<MergeRenovationTerm> GetMergeRenovationAvailableTerms(MergeRenovationTerm mergeRenovationQuery)
    {
        List<DateTime> intersectedAvailableDays = FindIntersectedAvailableDays(mergeRenovationQuery);

        List<MergeRenovationTerm> available = new List<MergeRenovationTerm>();

        FindAvailableTerms(mergeRenovationQuery, intersectedAvailableDays, available);
        return available;
    }

    private static void FindAvailableTerms(MergeRenovationTerm mergeRenovationQuery,
        List<DateTime> intersectedAvailableDays,
        List<MergeRenovationTerm> available)
    {
        mergeRenovationQuery
            .Duration--; //first day is already included so we subtract that day from total amount of days'
        int renovationId = 0;

        for (int i = 0; i < intersectedAvailableDays.Count - mergeRenovationQuery.Duration; i++)
        {
            if (DateRange.StartDayPlusDurationIsEndDay(mergeRenovationQuery.Duration, intersectedAvailableDays,i))
            {
                renovationId =
                    AddAsAvailableTerm(mergeRenovationQuery, available, renovationId, intersectedAvailableDays, i);
            }
        }
    }

    private static int AddAsAvailableTerm(MergeRenovationTerm mergeRenovationQuery,
        List<MergeRenovationTerm> available, int renovationId,
        List<DateTime> intersectedAvailableDays, int i)
    {
        available.Add(new MergeRenovationTerm(renovationId++,
            mergeRenovationQuery.RoomId1,
            mergeRenovationQuery.RoomId2,
            intersectedAvailableDays[i],
            intersectedAvailableDays[i + mergeRenovationQuery.Duration],
            mergeRenovationQuery.Description,
            mergeRenovationQuery.Name,
            mergeRenovationQuery.RoomType));
        return renovationId;
    }

    private List<DateTime> FindIntersectedAvailableDays(MergeRenovationTerm mergeRenovationQuery)
    {
        var firstRoomAvailableDays = new List<DateTime>();
        var secondRoomAvailableDays = new List<DateTime>();
        List<Appointment> allAppointments = this.appointmentRepository.GetAll();

        FillInAllDays(mergeRenovationQuery, firstRoomAvailableDays, secondRoomAvailableDays);

        RemoveOccupiedDays(mergeRenovationQuery, firstRoomAvailableDays, allAppointments, secondRoomAvailableDays);

        return firstRoomAvailableDays.Intersect(secondRoomAvailableDays).ToList();
    }

    private static void RemoveOccupiedDays(MergeRenovationTerm mergeRenovationQuery,
        List<DateTime> firstRoomAvailableDays,
        List<Appointment> allAppointments, List<DateTime> secondRoomAvailableDays)
    {
        for (int i = 0; i < firstRoomAvailableDays.Count; i++)
        {
            foreach (var appointment in allAppointments)
            {
                if (RoomHasAppointmentAtGivenDate(mergeRenovationQuery, firstRoomAvailableDays, i, appointment, 1))
                {
                    firstRoomAvailableDays.RemoveAt(i);
                }

                if (RoomHasAppointmentAtGivenDate(mergeRenovationQuery, secondRoomAvailableDays, i, appointment, 2))
                {
                    secondRoomAvailableDays.RemoveAt(i);
                }
            }
        }
    }

    private static bool RoomHasAppointmentAtGivenDate(MergeRenovationTerm mergeRenovationQuery,
        List<DateTime> roomAvailableDays, int i, Appointment appointment, int roomId)
    {
        if (roomId == 1)
        {
            return roomAvailableDays[i].Date == appointment.StartTime.Date &&
                   mergeRenovationQuery.RoomId1 == appointment.RoomNumber;
        }

        if (roomId == 2)
        {
            return roomAvailableDays[i].Date == appointment.StartTime.Date &&
                   mergeRenovationQuery.RoomId2 == appointment.RoomNumber;
        }

        throw new Exception("ROOM ID RoomHasAppointmentAtGivenDate == ???");
    }

    private static void FillInAllDays(MergeRenovationTerm mergeRenovationQuery,
        List<DateTime> firstRoomAvailableDays,
        List<DateTime> secondRoomAvailableDays)
    {
        for (var dt = mergeRenovationQuery.Range.Start; dt <= mergeRenovationQuery.Range.End; dt = dt.AddDays(1))
        {
            firstRoomAvailableDays.Add(dt);
            secondRoomAvailableDays.Add(dt);
        }
    }

    public bool ScheduleMerge(MergeRenovationTerm mergeRenovationTerm)
    {
        var room1 = roomRepository.GetById(mergeRenovationTerm.RoomId1);
        var room2 = roomRepository.GetById(mergeRenovationTerm.RoomId2);
        if (DateIsBetweenStartAndEnd(mergeRenovationTerm))
        {
            room1.Disabled = 2;
            room2.Disabled = 2;
            roomRepository.Update(room1);
            roomRepository.Update(room2);
        }
        return mergeTermRepository.ScheduleMerge(mergeRenovationTerm);
    }

    private static bool DateIsBetweenStartAndEnd(MergeRenovationTerm mergeRenovationTerm)
    {
        return DateTime.Now >= mergeRenovationTerm.Range.Start
               && DateTime.Now <= DateRange.GetLastMoment(mergeRenovationTerm.Range.End);
    }

    public void DisableMergingRooms()
    {
        List<MergeRenovationTerm> mergeRenovations = mergeTermRepository.GetMergeSchedules();
        List<Room> existing = roomRepository.GetAll();
        foreach (var room in existing)
        {
            foreach (var renovationTerm in mergeRenovations)
            {
                if (StartingDatePassed(renovationTerm) && RoomFound(room, renovationTerm))
                {
                    DisableAndUpdateMergingRoom(room);
                }
            }
        }
    }

    private void DisableAndUpdateMergingRoom(Room room)
    {
        room.Disabled = 2;
        roomRepository.Update(room);
    }

    private static bool StartingDatePassed(MergeRenovationTerm renovationTerm)
    {
        return DateTime.Now >= renovationTerm.Range.Start;
    }

    public void ExecuteMerging()
    {
        List<MergeRenovationTerm> mergeRenovations = mergeTermRepository.GetMergeSchedules();
        List<Room> existing = roomRepository.GetAll();
        List<Room> toCreateList = new List<Room>();
        foreach (var renovationTerm in mergeRenovations)
        {
            foreach (var room in existing)
            {
                if (EndingDatePassed(renovationTerm) && RoomFound(room, renovationTerm))
                {
                    CreateRoomAndAddToCreationList(toCreateList, renovationTerm, room);
                    DeleteRoomAndItsMergeScheduling(room, renovationTerm);
                }
            }
        }

        List<Room> distinctRooms = RemoveDuplicateRooms(toCreateList);
        CreateRooms(distinctRooms);
    }

    private void DeleteRoomAndItsMergeScheduling(Room room, MergeRenovationTerm renovationTerm)
    {
        roomRepository.DeleteById(room.Id);
        mergeTermRepository.DeleteMergeScheduling(renovationTerm);
    }

    private static void CreateRoomAndAddToCreationList(List<Room> toCreateList, MergeRenovationTerm renovationTerm,
        Room room)
    {
        toCreateList.Add(new Room(0, renovationTerm.Name, renovationTerm.RoomType, room.Floor,
            renovationTerm.Description,
            "No"));
    }

    private void CreateRooms(List<Room> distinctList)
    {
        foreach (Room toBeCreated in distinctList)
        {
            toBeCreated.Id = roomRepository.NextId();
            roomRepository.Create(toBeCreated);
        }
    }

    private static List<Room> RemoveDuplicateRooms(List<Room> toCreateList)
    {
        return toCreateList.DistinctBy(x => x.Name).ToList();
    }

    private static bool RoomFound(Room room, MergeRenovationTerm renovationTerm)
    {
        return (room.Id == renovationTerm.RoomId1 || room.Id == renovationTerm.RoomId2);
    }

    private static bool EndingDatePassed(MergeRenovationTerm renovationTerm)
    {
        return DateTime.Now >
               DateRange.GetLastMoment(renovationTerm.Range.End);
    }
}