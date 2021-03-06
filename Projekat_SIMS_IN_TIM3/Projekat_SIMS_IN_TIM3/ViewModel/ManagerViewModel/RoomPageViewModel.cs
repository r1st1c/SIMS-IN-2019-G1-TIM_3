using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Projekat_SIMS_IN_TIM3.Commands;
using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.ManagerWindows;
using Projekat_SIMS_IN_TIM3.Model;

namespace Projekat_SIMS_IN_TIM3.ViewModel.ManagerViewModel
{
    public class RoomPageViewModel
    {
        #region Fields

        public RoomController roomController;
        public RenovationTermController renovationTermController;
        public SplitTermController SplitTermController;
        public MergeTermController MergeTermController;
        public ObservableCollection<Room> Rooms { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand BasicCommand { get; set; }
        public RelayCommand MergeCommand { get; set; }
        public RelayCommand SplitCommand { get; set; }

        #endregion

        #region Constructor

        public RoomPageViewModel()
        {
            var app = Application.Current as App;
            this.roomController = app.roomController;
            this.SplitTermController = app.splitTermController;
            this.MergeTermController = app.mergeTermController;
            this.renovationTermController = app.renovationTermController;
            UpdateRenovatingFields();
            InstantiateCommands();
            Rooms = new ObservableCollection<Room>(roomController.GetAll());
        }

        private void UpdateRenovatingFields()
        {
            this.renovationTermController.DisableRenovatingRooms();
            this.MergeTermController.DisableMergingRooms();
            this.MergeTermController.ExecuteMerging();
            this.SplitTermController.DisableSplittingRooms();
            this.SplitTermController.ExecuteSplitting();
        }

        private void InstantiateCommands()
        {
            DeleteCommand = new RelayCommand(DeleteRoom);
            EditCommand = new RelayCommand(EditRoom);
            MergeCommand = new RelayCommand(MergeRoom);
            SplitCommand = new RelayCommand(SplitRoom);
            AddCommand = new RelayCommand(AddRoom);
            BasicCommand = new RelayCommand(BasicRoom);
        }

        #endregion

        #region Commands

        public void AddRoom(object parameter)
        {
            var addRoom = new AddRoom(Rooms);
            addRoom.ShowDialog();
        }

        public void EditRoom(object parameter)
        {
            Room room = this.roomController.GetById((int)parameter);
            int id = room.Id;
            var change = new EditRoomWindow(id, Rooms);
            change.ShowDialog();
        }

        public void DeleteRoom(object parameter)
        {
            Room room = this.roomController.GetById((int)parameter);
            if (room.Id == 0)
            {
                MessageBox.Show("Default storage room cant be deleted!");
                return;
            }

            RemoveFromList(room);
            this.roomController.DeleteById(room.Id);
        }

        private void RemoveFromList(Room room)
        {
            for (int i = 0; i < Rooms.Count; i++)
            {
                if (Rooms[i].Id == room.Id)
                {
                    Rooms.RemoveAt(i);
                }
            }
        }

        private void BasicRoom(object parameter)
        {
            Room room = this.roomController.GetById((int)parameter);
            var basic = new BasicRenovationWindow(room, Rooms);
            basic.ShowDialog();
        }

        private void MergeRoom(object parameter)
        {
            var merge = new MergeRoomsWindow(Rooms);
            merge.ShowDialog();
        }

        private void SplitRoom(object parameter)
        {
            Room room = this.roomController.GetById((int)parameter);
            var split = new SplitRoomWindow(room, Rooms);
            split.ShowDialog();
        }

        #endregion
    }
}