using Unity.VisualScripting;
using UnityEngine;

public class GamaManager : MonoBehaviour
{
    public static GamaManager Instance; //para poder acceder al game manager desde otro script, es una variable estatica

    [SerializeField] private int coins;
    [SerializeField] private int star;

    private bool _isPaused = false;
    private bool _winMenu = false;
    private bool _gui = true;

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

    void Start()
    {
        AudioManager.Instance.StartSoundTranck();
    }

    void Update()
    {
        if(_winMenu == false)
        {
            if (star == 10)
            {
                Win();
            }
        }

    }


    public void AddCoin() //creamos una funcion para modificar la variable del contador de modendas
    {
        coins += 1;
        CanvasManager.Instance.AddCoinText(coins);
    }

    public void AddStar()
    {
        star += 1;
        CanvasManager.Instance.AddSarText(star);

    }

    public void Pause()
    {
        if(_isPaused)
        {
            _isPaused = false;
            AudioManager.Instance.StartSoundTranck();
            Time.timeScale = 1;
            
        }
        else
        {
            _isPaused = true;
            AudioManager.Instance.PauseSoundtrack();
            Time.timeScale = 0;
        }

        CanvasManager.Instance.ChangeCanvasStatus(CanvasManager.Instance.pauseCanvas, CanvasManager.Instance.resumeButton);

    }

    public bool IsPaused()
    {
        return _isPaused;
    }

    public void Win()
    {
        if (_winMenu == false)
        {
            Time.timeScale = 0;
            _winMenu = true;
            _gui = false;

        }
        else
        {
            Time.timeScale = 1;
            _winMenu = false;
            _gui = true;

        }
        if(_gui == false)
        {
            CanvasManager.Instance.gui.SetActive(false);
        }
        //winCanvas.SetActive(_winMenu);
        CanvasManager.Instance.ChangeCanvasStatus(CanvasManager.Instance.winCanvas, CanvasManager.Instance.playButton);
    }
}
