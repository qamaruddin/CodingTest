using System;
using System.Collections.Generic;

namespace ParkingFeeCalculator.API.Services
{
    public class FeeRuleSelectorService : IFeeRuleSelectorService
    {
        private readonly IEnumerable<IParkingFeeCalculatorService> _parkingFeeCalculators;

        public FeeRuleSelectorService(IEnumerable<IParkingFeeCalculatorService> parkingFeeCalculators)
        {
            _parkingFeeCalculators = parkingFeeCalculators;
        }

        public double Calculate(DateTime entryTime, DateTime exitTime)
        {
            IParkingFeeCalculatorService applicableRate = null;

            foreach (var calculator in _parkingFeeCalculators)
            {
                if (calculator.IsRuleApplicable(entryTime, exitTime))
                {
                    applicableRate = calculator;
                    break;
                }
            }

            return applicableRate.Calculate(entryTime, exitTime);
        }
    }
}
