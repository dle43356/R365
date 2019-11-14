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

        public CalculatorService(IInputProcessorService inputProcessorService)
        {
            _inputProcessorService = inputProcessorService;
        }
        public int Calculate(string input)
        {
            var numbers = _inputProcessorService.ProcessInput(input);
            return numbers.Sum();
        }
    }
}
