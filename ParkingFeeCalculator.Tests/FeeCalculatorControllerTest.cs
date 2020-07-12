using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ParkingFeeCalculator.API.Controllers;
using ParkingFeeCalculator.API.Services;
using ParkingFeeCalculator.API.ViewModels;
using System;

namespace ParkingFeeCalculator.Tests
{
    public class FeeCalculatorControllerTest
    {
        private Mock<ILogger<CalculatorController>> loggerMock;
        private Mock<IFeeRuleSelectorService> selectorService;
        private CalculatorController feeController;

        [SetUp]
        public void Setup()
        {
            loggerMock = new Mock<ILogger<CalculatorController>>();
            selectorService = new Mock<IFeeRuleSelectorService>();
            feeController = new CalculatorController(loggerMock.Object, selectorService.Object);
        }

        [Test]
        public void ShouldReturnBadRequest_WhenParamsMissing()
        {
            var response = feeController.Get(new FeeCalculateRequest {  });
            var validationResult = response as BadRequestObjectResult;

            Assert.AreEqual(400, validationResult.StatusCode);
        }

        [Test]
        public void ShouldReturnBadRequest_WhenEntryTimeIsBiggerThanExitTime()
        {            
            var response = feeController.Get(new FeeCalculateRequest { EntryTime = DateTime.Now.AddDays(1), ExitTime = DateTime.Now});
            var validationResult = response as BadRequestObjectResult;

            Assert.AreEqual(400, validationResult.StatusCode);
        }

        [Test]
        public void ShouldReturnBadRequest_WhenDatesNotValid()
        {
            var response = feeController.Get(new FeeCalculateRequest { EntryTime = DateTime.MinValue, ExitTime = DateTime.Now });
            var validationResult = response as BadRequestObjectResult;

            Assert.AreEqual(400, validationResult.StatusCode);
        }

        [Test]
        public void ShouldReturnInternalServerError_WhenExceptionIsRaised()
        {
            selectorService.Setup(x => x.Calculate(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Throws(new Exception());
            var response = feeController.Get(new FeeCalculateRequest { EntryTime = DateTime.Now, ExitTime = DateTime.Now.AddHours(10) });
            var exceptionResult = response as ObjectResult;

            Assert.AreEqual(500, exceptionResult.StatusCode);
        }

        [Test]
        public void ShoudlReturnOkResponse_WhenProperDatesArePassedIn()
        {
            selectorService.Setup(x => x.Calculate(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(10);
            var response = feeController.Get(new FeeCalculateRequest { EntryTime = DateTime.Now, ExitTime = DateTime.Now.AddHours(10) });
            var okResult = response as OkObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
