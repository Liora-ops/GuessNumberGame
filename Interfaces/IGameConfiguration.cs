using GuessNumberGame.Models;
using System.Collections.Generic;

namespace GuessNumberGame.Interfaces
{
    public interface IGameConfiguration
    {
        DifficultyLevel GetDifficulty(int level);
        List<DifficultyLevel> GetAllDifficulties();
        bool IsValidDifficulty(int level);
    }
}