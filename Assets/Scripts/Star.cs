using UnityEngine;

public class Star : MonoBehaviour
{
    private AudioSource _starAudioSource;
    
    [SerializeField] private AudioClip _starAudio;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _collider;

    void Awake()
    {
        _starAudioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GamaManager.Instance.AddStar(); //llamamos a la funcion de añadir una moneda antes de matarla
            PlaySFX();
            _spriteRenderer.enabled = false;
            _collider.enabled = false;
            Destroy(gameObject, 0.5f);
        }
    }

    void PlaySFX()
    {
        _starAudioSource.PlayOneShot(_starAudio);
    }

}
