using UnityEngine;
using UnityEngine.InputSystem;

public class VolumeKeys : MonoBehaviour
{
    public AudioSource music;
    public float step = 0.1f;

    void Update()
    {
        Keyboard kb = Keyboard.current;
        if (kb == null) return;

        if (kb.upArrowKey.wasPressedThisFrame)
        {
            music.volume = Mathf.Clamp01(music.volume + step);
            Debug.Log("Music volume: " + music.volume.ToString("F1"));
        }

        if (kb.downArrowKey.wasPressedThisFrame)
        {
            music.volume = Mathf.Clamp01(music.volume - step);
            Debug.Log("Music volume: " + music.volume.ToString("F1"));
        }
    }
}