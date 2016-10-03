using System;
using System.Collections.Generic;
using System.Text;

namespace TweetSearchCore
{
    public class InputValidator : IInputValidator
    {
        public bool Validate(string input)
        {
            string pattern = @"(?<=#)\w+";

            if (System.Text.RegularExpressions.Regex.IsMatch(input, pattern))
            {
                return true;
            }

            return false;
        }
    }
}
