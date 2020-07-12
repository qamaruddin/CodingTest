using System;

namespace ParkingFeeCalculator.API.Services
{
    public interface IParkingFeeCalculator
    {
        double Calculate(DateTime entryTime, DateTime exitTime);
        bool IsRuleApplicable(DateTime entryTime, DateTime exitTime);
    }
}
