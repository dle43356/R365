using StringCalculator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly IInputProcessorService _inputProcessorService;
        private readonly IValidatorService _validatorService;

        public CalculatorService(IInputProcessorService inputProcessorService,
                                 IValidatorService validatorService)
        {
            _inputProcessorService = inputProcessorService;
            _validatorService = validatorService;
        }
        public int Calculate(string input)
        {
            var numbers = GetNumbers(input);
            return numbers.Sum();
        }

        public string CalculateToString(string input)
        {
            var numbers = GetNumbers(input);
            return $"{string.Join("+", numbers)} = {numbers.Sum()}";
        }

        private IEnumerable<int> GetNumbers(string input)
        {
            var numbers = _inputProcessorService.ProcessInput(input);
            var exception = _validatorService.Validate(numbers);
            if (exception != null)
            {
                throw exception;
            }
            return numbers;
        }
    }
}
