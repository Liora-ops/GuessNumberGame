namespace GuessNumberGame.Models
{
    /// <summary>
    /// Перечисление результатов угадывания числа
    /// </summary>
    public enum GuessResult
    {
        /// <summary>
        /// Число угадано правильно
        /// </summary>
        Correct = 0,

        /// <summary>
        /// Загаданное число больше
        /// </summary>
        TooLow = 1,

        /// <summary>
        /// Загаданное число меньше
        /// </summary>
        TooHigh = 2,

        /// <summary>
        /// Игра закончена (попытки исчерпаны)
        /// </summary>
        GameOver = 3
    }
}
