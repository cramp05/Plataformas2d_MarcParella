using UnityEngine;

public class Mimik : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 20;
    private int _actualHealth;

    [SerializeField] private int _quitarVidaPlayer = 20;
    [SerializeField] private float _timeBetweenAttacks = 2f;

    [SerializeField] private AudioClip _attackSound; // So del m�mic atac
    private AudioSource _audioSource;

    private float _attackTimer = 0f;
    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        _actualHealth = _maxHealth;
        _attackTimer = _timeBetweenAttacks;
    }

    void Update()
    {
        _attackTimer += Time.deltaTime;

        if (_attackTimer >= 0.5f)
        {
            _animator.SetBool("IsAttack", false);
        }
    }

    public void TakeDamage(int damage)
    {
        _actualHealth -= damage;

        if (_actualHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_attackTimer >= _timeBetweenAttacks)
            {
                Atacar(collision.gameObject);
            }
        }
    }

    private void Atacar(GameObject player)
    {
        _attackTimer = 0f;

        _animator.SetBool("IsAttack", true);

        if (_attackSound != null && _audioSource != null)
        {
            _audioSource.PlayOneShot(_attackSound);
        }

        PlayerControler scriptPlayerControler = player.GetComponent<PlayerControler>();
        if (scriptPlayerControler != null)
        {
            scriptPlayerControler.RestarVida(_quitarVidaPlayer);
        }
    }
}

