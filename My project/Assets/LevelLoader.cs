using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string sceneToLoad;
    public AudioClip beep;

    void Update()
    {
        Keyboard kb = Keyboard.current;
        if (kb == null) return;

        if (kb.enterKey.wasPressedThisFrame)
            SceneManager.LoadScene(sceneToLoad);

        if (kb.spaceKey.wasPressedThisFrame)
            SoundManager.Instance.PlaySfx(beep);
    }
}
