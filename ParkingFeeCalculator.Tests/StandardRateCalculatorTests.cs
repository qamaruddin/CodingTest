using NUnit.Framework;
using ParkingFeeCalculator.API.Services;
using System;

namespace ParkingFeeCalculator.Tests
{
    public class StandardRateCalculatorTests
    {
        [Test]
        [TestCase(40, 0, 0, 5)]
        [TestCase(0, 1, 0, 5)]
        [TestCase(70, 0, 0, 10)]
        [TestCase(0, 2, 0, 10)]
        [TestCase(130, 0, 0, 15)]
        [TestCase(0, 3, 0, 15)]
        [TestCase(189, 0, 0, 20)]
        [TestCase(0, 0, 1, 20)]
        [TestCase(0, 2, 1, 30)]
        [TestCase(0, 4, 1, 40)]
        public void StandardRateCalculatorTest(int minutes, int hours, int days, double expected)
        {
            var rateCalculator = new StandardRateCalculator();

            var fee = rateCalculator.Calculate(DateTime.Now, DateTime.Now.AddMinutes(minutes).AddHours(hours).AddDays(days));

            Assert.AreEqual(expected, fee);
        }
    }
}