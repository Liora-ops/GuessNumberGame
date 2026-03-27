using GuessNumberGame.Interfaces;
using System;

namespace GuessNumberGame.Services
{
    public class ConsoleInputService : IInputService
    {
        public string ReadLine() => Console.ReadLine();
    }
}