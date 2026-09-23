using UnityEngine;

public class Corazon : MonoBehaviour
{
    private AudioSource _corazonAudioSource;

    [SerializeField] private int _curarVida = 20;
    
    [SerializeField] private AudioClip _corazonAudio;
    private SpriteRenderer _spriteRenderer;
    private CircleCollider2D _collider;

    void Awake()
    {
        _corazonAudioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerControler corazonScript = collision.GetComponent<PlayerControler>();
            corazonScript.CurarVida(_curarVida);

            PlaySFX();
            _spriteRenderer.enabled = false;
            _collider.enabled = false;
            Destroy(gameObject, 0.5f);
        }
    }

    void PlaySFX()
    {
        _corazonAudioSource.PlayOneShot(_corazonAudio);
    }

}
