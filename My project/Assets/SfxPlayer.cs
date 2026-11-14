using UnityEngine;
using UnityEngine.InputSystem;

public class SfxPlayer : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    void Update()
    {
        Keyboard kb = Keyboard.current;
        if (kb != null && kb.fKey.wasPressedThisFrame)
        {
            source.PlayOneShot(clip, 0.8f);
        }
    }
}
