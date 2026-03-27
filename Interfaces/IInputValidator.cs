namespace GuessNumberGame.Interfaces
{
    public interface IInputValidator
    {
        bool IsValidNumber(string input, out int number, int minValue, int maxValue);
        string GetErrorMessage();
    }
}