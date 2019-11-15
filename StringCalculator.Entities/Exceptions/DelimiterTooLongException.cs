using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator.Entities.Exceptions
{
    public class DelimiterTooLongException : Exception
    {
        public override string Message => "Delimiter has too many characters.";
    }
}
