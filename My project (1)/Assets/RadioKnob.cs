using UnityEngine;
using UnityEngine.InputSystem;

public class RadioKnob : MonoBehaviour
{
    public AudioSource radio;
    public float step = 0.1f;

    void Update()
    {
        Keyboard kb = Keyboard.current;
        if (kb == null) return;

        if (kb.upArrowKey.wasPressedThisFrame)
        {
            radio.volume = Mathf.Clamp01(radio.volume + step);
            Debug.Log("Radio volume: " + radio.volume.ToString("F1"));
        }
        if (kb.downArrowKey.wasPressedThisFrame)
        {
            radio.volume = Mathf.Clamp01(radio.volume - step);
            Debug.Log("Radio volume: " + radio.volume.ToString("F1"));
        }
    }
}
