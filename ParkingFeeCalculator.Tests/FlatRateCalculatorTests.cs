using NUnit.Framework;
using ParkingFeeCalculator.API.Services;
using System;

namespace ParkingFeeCalculator.Tests
{
    public class FlatRateCalculatorTests
    {
        private IParkingFeeCalculator parkingFeeCalculator;

        [SetUp]
        public void Init()
        {
            parkingFeeCalculator = new FlatRateCalculator();
        }

        [Test]
        public void EarlyBirdTest()
        {
            var fee = parkingFeeCalculator.Calculate(new DateTime(2020, 7, 12, 7, 0, 0), new DateTime(2020, 7, 12, 23, 30, 0));
            Assert.AreEqual(13, fee);
        }

        [Test]
        public void NightRateTest()
        {
            var fee = parkingFeeCalculator.Calculate(new DateTime(2020, 7, 10, 18, 5, 0), new DateTime(2020, 7, 10, 23, 30, 0));
            Assert.AreEqual(6.5, fee);
        }

        [Test]
        public void WeekendRateTest()
        {
            var fee = parkingFeeCalculator.Calculate(new DateTime(2020, 7, 11, 0, 0, 0), new DateTime(2020, 7, 11, 23, 30, 0));
            Assert.AreEqual(10, fee);
        }
    }
}
