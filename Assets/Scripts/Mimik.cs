using UnityEngine;

public class Mimik : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 20;
    private int _actualHealth;

    [SerializeField] private int _quitarVidaPlayer = 20;

    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        _actualHealth = _maxHealth;
    }


    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        _actualHealth -= damage;

        if(_actualHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _animator.SetBool("IsAttack", true);
            PlayerControler scriptPlayerControler = collision.gameObject.GetComponent<PlayerControler>();
            scriptPlayerControler.RestarVida(_quitarVidaPlayer);


            //PlaySFX();
        }
    }
}
