using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat_SIMS_IN_TIM3.Model;

namespace Projekat_SIMS_IN_TIM3.IRepository
{
    public interface MergeTermIRepository
    {
        public bool ScheduleMerge(MergeRenovationTerm mergeRenovationTerm);
        public List<MergeRenovationTerm> GetMergeSchedules();
        public void DeleteMergeScheduling(MergeRenovationTerm renovationTerm);

    }
}
