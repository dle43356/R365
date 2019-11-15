using StringCalculator.Services.Interfaces;
using StringCalculator.Utilities.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Services
{
    public class InputProcessorService : IInputProcessorService
    {
        private IList<string> _delimiters = new List<string> { @",", @"\n" };
        private int _maxNumber = 1000;

        private readonly IDelimiterHelper _delimiterHelper;

        public InputProcessorService(IDelimiterHelper delimiterHelper) => _delimiterHelper = delimiterHelper;

        public IEnumerable<int> ProcessInput(string input)
        {
            var customDelimiter = _delimiterHelper.GetCustomDelimiter(input);
            if (!string.IsNullOrEmpty(customDelimiter?.Delimiter))
            {
                _delimiters.Add(customDelimiter.Delimiter);
                input = input.Substring(customDelimiter.LengthToRemoveFromInput);
            }
            var segments = input.Split(_delimiters.ToArray(), System.StringSplitOptions.RemoveEmptyEntries).ToList();
            var numbers = new List<int>();
            segments.ForEach(x =>
            {
                int number;
                if(int.TryParse(x, out number))
                {
                    numbers.Add(number <= _maxNumber ? number : 0);
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
