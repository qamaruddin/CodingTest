using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkingFeeCalculator.API.Services;
using ParkingFeeCalculator.API.ViewModels;
using System;

namespace ParkingFeeCalculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;
        private readonly IFeeRuleSelectorService _feeRuleSelectorService;

        public CalculatorController(ILogger<CalculatorController> logger, IFeeRuleSelectorService feeRuleSelectorService)
        {
            _logger = logger;
            _feeRuleSelectorService = feeRuleSelectorService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] FeeCalculateRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ValidationProblem(ModelState);
                }
                if (model.EntryTime == DateTime.MinValue || model.ExitTime == DateTime.MinValue)
                {
                    return BadRequest("Dates are not valid.");
                }
                if (model.EntryTime > model.ExitTime)
                {
                    return BadRequest("Entry date can't be newer than exit date.");
                }
                return Ok(_feeRuleSelectorService.Calculate(model.EntryTime, model.ExitTime));
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR AT {DateTime.Now} : An error happened while calculating parking fee for entry time {model.EntryTime} and end time {model.ExitTime}. Exception details {ex}.");
                return StatusCode(500, "Unable to calculate fee at the moment. Please try again later.");
            }
        }
    }
}
