using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBTT_Calculator
{
    public class TaxBandStrategiesFactory
    {
        public static List<ITaxBandStrategy> CreateResidentialTaxBands()
        {
            return new List<ITaxBandStrategy>
            {
                new StandardTaxBandStrategy(0, 145000, 0.00m),
                new StandardTaxBandStrategy(145000, 250000, 0.02m),
                new StandardTaxBandStrategy(250000, 325000, 0.05m),
                new StandardTaxBandStrategy(325000, 750000, 0.1m),
                new UpperTaxBandStrategy(750000, 0.12m)
            };
        }

        public static List<ITaxBandStrategy> CreateNonResidentialTaxBands()
        {
            return new List<ITaxBandStrategy>
            {
                new StandardTaxBandStrategy(0, 150000, 0.00m),
                new StandardTaxBandStrategy(150000, 250000, 0.01m),
                new UpperTaxBandStrategy(250000, 0.05m)
            };
        }
    }
}