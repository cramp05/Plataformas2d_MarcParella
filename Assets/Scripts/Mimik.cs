using UnityEngine;

public class Mimik : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 20;
    private int _actualHealth;


    void Start()
    {
        _actualHealth = _maxHealth;

        TakeDamage(10);
    }


    void Update()
    {
        
    }

    void TakeDamage(int damage)
    {
        _actualHealth -= damage;
    }
}
