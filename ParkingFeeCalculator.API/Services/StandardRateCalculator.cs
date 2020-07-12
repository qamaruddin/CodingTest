using System;

namespace ParkingFeeCalculator.API.Services
{
    public class StandardRateCalculator : IParkingFeeCalculator
    {
        public double Calculate(DateTime entryTime, DateTime exitTime)
        {
            var diff = exitTime.Subtract(entryTime);
            return CalculateHourlyCharge(diff.Hours * 60 + diff.Minutes) + CalculateDailyCharge(diff.Days);
        }

        private double CalculateHourlyCharge(double minutes)
        {
            if (minutes > 0 && minutes <= 60)
            {
                return 5;
            }
            if (minutes > 60 && minutes <= 120)
            {
                return 10;
            }
            if (minutes > 120 && minutes <= 180)
            {
                return 15;
            }
            if (minutes > 180 && minutes <= 24 * 60)
            {
                return 20;
            }

            return 0;
        }

        private double CalculateDailyCharge(int days)
        {
            return days * 20;
        }
    }
}
