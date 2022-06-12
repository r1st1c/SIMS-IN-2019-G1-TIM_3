using System.Collections.Generic;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;

namespace Projekat_SIMS_IN_TIM3.Controller;

public class MergeTermController
{
    public MergeTermService mergeTermService;

    public MergeTermController(MergeTermService mergeTermService)
    {
        this.mergeTermService = mergeTermService;
    }

    public List<MergeRenovationTerm> GetMergeRenovationAvailableTerms(MergeRenovationTerm mergeRenovationQuery)
    {
        return this.mergeTermService.GetMergeRenovationAvailableTerms(mergeRenovationQuery);
    }

    public bool ScheduleMerge(MergeRenovationTerm mergeRenovationTerm)
    {
        return this.mergeTermService.ScheduleMerge(mergeRenovationTerm);
    }

    public void DisableMergingRooms()
    {
        this.mergeTermService.DisableMergingRooms();
    }

    public void ExecuteMerging()
    {
        this.mergeTermService.ExecuteMerging();
    }
}