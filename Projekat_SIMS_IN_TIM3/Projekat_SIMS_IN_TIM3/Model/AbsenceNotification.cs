using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class AbsenceNotification
    {
        public int Id { get; set; }
        public AbsenceRequest AbsenceRequest { get; set; }
        public String RejectionExplanation { get; set; }

        public AbsenceNotification(int id, AbsenceRequest absenceRequest, string rejectionExplanation)
        {
            Id = id;
            AbsenceRequest = absenceRequest;
            RejectionExplanation = rejectionExplanation;
        }

    }
}
