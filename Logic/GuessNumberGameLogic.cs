using GuessNumberGame.Interfaces;
using GuessNumberGame.Models;

namespace GuessNumberGame.Logic
{
    public class GuessNumberGameLogic : IGameLogic
    {
        private readonly IRandomNumberGenerator _randomGenerator;
        private int _targetNumber;
        private int _attemptsLeft;
        private int _totalAttempts;
        private bool _gameOver;
        private DifficultyLevel _currentDifficulty;

        public GuessNumberGameLogic(IRandomNumberGenerator randomGenerator)
        {
            _randomGenerator = randomGenerator;
        }

        public void StartNewGame(DifficultyLevel difficulty)
        {
            _currentDifficulty = difficulty;
            _targetNumber = _randomGenerator.Generate(difficulty.MinNumber, difficulty.MaxNumber);
            _totalAttempts = difficulty.MaxAttempts;
            _attemptsLeft = difficulty.MaxAttempts;
            _gameOver = false;
        }

        public GameResult MakeGuess(int guess)
        {
            if (_gameOver)
            {
                return new GameResult(GuessResult.GameOver, "Игра уже окончена! Начните новую игру.");
            }

            if (_attemptsLeft <= 0)
            {
                _gameOver = true;
                return new GameResult(GuessResult.GameOver,
                    $"Игра окончена! Вы использовали все попытки. Загаданное число: {_targetNumber}");
            }

            _attemptsLeft--;

            if (guess == _targetNumber)
            {
                _gameOver = true;
                return new GameResult(GuessResult.Correct,
                    $"Поздравляю! Вы угадали число {_targetNumber} за {_totalAttempts - _attemptsLeft} попыток!",
                    _targetNumber);
            }

            if (guess < _targetNumber)
            {
                return new GameResult(GuessResult.TooLow,
                    $"Загаданное число БОЛЬШЕ {guess}. Осталось попыток: {_attemptsLeft}");
            }
            else
            {
                return new GameResult(GuessResult.TooHigh,
                    $"Загаданное число МЕНЬШЕ {guess}. Осталось попыток: {_attemptsLeft}");
            }
        }

        public int GetTargetNumber() => _targetNumber;
        public int GetAttemptsLeft() => _attemptsLeft;
        public int GetTotalAttempts() => _totalAttempts;
        public bool IsGameOver() => _gameOver;
        public DifficultyLevel GetCurrentDifficulty() => _currentDifficulty;
    }
}