using StringCalculator.Services;
using StringCalculator.Utilities;
using System;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter numbers to add");
            var input = Console.ReadLine();
            // In production, would use DI
            try
            {
                var calculatorService =
                    new CalculatorService(new InputProcessorService(new DelimiterHelper()),
                                          new ValidatorService());
                Console.WriteLine(calculatorService.Calculate(input));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
