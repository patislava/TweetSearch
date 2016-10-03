using System;
using System.Collections.Generic;
using System.Text;

namespace TweetSearchCore
{
    public interface IInputValidator
    {
        bool Validate(string input);
    }
}
