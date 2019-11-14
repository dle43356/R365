using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator.Entities.Exceptions
{
    public class TooManyNumbersException : Exception
    {
        public override string Message => "Too many numbers were entered.";
    }
}
