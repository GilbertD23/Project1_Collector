using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // Added for new Input System

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI;

    void Update()
    {
        // New Input System check for Escape key
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (pauseMenuUI.activeSelf) Resume();
            else Pause();
        }
    }

    public void Resume()
    {
        if (pauseMenuUI != null) pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        if (pauseMenuUI != null) pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
