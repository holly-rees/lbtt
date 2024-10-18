using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBTT_Calculator
{
    public class StandardTaxBandStrategy : ITaxBandStrategy
    {
        private int upperLimit;
        private int lowerLimit;
        private decimal rate;
        public StandardTaxBandStrategy(int lowerLimit, int upperLimit, decimal rate)
        {
            this.lowerLimit = lowerLimit;
            this.upperLimit = upperLimit;
            this.rate = rate;
        }
        public decimal CalculateTax(int propertyValue)
        {
            if (propertyValue < lowerLimit)
            {
                return 0;
            }
            else if (propertyValue <= upperLimit)
            {
                return (propertyValue - lowerLimit) * rate;
            }
            else
            {
                return (upperLimit - lowerLimit) * rate;
            }
        }
    }
}