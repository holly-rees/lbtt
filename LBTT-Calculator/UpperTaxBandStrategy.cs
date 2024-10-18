using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBTT_Calculator
{
    public class UpperTaxBandStrategy : ITaxBandStrategy
    {
        private int lowerLimit;
        private decimal rate;
        public UpperTaxBandStrategy(int lowerLimit, decimal rate)
        {
            this.lowerLimit = lowerLimit;
            this.rate = rate;
        }
        public decimal CalculateTax(int propertyValue)
        {
            decimal taxableAmount = Math.Max(propertyValue - lowerLimit, 0);
            return taxableAmount * rate;
        }
    }
}