using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // Restoring the Singleton Instance so your CoinPickup script can find it
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioSource sfxSource;

    private void Awake()
    {
        // Requirement 3: Persistent audio object with duplicates guarded against
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Load the saved volume (defaults to 0 dB if playing for the first time)
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 0f);
        ApplyVolume(savedVolume);
    }

    public void ApplyVolume(float volume)
    {
        // Apply to the mixer
        if (mixer != null)
        {
            mixer.SetFloat("MasterVolume", volume);
        }
        
        // Save the setting so it persists across relaunches
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (sfxSource != null && clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}