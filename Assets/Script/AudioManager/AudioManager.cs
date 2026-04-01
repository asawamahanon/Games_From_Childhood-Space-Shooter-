using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("Audio Clips")]
    public AudioClip BackgroundBattle;
    public AudioClip BackGroundStartAndEnd;
    public AudioClip ExplosionUnderSnowSFX;
    public AudioClip LaserShot;

    void Start()
    {
        
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name ==  "GameOver"|| UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Home")
        {
            musicSource.clip = BackGroundStartAndEnd;
            musicSource.Play();
        }
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "FristSecne")
        { 
            musicSource.clip = BackgroundBattle;
            musicSource.Play();
        }
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
