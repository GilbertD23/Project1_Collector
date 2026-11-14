using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

// Goes on OverlayManager (Cavern scene) and TitleManager (TitleScreen scene). Fill only the fields that scene uses.
public class OverlayController : MonoBehaviour
{
    [SerializeField] TMP_Text gemLabel;
    [SerializeField] TMP_Text recordLabel;
    [SerializeField] GameObject pauseMenu;

    private bool pausedNow = false;

    void Update()
    {
        if (gemLabel != null) gemLabel.text = "Gems: " + RunState.Gems;
        if (recordLabel != null) recordLabel.text = "Record: " + RunState.Record;

        // Update still runs while Time.timeScale is 0, so this check keeps working.
        if (pauseMenu != null && Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (pausedNow) ClosePause();
            else OpenPause();
        }
    }

    public void OpenPause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pausedNow = true;
    }

    public void ClosePause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        pausedNow = false;
    }

    void OnDestroy()
    {
        // timeScale is global and survives scene loads, so always reset it.
        Time.timeScale = 1f;
    }
}
