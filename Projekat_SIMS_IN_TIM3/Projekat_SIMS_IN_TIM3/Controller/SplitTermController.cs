using System.Collections.Generic;
using Projekat_SIMS_IN_TIM3.Model;
using Projekat_SIMS_IN_TIM3.Service;

namespace Projekat_SIMS_IN_TIM3.Controller;

public class SplitTermController
{
    public SplitTermService SplitTermService { get; set; } = new SplitTermService();

    public List<SplitRenovationTerm> GetSplitRenovationAvailableTerms(SplitRenovationTerm splitRenovationQuery)
    {
        return this.SplitTermService.GetSplitRenovationAvailableTerms(splitRenovationQuery);
    }

    public bool ScheduleSplit(SplitRenovationTerm splitRenovationTerm)
    {
        return this.SplitTermService.ScheduleSplit(splitRenovationTerm);
    }

    public void DisableSplittingRooms()
    {
        this.SplitTermService.DisableSplittingRooms();
    }

    public void ExecuteSplitting()
    {
        this.SplitTermService.ExecuteSplitting();
    }
}