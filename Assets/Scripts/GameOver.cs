using UnityEngine;

public class GameOver : MonoBehaviour
{
    void Start()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayGameOverMusic();
        }
    }
}
