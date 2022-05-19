using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Controller
{
    public class RoomController
    {
        public int getMaxId()
        {
            return this.roomService.getMaxId();
        }

        public Room GetById(int id)
        {
            return this.roomService.GetById(id);
        }
        public Room GetByName(string name)
        {
            return this.roomService.GetByName(name);
        }
        public List<Room> GetAll()
        {
            return this.roomService.GetAll();
        }

        public (bool,bool) Create(Room room)
        {
            return this.roomService.Create(room);
        }
        public bool UpdateUsingNewName(Room room)
        {
            return this.roomService.UpdateUsingNewName(room);
        }
        public bool UpdateUsingSameName(Room room)
        {
            return this.roomService.UpdateUsingSameName(room);
        }

        public bool DeleteById(int id)
        {
            return this.roomService.DeleteById(id);
        }

        public List<RenovationTerm> BasicRenovation(int roomId, DateTime start, DateTime end, int duration)
        {
            return this.roomService.BasicRenovation(roomId, start, end, duration);
        }

        public bool ScheduleRenovation(int roomId, string start, string end, string description)
        {
            return this.roomService.ScheduleRenovation(roomId, start, end, description);
        }

        public void UpdateDisabledFields()
        {
            this.roomService.UpdateDisabledFields();
        }
        public List<RenovationTerm> GetRenovationSchedules()
        {
            return this.roomService.GetRenovationSchedules();
        }

        public List<MergeRenovationTerm> GetMergeRenovationAvailableTerms(MergeRenovationTerm mergeRenovationQuery)
        {
            return this.roomService.GetMergeRenovationAvailableTerms(mergeRenovationQuery);
        }

        public bool ScheduleMerge(MergeRenovationTerm mergeRenovationTerm)
        {
            return this.roomService.ScheduleMerge(mergeRenovationTerm);
        }

        public void DisableMergingRooms()
        {
            this.roomService.DisableMergingRooms();
        }
        public void ExecuteMerging()
        {
            this.roomService.ExecuteMerging();
        }
        public List<SplitRenovationTerm> GetSplitRenovationAvailableTerms(SplitRenovationTerm splitRenovationQuery)
        {
            return this.roomService.GetSplitRenovationAvailableTerms(splitRenovationQuery);
        }

        public bool ScheduleSplit(SplitRenovationTerm splitRenovationTerm)
        {
            return this.roomService.ScheduleSplit(splitRenovationTerm);
        }
        public void DisableSplittingRooms()
        {
            this.roomService.DisableSplittingRooms();
        }

        public void ExecuteSplitting()
        {
            this.roomService.ExecuteSplitting();
        }
        public RoomService roomService = new RoomService();

    }
}
