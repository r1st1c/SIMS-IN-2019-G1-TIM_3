using System.Collections.Generic;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;

namespace Projekat_SIMS_IN_TIM3.Controller;

public class MergeTermController
{
    public MergeTermService MergeTermService { get; set; } = new MergeTermService();

    public List<MergeRenovationTerm> GetMergeRenovationAvailableTerms(MergeRenovationTerm mergeRenovationQuery)
    {
        return this.MergeTermService.GetMergeRenovationAvailableTerms(mergeRenovationQuery);
    }

    public bool ScheduleMerge(MergeRenovationTerm mergeRenovationTerm)
    {
        return this.MergeTermService.ScheduleMerge(mergeRenovationTerm);
    }

    public void DisableMergingRooms()
    {
        this.MergeTermService.DisableMergingRooms();
    }

    public void ExecuteMerging()
    {
        this.MergeTermService.ExecuteMerging();
    }
}