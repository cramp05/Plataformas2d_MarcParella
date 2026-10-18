using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private AudioSource _audioSource;

    [SerializeField] private AudioClip _menuSoundTrack;
    [SerializeField] private AudioClip _level1soundtrack;
    [SerializeField] private AudioClip _gameOverSoundTrack;
    [SerializeField] private AudioClip _gameOverSFX;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;
        if (_audioSource.clip == clip && _audioSource.isPlaying) return;

        _audioSource.clip = clip;
        _audioSource.loop = true;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }

    public void PlayMenuMusic()
    {
        PlayMusic(_menuSoundTrack);
    }

    public void PlayLevel1Music()
    {
        PlayMusic(_level1soundtrack);
    }

    public void PlayGameOverMusic()
    {
        PlayMusic(_gameOverSoundTrack);
    }

    public void PlayGameOverSFX()
    {
        StopMusic();
        if (_gameOverSFX != null)
        {
            _audioSource.PlayOneShot(_gameOverSFX);
        }
    }

    public void StartSoundTranck()
    {
        PlayLevel1Music();
    }

    public void PauseSoundtrack()
    {
        _audioSource.Pause();
    }

    public void ResumeSoundtrack()
    {
        _audioSource.UnPause();
    }
}
