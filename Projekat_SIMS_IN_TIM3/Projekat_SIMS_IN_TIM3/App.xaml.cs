using Projekat_SIMS_IN_TIM3.Controller;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Windows.ApplicationModel;
using Projekat_SIMS_IN_TIM3.IRepository;
using Projekat_SIMS_IN_TIM3.Repository;
using Projekat_SIMS_IN_TIM3.Service;
using Xceed.Wpf.Toolkit.Core.Converters;

namespace Projekat_SIMS_IN_TIM3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public readonly UserController userController = new UserController();
        public readonly UserLoginController userLoginController = new UserLoginController();
        public readonly PatientController patientController = new PatientController();
        public readonly GuestController guestController = new GuestController();
        public readonly AppointmentController appointmentController = new AppointmentController();
        public readonly DoctorController docController = new DoctorController();
        public readonly AllergenController allergenController = new AllergenController();
        public readonly MedicinePrescriptionController medPrescriptionController = new MedicinePrescriptionController();
        public readonly MedicineController medicineController = new MedicineController();
        public readonly HospitalController hospitalController = new HospitalController();
        public readonly NoteController noteController = new NoteController();
        public string id;
        internal object doctorController;
        public readonly HospitalGradeController hospitalGradeController = new HospitalGradeController();
        public readonly DoctorGradeController doctorGradeController = new DoctorGradeController();
        public static AppointmentRepository appointmentRepository = new();

        #region Manager
        public static RoomIRepository roomRepository = new RoomRepository();
        public static SplitTermRepository splitTermRepository = new ();
        public static EquipmentRepository equipmentRepository = new();
        public static MergeTermRepository mergeTermRepository = new ();

        public static RoomService roomService = new RoomService(roomRepository, equipmentRepository);
        public static SplitTermService splitTermService =
            new SplitTermService(splitTermRepository, appointmentRepository, roomRepository);
        public static MergeTermService mergeTermService =
            new MergeTermService(mergeTermRepository, roomRepository, appointmentRepository);
        public static EquipmentService equipmentService = new EquipmentService(roomRepository, equipmentRepository);

        public readonly RoomController roomController = new RoomController(roomService);
        public readonly SplitTermController splitTermController = new SplitTermController(splitTermService);
        public readonly MergeTermController mergeTermController = new MergeTermController(mergeTermService);
        public readonly EquipmentController equipmentController = new EquipmentController(roomService,equipmentService);


        #endregion
    }
}
