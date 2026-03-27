namespace GuessNumberGame.Models
{
    public class DifficultyLevel
    {
        public string Name { get; set; }
        public int MinNumber { get; set; }
        public int MaxNumber { get; set; }
        public int MaxAttempts { get; set; }
        public string Description { get; set; }

        public DifficultyLevel(string name, int min, int max, int attempts, string description)
        {
            Name = name;
            MinNumber = min;
            MaxNumber = max;
            MaxAttempts = attempts;
            Description = description;
        }
    }
}