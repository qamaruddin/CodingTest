using System;

namespace ParkingFeeCalculator.API.Services
{
    public interface IParkingFeeCalculatorService
    {
        double Calculate(DateTime entryTime, DateTime exitTime);
        bool IsRuleApplicable(DateTime entryTime, DateTime exitTime);
    }
}
