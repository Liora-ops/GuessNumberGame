using GuessNumberGame.Interfaces;
using GuessNumberGame.Models;

namespace GuessNumberGame.Logic
{
    public class GameController : IGameController
    {
        private readonly IOutputService _output;
        private readonly IInputService _input;
        private readonly IInputValidator _validator;
        private readonly IGameLogic _gameLogic;
        private readonly IGameConfiguration _config;

        public GameController(
            IOutputService output,
            IInputService input,
            IInputValidator validator,
            IGameLogic gameLogic,
            IGameConfiguration config)
        {
            _output = output;
            _input = input;
            _validator = validator;
            _gameLogic = gameLogic;
            _config = config;
        }

        public void Run()
        {
            bool playing = true;

            while (playing)
            {
                _output.Clear();
                ShowWelcomeMessage();
                SelectDifficulty();
                PlayGame();
                playing = AskToPlayAgain();
            }

            ShowGoodbyeMessage();
        }

        public void SelectDifficulty()
        {
            bool validChoice = false;

            while (!validChoice)
            {
                _output.WriteLine("\nВыберите уровень сложности:");

                var difficulties = _config.GetAllDifficulties();
                foreach (var diff in difficulties)
                {
                    _output.WriteLine($"{diff.Name} - {diff.Description}");
                }

                _output.Write("Ваш выбор (1-3): ");
                string choice = _input.ReadLine();

                if (int.TryParse(choice, out int level) && _config.IsValidDifficulty(level))
                {
                    var selectedDifficulty = _config.GetDifficulty(level);
                    _gameLogic.StartNewGame(selectedDifficulty);
                    validChoice = true;

                    _output.WriteLine($"\nВы выбрали {selectedDifficulty.Name}");
                    _output.WriteLine($"Диапазон: {selectedDifficulty.MinNumber} - {selectedDifficulty.MaxNumber}");
                    _output.WriteLine($"Попыток: {selectedDifficulty.MaxAttempts}");
                    _output.WriteLine("Начинаем игру!");
                    _output.WriteLine();
                }
                else
                {
                    _output.WriteLine("Неверный выбор! Пожалуйста, выберите 1, 2 или 3.");
                }
            }
        }

        public void PlayGame()
        {
            var difficulty = _gameLogic.GetCurrentDifficulty();
            bool gameActive = true;

            while (gameActive && !_gameLogic.IsGameOver())
            {
                _output.Write($"Введите число от {difficulty.MinNumber} до {difficulty.MaxNumber}: ");
                string input = _input.ReadLine();

                if (_validator.IsValidNumber(input, out int guess, difficulty.MinNumber, difficulty.MaxNumber))
                {
                    var result = _gameLogic.MakeGuess(guess);
                    _output.WriteLine(result.Message);

                    if (result.Result == GuessResult.Correct || result.Result == GuessResult.GameOver)
                    {
                        gameActive = false;
                    }
                }
                else
                {
                    _output.WriteLine(_validator.GetErrorMessage());
                }
            }
        }

        public bool AskToPlayAgain()
        {
            _output.WriteLine("\nХотите сыграть еще? (y/n): ");
            string response = _input.ReadLine()?.ToLower();

            while (response != "y" && response != "n" && response != "да" && response != "нет")
            {
                _output.Write("Пожалуйста, введите 'y' (да) или 'n' (нет): ");
                response = _input.ReadLine()?.ToLower();
            }

            return response == "y" || response == "да";
        }

        private void ShowWelcomeMessage()
        {
            _output.WriteLine("========================================");
            _output.WriteLine("       ДОБРО ПОЖАЛОВАТЬ В ИГРУ");
            _output.WriteLine("          'УГАДАЙ ЧИСЛО'");
            _output.WriteLine("========================================");
        }

        private void ShowGoodbyeMessage()
        {
            _output.WriteLine("\n========================================");
            _output.WriteLine("    Спасибо за игру! До встречи!");
            _output.WriteLine("========================================");
        }
    }
}