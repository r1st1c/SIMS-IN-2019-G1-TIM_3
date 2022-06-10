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
        #region Doctor
        public static DoctorService doctorService = new DoctorService();

        public static AbsenceRequestIRepository AbsenceRequestIRepository = new AbsenceRequestRepository();
        public static AbsenceRequestService AbsenceRequestService = new AbsenceRequestService(AbsenceRequestIRepository, doctorService);
        public readonly AbsenceRequestController absenceRequestController = new AbsenceRequestController(AbsenceRequestService);

        public static AbsenceNotificationsIRepository AbsenceNotificationsIRepository = new AbsenceNotificationsRepository();
        public static AbsenceNotificationsService AbsenceNotificationsService = new AbsenceNotificationsService(AbsenceNotificationsIRepository);
        public readonly AbsenceNotificationsController AbsenceNotificationsController = new AbsenceNotificationsController(AbsenceNotificationsService);
       
        public static AllergenIRepository AllergenIRepository = new AllergenRepository();
        public static AllergenService AllergenService = new AllergenService(AllergenIRepository);
        public readonly AllergenController allergenController = new AllergenController(AllergenService);

        public static MedicinePrescriptionIRepository MedicinePrescriptionIRepository = new MedicinePrescriptionRepository();
        public static MedicinePrescriptionService prescriptionService = new MedicinePrescriptionService(MedicinePrescriptionIRepository, medicineIRepository, AllergenIRepository);
        public readonly MedicinePrescriptionController medPrescriptionController = new MedicinePrescriptionController(prescriptionService);

        #endregion
        public readonly UserController userController = new UserController();
        public readonly UserLoginController userLoginController = new UserLoginController();
        public readonly PatientController patientController = new PatientController();
        public readonly GuestController guestController = new GuestController();
        
        
        public readonly DoctorController docController = new DoctorController();
     
        public static MedicineIRepository medicineIRepository= new MedicineRepository();
        public static MedicineService medicineService = new MedicineService(medicineIRepository);
        public readonly MedicineController medicineController = new MedicineController(medicineService);
        public readonly HospitalController hospitalController = new HospitalController();
        
        public string id;
        

        #region Patient
        public static NoteIRepository noteRepository = new NoteRepository();
        public static AnamnesisIRepository anamnesisRepository = new AnamnesisRepository();
        public static AppointmentIRepository appointmentRepositoryPatient = new AppointmentRepository();
        public static HospitalGradeIRepository hospitalGradeRepository = new HospitalGradeRepository();
        public static AlarmIRepository alarmRepository = new AlarmRepository();
        public static DoctorGradeIRepository doctorGradeRepository = new DoctorGradeRepository();

        public static PatientService patientService = new PatientService();
        public static NoteService noteService = new NoteService(noteRepository);
        public static AnamnesisService anamnesisService = new AnamnesisService(anamnesisRepository);
        public static AppointmentService appointmentService = new AppointmentService(appointmentRepositoryPatient, patientService);
        public static HospitalGradeService hospitalGradeService = new HospitalGradeService(hospitalGradeRepository);
        public static AlarmService alarmService = new AlarmService(alarmRepository);
        public static DoctorGradeService doctorGradeService = new DoctorGradeService(doctorGradeRepository);


        public readonly NoteController noteController = new NoteController(noteService);
        public readonly AnamnesisController anamnesisController = new AnamnesisController(anamnesisService);
        public readonly AppointmentController appointmentController = new AppointmentController(appointmentService);
        public readonly HospitalGradeController hospitalGradeController = new HospitalGradeController(hospitalGradeService);
        public readonly DoctorGradeController doctorGradeController = new DoctorGradeController(doctorGradeService);
        public readonly AlarmController alarmController = new AlarmController(alarmService);

        #endregion

        #region Manager
        public static RoomIRepository roomRepository = new RoomRepository();
        public static RenovationTermIRepository renovationTermRepository = new RenovationTermRepository();
        public static SplitTermIRepository splitTermRepository = new SplitTermRepository();
        public static EquipmentIRepository equipmentRepository = new EquipmentRepository();
        public static MergeTermIRepository mergeTermRepository = new MergeTermRepository();
        public static AppointmentRepository appointmentRepository = new AppointmentRepository();

        public static RoomService roomService = new RoomService(roomRepository, equipmentRepository);
        public static RenovationTermService renovationTermService =
            new RenovationTermService(roomRepository, appointmentRepository, renovationTermRepository);
        public static SplitTermService splitTermService =
            new SplitTermService(splitTermRepository, appointmentRepository, roomRepository);
        public static MergeTermService mergeTermService =
            new MergeTermService(mergeTermRepository, roomRepository, appointmentRepository);
        public static EquipmentService equipmentService = new EquipmentService(roomRepository, equipmentRepository);

        public readonly RoomController roomController = new RoomController(roomService);
        public readonly RenovationTermController renovationTermController = new RenovationTermController(renovationTermService);
        public readonly SplitTermController splitTermController = new SplitTermController(splitTermService);
        public readonly MergeTermController mergeTermController = new MergeTermController(mergeTermService);
        public readonly EquipmentController equipmentController = new EquipmentController(roomService,equipmentService);


        #endregion

       
    }
}
