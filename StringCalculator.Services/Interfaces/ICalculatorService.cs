using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator.Services.Interfaces
{
    public interface ICalculatorService
    {
        int Calculate(string input);
        string CalculateToString(string input);

    }
}
