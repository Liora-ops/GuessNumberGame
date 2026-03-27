using GuessNumberGame.Configuration;
using GuessNumberGame.Interfaces;
using GuessNumberGame.Logic;
using GuessNumberGame.Services;
using System;

namespace GuessNumberGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Угадай число";
            Console.ForegroundColor = ConsoleColor.Cyan;

            IOutputService output = new ConsoleOutputService();
            IInputService input = new ConsoleInputService();
            IInputValidator validator = new NumberInputValidator();
            IRandomNumberGenerator randomGenerator = new RandomNumberGeneratorService();
            IGameLogic gameLogic = new GuessNumberGameLogic(randomGenerator);
            IGameConfiguration config = new GameConfiguration();

            IGameController controller = new GameController(
                output, input, validator, gameLogic, config);

            controller.Run();
        }
    }
}