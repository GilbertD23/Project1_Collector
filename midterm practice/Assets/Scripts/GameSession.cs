using UnityEngine;

// A static class (never attached to an object). Holds the score and the saved high score.
public static class GameSession
{
    const string HighScoreKey = "HighScore";

    public static int Score;

    public static int HighScore
    {
        get { return PlayerPrefs.GetInt(HighScoreKey, 0); }
    }

    public static void NewGame()
    {
        Score = 0;
    }

    public static void SaveHighScore()
    {
        if (Score > HighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, Score);
            PlayerPrefs.Save();
            Debug.Log("New high score saved: " + Score);
        }
    }
}
