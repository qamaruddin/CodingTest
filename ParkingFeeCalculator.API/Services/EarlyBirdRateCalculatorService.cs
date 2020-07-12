using System;

namespace ParkingFeeCalculator.API.Services
{
    public class EarlyBirdRateCalculatorService : IParkingFeeCalculatorService
    {
        public double Calculate(DateTime entryTime, DateTime exitTime)
        {
            return 13;
        }

        public bool IsRuleApplicable(DateTime entryTime, DateTime exitTime)
        {
            var earlyBirdEntryStart = new DateTime(entryTime.Year, entryTime.Month, entryTime.Day, 6, 0, 0);
            var earlyBirdEntryEnd = earlyBirdEntryStart.AddHours(3);
            var earlyBirdExitStart = new DateTime(entryTime.Year, entryTime.Month, entryTime.Day, 15, 30, 0);
            var earlyBirdExitEnd = earlyBirdExitStart.AddHours(8);

            return (entryTime >= earlyBirdEntryStart && entryTime <= earlyBirdEntryEnd)
                 && (exitTime >= earlyBirdExitStart && exitTime <= earlyBirdExitEnd);
        }
    }
}
