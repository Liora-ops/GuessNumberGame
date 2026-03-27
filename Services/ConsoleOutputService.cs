using GuessNumberGame.Interfaces;
using System;

namespace GuessNumberGame.Services
{
    public class ConsoleOutputService : IOutputService
    {
        public void Write(string message) => Console.Write(message);
        public void WriteLine(string message) => Console.WriteLine(message);
        public void WriteLine() => Console.WriteLine();
        public void Clear() => Console.Clear();
    }
}