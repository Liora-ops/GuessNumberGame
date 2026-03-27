namespace GuessNumberGame.Interfaces
{
    public interface IOutputService
    {
        void Write(string message);
        void WriteLine(string message);
        void WriteLine();
        void Clear();
    }
}