using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class DateRange
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public DateRange(DateTime start, DateTime end)
        {
            this.Start = start;
            this.End = end;
        }

        public static DateTime GetLastMoment(DateTime end)
        {
            return end.AddHours(23).AddMinutes(59).AddSeconds(59);
        }
        public static bool StartDayPlusDurationIsEndDay(int duration,
            List<DateTime> intersectedAvailableDays, int i)
        {
            return intersectedAvailableDays[i].AddDays(duration) ==
                   intersectedAvailableDays[i + duration];
        }

        public static bool DateIsBetweenStartAndEnd(DateTime start, DateTime end)
        {
            return DateTime.Now >= start
                   && DateTime.Now <= DateRange.GetLastMoment(end);
        }
        public static bool StartingDayPassed(DateTime start)
        {
            return DateTime.Now >= start;
        }
        public static bool EndingDateHasPassed(DateTime end)
        {
            return DateTime.Now >
                   DateRange.GetLastMoment(end);
        }
    }
}
