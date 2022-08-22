namespace Code.Service
{
    // PatternSolver contains the responsability to find the patter given an input
    // Strategy Pattern
    public interface IPatternSolver
    {
        string FindPattern(string input);
    }

    public class PatternSolver : IPatternSolver
    {
        public string FindPattern(string input)
        {
            // All the validation should be move to other place to be focued in the logic
            // probably we could use FluentValidation 
            if (input == null) throw new ArgumentNullException("input");
            if (input.Length == 0) return string.Empty;
            if (input.Length == 1 || input.Length == 2) return input;

            if (input.Length % 2 == 0)
                return input.Substring(input.Length/2 - 1, 2);
            else
                return input.Substring(input.Length/2 , 1);
        }
    }
}