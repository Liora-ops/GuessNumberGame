namespace GuessNumberGame.Interfaces
{
    public interface IGameController
    {
        void Run();
        void SelectDifficulty();
        void PlayGame();
        bool AskToPlayAgain();
    }
}