using System;

namespace ParkingFeeCalculator.API.Services
{
    public interface IFeeRuleSelectorService
    {
        double Calculate(DateTime entryTime, DateTime exitTime);
    }
}