using UnityEngine;

public class Coin : MonoBehaviour
{
    private AudioSource _coinAudioSource;
    
    [SerializeField] private AudioClip _coinAudio;

    void Awake()
    {
        _coinAudioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GamaManager.Instance.AddCoin(); //llamamos a la funcion de añadir una moneda antes de matarla
            PlaySFX();
            Destroy(gameObject);
        }
    }

    void PlaySFX()
    {
        _coinAudioSource.PlayOneShot(_coinAudio);
    }


}
