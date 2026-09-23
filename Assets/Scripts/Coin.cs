using UnityEngine;

public class Coin : MonoBehaviour
{
    private AudioSource _coinAudioSource;
    
    [SerializeField] private AudioClip _coinAudio;
    private SpriteRenderer _spriteRenderer;
    private CircleCollider2D _collider;

    void Awake()
    {
        _coinAudioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GamaManager.Instance.AddCoin(); //llamamos a la funcion de añadir una moneda antes de matarla
            PlaySFX();
            _spriteRenderer.enabled = false;
            _collider.enabled = false;
            Destroy(gameObject, 0.5f);
        }
    }

    void PlaySFX()
    {
        _coinAudioSource.PlayOneShot(_coinAudio);
    }


}
