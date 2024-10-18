using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBTT_Calculator
{
    public class LBTTCalculator
    {

        private List<ITaxBandStrategy> taxBrackets;

        public LBTTCalculator(List<ITaxBandStrategy> taxBrackets)
        {
            this.taxBrackets = taxBrackets;
        }
        public decimal CalculateTax(int propertyValue)
        {
            decimal totalTax = 0;

            foreach (var bracket in taxBrackets)
            {
                totalTax += bracket.CalculateTax(propertyValue);
            }

            return totalTax;
        }
    }
}