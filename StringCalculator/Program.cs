using StringCalculator.Services;
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
                Console.WriteLine(new CalculatorService(new InputProcessorService()).Calculate(input));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
