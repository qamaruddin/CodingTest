using System;

namespace ParkingFeeCalculator.API.Services
{
    public class NightRateCalulator : IParkingFeeCalculator
    {
        public double Calculate(DateTime entryTime, DateTime exitTime)
        {
            return 6.50;
        }

        public bool IsRuleApplicable(DateTime entryTime, DateTime exitTime)
        {
            var nightRateEntryStart = new DateTime(entryTime.Year, entryTime.Month, entryTime.Day, 18, 0, 0);
            var nightRateEntryExit = new DateTime(entryTime.Year, entryTime.Month, entryTime.Day, 23, 59, 59);
            var nightRateExitStart = new DateTime(entryTime.Year, entryTime.Month, entryTime.Day, 15, 30, 0);
            var nightRateExitEnd = new DateTime(entryTime.Year, entryTime.Month, entryTime.Day, 23, 30, 0);

            return ((entryTime.DayOfWeek != DayOfWeek.Saturday && entryTime.DayOfWeek != DayOfWeek.Sunday)
                 && ((entryTime >= nightRateEntryStart & entryTime <= nightRateEntryExit) && (exitTime >= nightRateExitStart && exitTime <= nightRateExitEnd)));
        }
    }
}
