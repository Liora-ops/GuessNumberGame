using GuessNumberGame.Interfaces;
using GuessNumberGame.Logic;
using GuessNumberGame.Models;
using System.Collections.Generic;

namespace GuessNumberGame.Configuration
{
    public class GameConfiguration : IGameConfiguration
    {
        private readonly List<DifficultyLevel> _difficulties;

        public GameConfiguration()
        {
            _difficulties = DifficultyLevels.GetAllLevels();
        }

        public DifficultyLevel GetDifficulty(int level)
        {
            if (level >= 1 && level <= _difficulties.Count)
            {
                return _difficulties[level - 1];
            }

            return _difficulties[0];
        }

        public List<DifficultyLevel> GetAllDifficulties()
        {
            return _difficulties;
        }

        public bool IsValidDifficulty(int level)
        {
            return level >= 1 && level <= _difficulties.Count;
        }
    }
}