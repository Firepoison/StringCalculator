using System;
using System.Collections.Generic;

namespace challenge_calculator
{
    public interface ICalculator
    {
        int AddString(String inputString);
        List<int> ValidateNumbers(String[] stringNumbers);
    } 
}
