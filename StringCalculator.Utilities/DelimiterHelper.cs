using StringCalculator.Entities;
using StringCalculator.Entities.Exceptions;
using StringCalculator.Utilities.Interfaces;
using System;

namespace StringCalculator.Utilities
{
    public class DelimiterHelper : IDelimiterHelper
    {
        private const string DELIMITER_BEGIN_STRING_SINGLE_CHAR = "//";
        private const string DELIMITER_BEGIN_STRING = "//[";

        private bool _processSingleCharDelimiter;
        private bool _processMultipleCharDelimiter;

        public CustomDelimiter GetCustomDelimiter(string input)
        {
            var customDelimiter = new CustomDelimiter();
            _processMultipleCharDelimiter = input.StartsWith(DELIMITER_BEGIN_STRING);
            _processSingleCharDelimiter = !_processMultipleCharDelimiter && input.StartsWith(DELIMITER_BEGIN_STRING_SINGLE_CHAR);

            if(_processMultipleCharDelimiter || _processSingleCharDelimiter)
            {
                var index = input.IndexOf(@"\n");
                if (index > -1)
                {
                    var delimiterBeginString = _processSingleCharDelimiter
                        ? DELIMITER_BEGIN_STRING_SINGLE_CHAR
                        : DELIMITER_BEGIN_STRING;
                    customDelimiter.Delimiter =
                        input.Substring(delimiterBeginString.Length, index - (delimiterBeginString.Length + (_processMultipleCharDelimiter ? 1 : 0)));
                    if (_processSingleCharDelimiter && customDelimiter.Delimiter.Length > 1)
                    {
                        throw new DelimiterTooLongException();
                    }
                    customDelimiter.LengthToRemoveFromInput = 
                        customDelimiter.Delimiter.Length + delimiterBeginString.Length + (_processMultipleCharDelimiter ? 1 : 0);
                }
            }

            return customDelimiter;

        }
    }
}
