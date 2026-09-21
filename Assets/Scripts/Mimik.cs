using UnityEngine;

public class Mimik : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 20;
    private int _actualHealth;


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
}
