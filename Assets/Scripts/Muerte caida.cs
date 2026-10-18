using UnityEngine;

public class Muertecaida : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerControler player = collision.gameObject.GetComponent<PlayerControler>();
            if (player != null)
            {
                player.RestarVida(1000);
            }
        }
    }
}
