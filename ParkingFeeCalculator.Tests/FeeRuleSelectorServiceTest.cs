using Moq;
using NUnit.Framework;
using ParkingFeeCalculator.API.Services;
using System;
using System.Collections.Generic;

namespace ParkingFeeCalculator.Tests
{
    public class FeeRuleSelectorServiceTest
    {
        private Mock<IParkingFeeCalculatorService> parkingFeeCalcService;

        [SetUp]
        public void Setup()
        {
            parkingFeeCalcService = new Mock<IParkingFeeCalculatorService>();
        }

        [Test]
        public void SholdStopRunningRules_WhenAnApplicableRuleFound()
        {
            parkingFeeCalcService.Setup(x => x.IsRuleApplicable(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(true);
            parkingFeeCalcService.Setup(x => x.Calculate(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(10);
            var service = new FeeRuleSelectorService(new List<IParkingFeeCalculatorService>() { parkingFeeCalcService.Object });
            
            service.Calculate(DateTime.Now, DateTime.Now);

            parkingFeeCalcService.Verify(x => x.IsRuleApplicable(It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.AtMostOnce());
            parkingFeeCalcService.Verify(x => x.Calculate(It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.AtMostOnce());         
        }
    }
}
