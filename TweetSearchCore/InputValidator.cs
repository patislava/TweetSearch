namespace TweetSearchWPF
{
    public class InputValidator : IInputValidator
    {
        public bool Validate(string input)
        {
            string pattern = @"^#\w+$";

            if (System.Text.RegularExpressions.Regex.IsMatch(input, pattern) && input.Length <= 140)
            {
                return true;
            }

            return false;
        }
    }
}
