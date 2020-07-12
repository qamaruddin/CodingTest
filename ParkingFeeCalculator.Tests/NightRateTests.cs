using NUnit.Framework;
using ParkingFeeCalculator.API.Services;
using System;

namespace ParkingFeeCalculator.Tests
{
    public class NightRateTests
    {
        private IParkingFeeCalculatorService parkingFeeCalculator;

        [Test]
        public void NightRateTest()
        {
            parkingFeeCalculator = new NightRateCalulatorService();
            DateTime entryTime = new DateTime(2020, 7, 10, 18, 5, 0);
            DateTime exitTime = new DateTime(2020, 7, 10, 23, 30, 0);

            var fee = parkingFeeCalculator.Calculate(entryTime, exitTime);
            var ruleApply = parkingFeeCalculator.IsRuleApplicable(entryTime, exitTime);

            Assert.AreEqual(6.5, fee);
            Assert.IsTrue(ruleApply);
        }

        [Test]
        public void NightRateTest_EntryTimeNotMeetingConditon()
        {
            parkingFeeCalculator = new NightRateCalulatorService();
            DateTime entryTime = new DateTime(2020, 7, 10, 17, 5, 0);
            DateTime exitTime = new DateTime(2020, 7, 10, 23, 30, 0);

            var ruleApply = parkingFeeCalculator.IsRuleApplicable(entryTime, exitTime);

            Assert.IsFalse(ruleApply);
        }

        [Test]
        public void NightRateTest_ExitTimeNotMeetingConditon()
        {
            parkingFeeCalculator = new NightRateCalulatorService();
            DateTime entryTime = new DateTime(2020, 7, 10, 16, 5, 0);
            DateTime exitTime = new DateTime(2020, 7, 10, 23, 47, 0);

            var ruleApply = parkingFeeCalculator.IsRuleApplicable(entryTime, exitTime);

            Assert.IsFalse(ruleApply);
        }

        [Test]
        public void NightRate_EntryIsOnSunday()
        {
            parkingFeeCalculator = new NightRateCalulatorService();
            DateTime entryTime = new DateTime(2020, 7, 12, 18, 5, 0);
            DateTime exitTime = new DateTime(2020, 7, 12, 23, 30, 0);

            var ruleApply = parkingFeeCalculator.IsRuleApplicable(entryTime, exitTime);

            Assert.IsFalse(ruleApply);
        }

        [Test]
        public void NightRate_EntryIsOnSaturday()
        {
            parkingFeeCalculator = new NightRateCalulatorService();
            DateTime entryTime = new DateTime(2020, 7, 11, 18, 5, 0);
            DateTime exitTime = new DateTime(2020, 7, 11, 23, 30, 0);

            var ruleApply = parkingFeeCalculator.IsRuleApplicable(entryTime, exitTime);

            Assert.IsFalse(ruleApply);
        }
    }
}
