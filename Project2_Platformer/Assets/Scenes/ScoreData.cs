public class ScoreData
{
    public int CurrentScore { get; private set; }

    public void AddPoints(int points)
    {
        CurrentScore += points;
    }

    public bool CheckWinCondition(int winThreshold)
    {
        return CurrentScore >= winThreshold;
    }
}