using UnityEngine;

public class Coin : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GamaManager.Instance.AddCoin(); //llamamos a la funcion de añadir una moneda antes de matarla
            Destroy(gameObject);
        }
    }


}
