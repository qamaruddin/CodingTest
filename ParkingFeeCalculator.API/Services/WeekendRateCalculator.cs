using System;

namespace ParkingFeeCalculator.API.Services
{
    public class WeekendRateCalculator : IParkingFeeCalculator
    {
        public double Calculate(DateTime entryTime, DateTime exitTime)
        {
            return 10;
        }

        public bool IsRuleApplicable(DateTime entryTime, DateTime exitTime)
        {
            return ((entryTime.DayOfWeek == DayOfWeek.Saturday || entryTime.DayOfWeek == DayOfWeek.Sunday)
                    && (exitTime.DayOfWeek == DayOfWeek.Saturday || exitTime.DayOfWeek == DayOfWeek.Sunday));
        }
    }
}
