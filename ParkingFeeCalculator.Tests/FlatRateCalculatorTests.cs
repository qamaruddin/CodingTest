using NUnit.Framework;
using ParkingFeeCalculator.API.Services;
using System;

namespace ParkingFeeCalculator.Tests
{
    public class FlatRateCalculatorTests
    {
        [Test]
        public void ShouldPickRightFeeCalculator()
        {
            var earlyBirdCalculator = new EarlyBirdRateCalculator();
            var nightRateCalculator = new NightRateCalulator();
            var weekendRateCalculator = new WeekendRateCalculator();

            DateTime entryTime = new DateTime(2020, 7, 9, 7, 0, 0);
            DateTime exitTime = new DateTime(2020, 7, 9, 23, 30, 0);

            var isEarlyBirdRate = earlyBirdCalculator.IsRuleApplicable(entryTime, exitTime);
            var isNightRate = nightRateCalculator.IsRuleApplicable(entryTime, exitTime);
            var isWeekendRate = weekendRateCalculator.IsRuleApplicable(entryTime, exitTime);

            Assert.IsTrue(isEarlyBirdRate);
            Assert.IsFalse(isNightRate);
            Assert.IsFalse(isWeekendRate);
        }

    }
}
