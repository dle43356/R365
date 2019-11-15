using StringCalculator.Entities;
using StringCalculator.Entities.Exceptions;
using StringCalculator.Utilities.Interfaces;
using System;

namespace StringCalculator.Utilities
{
    public class DelimiterHelper : IDelimiterHelper
    {
        private const string DELIMITER_BEGIN_STRING = "//";

        public CustomDelimiter GetCustomDelimiter(string input)
        {
            var customDelimiter = new CustomDelimiter();
            if (input.StartsWith(DELIMITER_BEGIN_STRING))
            {
                var index = input.IndexOf(@"\n");
                if (index > -1)
                {
                    customDelimiter.Delimiter =
                        input.Substring(DELIMITER_BEGIN_STRING.Length, index - DELIMITER_BEGIN_STRING.Length);
                    if (customDelimiter.Delimiter.Length > 1)
                    {
                        throw new DelimiterTooLongException();
                    }
                    customDelimiter.LengthToRemoveFromInput = customDelimiter.Delimiter.Length + DELIMITER_BEGIN_STRING.Length;
                }
            }

            return customDelimiter;

        }
    }
}
