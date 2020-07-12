using NUnit.Framework;
using ParkingFeeCalculator.API.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingFeeCalculator.Tests
{
    public class WeekendRateTest
    {
        private IParkingFeeCalculatorService parkingFeeCalculator;

        [Test]
        public void WeekendRateTest_EntryAndExitSunday()
        {
            parkingFeeCalculator = new WeekendRateCalculatorService();
            DateTime entryTime = new DateTime(2020, 7, 12, 0, 0, 0);
            DateTime exitTime = new DateTime(2020, 7, 12, 23, 30, 0);

            var fee = parkingFeeCalculator.Calculate(entryTime, exitTime);
            var ruleApply = parkingFeeCalculator.IsRuleApplicable(entryTime, exitTime);

            Assert.AreEqual(10, fee);
            Assert.IsTrue(ruleApply);
        }

        [Test]
        public void WeekendRateTest_EntryAndExitSat()
        {
            parkingFeeCalculator = new WeekendRateCalculatorService();
            DateTime entryTime = new DateTime(2020, 7, 11, 0, 0, 0);
            DateTime exitTime = new DateTime(2020, 7, 11, 23, 30, 0);

            var fee = parkingFeeCalculator.Calculate(entryTime, exitTime);
            var ruleApply = parkingFeeCalculator.IsRuleApplicable(entryTime, exitTime);

            Assert.AreEqual(10, fee);
            Assert.IsTrue(ruleApply);
        }

        [Test]
        public void WeekendRateTest_EntrySatExitSun()
        {
            parkingFeeCalculator = new WeekendRateCalculatorService();
            DateTime entryTime = new DateTime(2020, 7, 11, 0, 0, 0);
            DateTime exitTime = new DateTime(2020, 7, 12, 23, 30, 0);

            var fee = parkingFeeCalculator.Calculate(entryTime, exitTime);
            var ruleApply = parkingFeeCalculator.IsRuleApplicable(entryTime, exitTime);

            Assert.AreEqual(10, fee);
            Assert.IsTrue(ruleApply);
        }
    }
}
