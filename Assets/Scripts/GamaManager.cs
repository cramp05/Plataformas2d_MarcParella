using UnityEngine;

public class GamaManager : MonoBehaviour
{
    public static GamaManager Instance; //para poder acceder al game manager desde otro script, es una variable estatica

    [SerializeField] private int coins;

    private bool _isPaused = false;

    void Awake()
    {
        if(Instance != null && Instance != this) //si hay varios game manager uno se destruye para solo quede uno
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void start()
    {
        AudioManager.Instance.StartSoundTranck();
    }


    public void AddCoin() //creamos una funcion para modificar la variable del contador de modendas
    {
        coins += 1;

    }

    public void Pause()
    {
        if(_isPaused)
        {
            _isPaused = false;
            AudioManager.Instance.PauseSoundtrack();
            Time.timeScale = 1;
            
        }
        else
        {
            _isPaused = true;
            AudioManager.Instance.PauseSoundtrack();
            Time.timeScale = 0;
        }

    }

    public bool IsPaused()
    {
        return _isPaused;
    }
}
