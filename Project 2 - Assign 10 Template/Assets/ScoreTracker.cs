// Pure C# class holding game logic, no MonoBehaviour
public class ScoreTracker
{
    private int currentScore = 0;

    public void AddPoints(int amount)
    {
        currentScore += amount;
    }

    public int GetScore()
    {
        return currentScore;
    }
}