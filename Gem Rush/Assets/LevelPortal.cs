using UnityEngine;
using UnityEngine.SceneManagement;

// Goes on Exit (loads a scene when the miner touches it) and on TitleManager (Button On Click).
public class LevelPortal : MonoBehaviour
{
    [SerializeField] string destinationScene = "TitleScreen";
    [SerializeField] bool recordOnEnter = false;

    public void GoToScene(string targetScene)
    {
        if (targetScene == "Cavern") RunState.Gems = 0;
        SceneManager.LoadScene(targetScene);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Miner")) return;

        if (recordOnEnter) RunState.StoreRecord();
        SceneManager.LoadScene(destinationScene);
    }
}
