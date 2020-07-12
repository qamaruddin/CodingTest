using NUnit.Framework;
using ParkingFeeCalculator.API.Services;
using System;

namespace ParkingFeeCalculator.Tests
{
    public class RightRateChooseTests
    {
        [Test]
        public void ShouldUseStandardRate_IfFlatRatesDontMatchConditions()
        {
            var entryTime = new DateTime(2020, 7, 8, 8, 30, 0);
            var exitTime = new DateTime(2020, 7, 11, 18, 05, 0);

            var earlyBirdCalculator = new EarlyBirdRateCalculatorService();
            var nightRateCalculator = new NightRateCalulatorService();
            var weekendRateCalculator = new WeekendRateCalculatorService();
            var standardRateCalculator = new StandardRateCalculatorService();

            var isEarlyBirdRate = earlyBirdCalculator.IsRuleApplicable(entryTime, exitTime);
            var isNightRate = nightRateCalculator.IsRuleApplicable(entryTime, exitTime);
            var isWeekendRate = weekendRateCalculator.IsRuleApplicable(entryTime, exitTime);
            var isStandardRate = standardRateCalculator.IsRuleApplicable(entryTime, exitTime);

            var fee = standardRateCalculator.Calculate(entryTime, exitTime);

            Assert.IsTrue(isStandardRate);
            Assert.IsFalse(isEarlyBirdRate);
            Assert.IsFalse(isNightRate);
            Assert.IsFalse(isWeekendRate);
            Assert.AreEqual(80, fee);
        }
    }
}
