using System;
using System.Collections.Generic;

namespace StringCalculator.Entities.Exceptions
{
    public class NegativeNumberException : Exception
    {
        private readonly IEnumerable<int> _negativeNumbers;
        public NegativeNumberException(IEnumerable<int> negativeNumbers)
            => _negativeNumbers = negativeNumbers;

        public override string Message =>
            $"Negative numbers entered: { string.Join(", ", _negativeNumbers) }.";
    }
}
