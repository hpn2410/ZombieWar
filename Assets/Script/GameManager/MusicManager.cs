using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    [Header("Audio")]
    public AudioSource BackGroundAudio;
    public AudioSource LevelBgAudio;
    public AudioSource FireAudio;
    public AudioSource PlayerPain;
    public AudioSource ZombiePain;
    public AudioSource ZombieDeath;
    public AudioSource BombExplose;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySound(AudioSource soundToPlay)
    {
        soundToPlay.Play();
    }

    public void StopSound(AudioSource soundToStop)
    {
        if (soundToStop.isPlaying)
            soundToStop.Stop();
    }
}
