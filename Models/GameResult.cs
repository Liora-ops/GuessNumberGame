namespace GuessNumberGame.Models
{
    // Это enum (перечисление)
    public enum GuessResult
    {
        TooLow,
        TooHigh,
        Correct,
        InvalidInput,
        GameOver
    }

    // Это class
    public class GameResult
    {
        public GuessResult Result { get; set; }
        public string Message { get; set; }
        public int? GuessedNumber { get; set; }

        public GameResult(GuessResult result, string message, int? guessedNumber = null)
        {
            Result = result;
            Message = message;
            GuessedNumber = guessedNumber;
        }
    }
}