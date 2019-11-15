using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator.Entities
{
    public class CustomDelimiter
    {
        public IEnumerable<string> Delimiters { get; set; }
        public int LengthToRemoveFromInput { get; set; }
    }
}
