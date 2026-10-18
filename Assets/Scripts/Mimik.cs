using UnityEngine;

public class Mimik : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 20;
    private int _actualHealth;

    [SerializeField] private int _quitarVidaPlayer = 20;
    [SerializeField] private float _timeBetweenAttacks = 2f;

    private float _attackTimer = 0f;
    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        _actualHealth = _maxHealth;
        _attackTimer = _timeBetweenAttacks;
    }

    void Update()
    {
        _attackTimer += Time.deltaTime;

        // Apagamos la animación de ataque 0.5 segundos después de haber atacado
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

        // Activa la animación
        _animator.SetBool("IsAttack", true);

        PlayerControler scriptPlayerControler = player.GetComponent<PlayerControler>();
        if (scriptPlayerControler != null)
        {
            scriptPlayerControler.RestarVida(_quitarVidaPlayer);
        }
    }
}

