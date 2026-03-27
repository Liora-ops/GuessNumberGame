using GuessNumberGame.Models;

namespace GuessNumberGame.Interfaces
{
    public interface IGameLogic
    {
        void StartNewGame(DifficultyLevel difficulty);
        GameResult MakeGuess(int guess);
        int GetTargetNumber();
        int GetAttemptsLeft();
        int GetTotalAttempts();
        bool IsGameOver();
        DifficultyLevel GetCurrentDifficulty();
    }
}