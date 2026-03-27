using GuessNumberGame.Interfaces;

namespace GuessNumberGame.Services
{
    public class NumberInputValidator : IInputValidator
    {
        private string _errorMessage;

        public bool IsValidNumber(string input, out int number, int minValue, int maxValue)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                _errorMessage = "Ввод не может быть пустым!";
                number = 0;
                return false;
            }

            if (!int.TryParse(input, out number))
            {
                _errorMessage = "Пожалуйста, введите целое число!";
                return false;
            }

            if (number < minValue || number > maxValue)
            {
                _errorMessage = $"Число должно быть в диапазоне от {minValue} до {maxValue}!";
                return false;
            }

            return true;
        }

        public string GetErrorMessage() => _errorMessage;
    }
}