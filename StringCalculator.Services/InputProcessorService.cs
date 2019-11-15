using StringCalculator.Services.Interfaces;
using StringCalculator.Utilities.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Services
{
    public class InputProcessorService : IInputProcessorService
    {
        private IList<string> _baseDelimiters = new List<string> { @",", @"\n" };
        private int _maxNumber = 1000;

        private readonly IDelimiterHelper _delimiterHelper;

        public InputProcessorService(IDelimiterHelper delimiterHelper) => _delimiterHelper = delimiterHelper;

        private IList<string> GetDefaultDelimiters() => _baseDelimiters.Select(x => x).ToList();

        public IEnumerable<int> ProcessInput(string input)
        {
            var delimiters = GetDefaultDelimiters().ToList();

            var customDelimiter = _delimiterHelper.GetCustomDelimiter(input);
            if (customDelimiter?.Delimiters?.Count() > 0)
            {
                delimiters.AddRange(customDelimiter.Delimiters.ToList());
                input = input.Substring(customDelimiter.LengthToRemoveFromInput);
            }
            var segments = input.Split(delimiters.ToArray(), System.StringSplitOptions.RemoveEmptyEntries).ToList();
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
