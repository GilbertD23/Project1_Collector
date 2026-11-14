using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioMixer mixer;
    public AudioSource sfxSource;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Load saved volume
        float savedVol = PlayerPrefs.GetFloat("MusicVolume", 1f);
        mixer.SetFloat("MusicVolParam", Mathf.Log10(savedVol) * 20);
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void SaveVolume(float vol)
    {
        PlayerPrefs.SetFloat("MusicVolume", vol);
        PlayerPrefs.Save();
    }
}
