using UnityEngine;
using TMPro;

public class PuzzleController : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI winText;
    
    [Header("Win Condition")]
    [SerializeField] private int coinsNeededToWin = 3; // Satisfies Req 2 (Counter)
    
    private int coinsCollected = 0;
    private ScoreData scoreData = new ScoreData(); // Satisfies Req 4 (Pure C# Class)

    private void Start()
    {
        Time.timeScale = 1f;
        
        if (winText != null)
        {
            winText.gameObject.SetActive(false);
        }
    }

    public void CollectCoin(int points)
    {
        // Track score logic purely in C# class
        scoreData.AddPoints(points);
        
        // Track puzzle state progress
        coinsCollected++;

        // Check win condition based on coin count
        if (coinsCollected >= coinsNeededToWin)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        if (winText != null)
        {
            winText.gameObject.SetActive(true);
            winText.text = "You Win! Final Score: " + scoreData.CurrentScore;
        }
        
        Time.timeScale = 0f; 
    }
}