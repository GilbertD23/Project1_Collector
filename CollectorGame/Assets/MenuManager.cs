using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        // Make sure "SampleScene" exactly matches your gameplay scene's name
        SceneManager.LoadScene("SampleScene"); 
    }
}