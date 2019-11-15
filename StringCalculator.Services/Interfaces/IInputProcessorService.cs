using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator.Services.Interfaces
{
    public interface IInputProcessorService
    {
        IEnumerable<int> ProcessInput(string input);


    }
}
