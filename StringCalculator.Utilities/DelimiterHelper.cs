using StringCalculator.Entities;
using StringCalculator.Entities.Exceptions;
using StringCalculator.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Utilities
{
    public class DelimiterHelper : IDelimiterHelper
    {
        private const string DELIMITER_BEGIN_STRING_CHAR = "//";
        private const string DELIMITER_BEGIN_STRING_STRING = "//[";

        private bool _processCharDelimiter;
        private bool _processStringDelimiter;

        public CustomDelimiter GetCustomDelimiter(string input)
        {
            var customDelimiter = new CustomDelimiter();
            _processStringDelimiter = input.StartsWith(DELIMITER_BEGIN_STRING_STRING);
            _processCharDelimiter = !_processStringDelimiter && input.StartsWith(DELIMITER_BEGIN_STRING_CHAR);

            if(_processStringDelimiter || _processCharDelimiter)
            {
                var index = input.IndexOf(@"\n");
                if (index > -1)
                {
                    var delimiterBeginString = _processCharDelimiter
                        ? DELIMITER_BEGIN_STRING_CHAR
                        : DELIMITER_BEGIN_STRING_STRING;
                    customDelimiter.Delimiters = 
                        ParseDelimiters(input.Substring(delimiterBeginString.Length, index - delimiterBeginString.Length),
                                        delimiterBeginString, 
                                        _processStringDelimiter);
                    if (_processCharDelimiter && customDelimiter.Delimiters.First().Length > 1)
                    {
                        throw new DelimiterTooLongException();
                    }
                    customDelimiter.LengthToRemoveFromInput = index;
                }
            }

            return customDelimiter;
        }

        private IEnumerable<string> ParseDelimiters(string input, string delimiterBeginString, bool isStringDelimiter)
        {
            var delimiters = new List<string>();
            if (isStringDelimiter)
            {
                var separators = new List<string> { @"[", @"]" };
                delimiters.AddRange(input.Split(separators.ToArray(), System.StringSplitOptions.RemoveEmptyEntries).ToList());
            }
            else
            {
                delimiters.Add(input);
            }
            return delimiters;
        }
    }
}
