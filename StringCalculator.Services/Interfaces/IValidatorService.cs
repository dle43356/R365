using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator.Services.Interfaces
{
    public interface IValidatorService
    {
        Exception Validate(IEnumerable<int> numbers);
    }
}
