using System;
using System.Collections.Generic;

namespace ParkingFeeCalculator.API.Services
{
    public class FeeRuleSelectorService
    {
        private readonly IEnumerable<IParkingFeeCalculatorService> parkingFeeCalculators;

        public FeeRuleSelectorService(IEnumerable<IParkingFeeCalculatorService> parkingFeeCalculators)
        {
            this.parkingFeeCalculators = parkingFeeCalculators;
        }

        public double Calculate(DateTime entryTime, DateTime exitTime)
        {
            IParkingFeeCalculatorService applicableRate = null;
            
            foreach (var calculator in parkingFeeCalculators)
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
