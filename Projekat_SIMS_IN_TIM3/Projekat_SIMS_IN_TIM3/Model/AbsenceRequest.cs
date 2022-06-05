using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class AbsenceRequest
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AdditionalExplanation { get; set; }
        public bool IsUrgent { get; set; }

        public int DoctorId { get; set; }
        public RequestStatus requestStatus { get; set; }
        public string RejectionExplanation { get; set; }
        public enum RequestStatus{
            OnHold,
            Accepted,
            Rejected
        }

        public AbsenceRequest(int id, DateTime startDate, DateTime endDate, string additionalExplanation, bool isUrgent, int doctorId, RequestStatus requestStatus, string rejectionExplanation) : this(id, startDate, endDate, additionalExplanation, isUrgent, doctorId, requestStatus)
        {
          
            RejectionExplanation = rejectionExplanation;
        }

        public AbsenceRequest(int id, DateTime startDate, DateTime endDate, string additionalExplanation, bool isUrgent, int doctorId)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            AdditionalExplanation = additionalExplanation;
            IsUrgent = isUrgent;
            DoctorId = doctorId;
        }

        public AbsenceRequest(int id, DateTime startDate, DateTime endDate, string additionalExplanation, bool isUrgent, int doctorId, RequestStatus requestStatus) : this(id, startDate, endDate, additionalExplanation, isUrgent, doctorId)
        {
            this.requestStatus = requestStatus;
        }

        public AbsenceRequest()
        {
        }
    }
}
