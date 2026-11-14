using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

// Goes on GameManager (Game scene) and MenuManager (MainMenu scene). Fill only the fields that scene uses.
public class HudController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreLabel;
    [SerializeField] TMP_Text bestLabel;
    [SerializeField] GameObject pausePanel;

    private bool isPaused = false;

    void Update()
    {
        if (scoreLabel != null) scoreLabel.text = "Coins: " + GameSession.Score;
        if (bestLabel != null) bestLabel.text = "Best: " + GameSession.HighScore;

        // Update still runs while Time.timeScale is 0, so this check keeps working.
        if (pausePanel != null && Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (isPaused) Resume();
            else Pause();
        }
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void OnDestroy()
    {
        // timeScale is global and survives scene loads, so always reset it.
        Time.timeScale = 1f;
    }
}
