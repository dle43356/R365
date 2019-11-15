using StringCalculator.Services;
using StringCalculator.Utilities;
using System;

namespace StringCalculator
{
    class Program
    {
        private static bool keepRunning = true;
        static void Main(string[] args)
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(ExitHandler);
            while (keepRunning)
            {
                Console.WriteLine("Please enter numbers to add");
                var input = Console.ReadLine();
                // In production, would use DI
                try
                {
                    var calculatorService =
                        new CalculatorService(new InputProcessorService(new DelimiterHelper()),
                                              new ValidatorService());
                    Console.WriteLine($"Your result is: {calculatorService.CalculateToString(input)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine();
            }
        }

        private static void ExitHandler(object sender, ConsoleCancelEventArgs args)
        {
            args.Cancel = true;
            keepRunning = false;
        }
    }
}
