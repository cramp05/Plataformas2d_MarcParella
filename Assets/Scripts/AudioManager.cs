using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private AudioSource _audioSource;

    [SerializeField] private AudioClip _level1soundtrack;

    void awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        _audioSource = GetComponent<AudioSource>();

    }

    public void StartSoundTranck()
    {
        _audioSource.clip = _level1soundtrack; //rellenamos el audiosource con el clip que pongamos
        _audioSource.Play();
    }

    public void PauseSoundtrack()
    {
        _audioSource.Pause();
    }
}
