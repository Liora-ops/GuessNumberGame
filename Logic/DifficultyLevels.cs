using GuessNumberGame.Models;
using System.Collections.Generic;

namespace GuessNumberGame.Logic
{
    public static class DifficultyLevels
    {
        public static List<DifficultyLevel> GetAllLevels()
        {
            return new List<DifficultyLevel>
            {
                new DifficultyLevel(
                    "1. Лёгкий",
                    1, 50, 10,
                    "Числа от 1 до 50, 10 попыток"
                ),
                new DifficultyLevel(
                    "2. Средний",
                    1, 100, 7,
                    "Числа от 1 до 100, 7 попыток"
                ),
                new DifficultyLevel(
                    "3. Сложный",
                    1, 200, 5,
                    "Числа от 1 до 200, 5 попыток"
                )
            };
        }
    }
}