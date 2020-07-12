using NUnit.Framework;
using ParkingFeeCalculator.API.Services;
using System;

namespace ParkingFeeCalculator.Tests
{
    public class EarlyBirdRateTests
    {
        private IParkingFeeCalculator parkingFeeCalculator;

        [Test]
        public void EarlyBirdTest()
        {
            parkingFeeCalculator = new EarlyBirdRateCalculator();
            DateTime entryTime = new DateTime(2020, 7, 12, 7, 0, 0);
            DateTime exitTime = new DateTime(2020, 7, 12, 23, 30, 0);

            var ruleApply = parkingFeeCalculator.IsRuleApplicable(entryTime, exitTime);
            var fee = parkingFeeCalculator.Calculate(entryTime, exitTime);

            Assert.AreEqual(13, fee);
            Assert.IsTrue(ruleApply);
        }

        [Test]
        public void EarlyBirdTest_EntryTimeNotMeetingCondition()
        {
            parkingFeeCalculator = new EarlyBirdRateCalculator();
            DateTime entryTime = new DateTime(2020, 7, 12, 5, 0, 0);
            DateTime exitTime = new DateTime(2020, 7, 12, 23, 30, 0);

            var ruleApply = parkingFeeCalculator.IsRuleApplicable(entryTime, exitTime);

            Assert.IsFalse(ruleApply);
        }

        [Test]
        public void EarlyBirdTest_ExitTimeNotMeetingCondition()
        {
            parkingFeeCalculator = new EarlyBirdRateCalculator();
            DateTime entryTime = new DateTime(2020, 7, 12, 6, 0, 0);
            DateTime exitTime = new DateTime(2020, 7, 12, 23, 55, 0);

            var ruleApply = parkingFeeCalculator.IsRuleApplicable(entryTime, exitTime);

            Assert.IsFalse(ruleApply);
        }
    }
}
