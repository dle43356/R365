using StringCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator.Utilities.Interfaces
{
    public interface IDelimiterHelper
    {
        CustomDelimiter GetCustomDelimiter(string input);
    }
}
