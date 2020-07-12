using System;

namespace ParkingFeeCalculator.API.Services
{
    public class FlatRateCalculator : IParkingFeeCalculator
    {
        public double Calculate(DateTime entryTime, DateTime exitTime)
        {
            //early bird
            var earlyBirdEntryStart = new DateTime(entryTime.Year, entryTime.Month, entryTime.Day, 6, 0, 0);
            var earlyBirdEntryEnd = earlyBirdEntryStart.AddHours(3);
            var earlyBirdExitStart = new DateTime(entryTime.Year, entryTime.Month, entryTime.Day, 15, 30, 0);
            var earlyBirdExitEnd = earlyBirdExitStart.AddHours(8);

            if (entryTime >= earlyBirdEntryStart && entryTime <= earlyBirdEntryEnd
                && exitTime >= earlyBirdExitStart && exitTime <= earlyBirdExitEnd)
            {
                return 13;
            }

            //weekdays night rate
            var nightRateEntryStart = new DateTime(entryTime.Year, entryTime.Month, entryTime.Day, 18, 0, 0);
            var nightRateEntryExit = nightRateEntryStart.AddHours(6);
            var nightRateExitStart = new DateTime(entryTime.Year, entryTime.Month, entryTime.Day, 15, 30, 0);
            var nightRateExitEnd = nightRateExitStart.AddHours(8);

            if ((entryTime.DayOfWeek != DayOfWeek.Saturday || entryTime.DayOfWeek != DayOfWeek.Sunday)
                && entryTime >= nightRateEntryStart && entryTime <= nightRateEntryExit && exitTime >= nightRateExitStart && exitTime <= nightRateExitEnd)
            {
                return 6.50;
            }

            //weekend rate
            if ((entryTime.DayOfWeek == DayOfWeek.Saturday || entryTime.DayOfWeek == DayOfWeek.Sunday)
                && (exitTime.DayOfWeek == DayOfWeek.Saturday || exitTime.DayOfWeek == DayOfWeek.Sunday))
            {
                return 10;
            }

            return 0;
        }
    }
}
