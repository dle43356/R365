using StringCalculator.Entities.Exceptions;
using StringCalculator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator.Services
{
    public class ValidatorService : IValidatorService
    {
        Exception IValidatorService.Validate(IEnumerable<int> numbers)
            => numbers.Any(x => x < 0)
                ? new NegativeNumberException(numbers.Where(x => x < 0))
                : null;
    }
}
