// See https://aka.ms/new-console-template for more information

namespace LBTT_Calculator
{
    public class Application
    {
        public static void Main()
        {
            Application.Run();
        }
        public static void Run()
        {
            List<ITaxBandStrategy> residentalTaxBrackets = TaxBandStrategiesFactory.CreateResidentialTaxBands();

            LBTTCalculator calculator = new LBTTCalculator(residentalTaxBrackets);

            Console.WriteLine("LBBT Tax Calculator");
            Console.WriteLine("Enter property price:");
            try
            {
                int propertyValue = int.Parse(Console.ReadLine());
                decimal tax = calculator.CalculateTax(propertyValue);
                Console.WriteLine("Tax due: " + tax);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message + " Make sure you enter a valid integer!");
            }
        }
    }
}