using StringCalculator.Entities.Exceptions;
using StringCalculator.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Services
{
    public class InputProcessorService : IInputProcessorService
    {
        private string[] _delimiters = { @",", @"\n" };

        public IEnumerable<int> ProcessInput(string input)
        {
            var segments = input.Split(_delimiters, System.StringSplitOptions.RemoveEmptyEntries).ToList();
            var numbers = new List<int>();
            segments.ForEach(x =>
            {
                int number;
                if(int.TryParse(x, out number))
                {
                    numbers.Add(number);
                }
                else
                {
                    numbers.Add(0);
                }
            });
            return numbers;
        }
    }
}
