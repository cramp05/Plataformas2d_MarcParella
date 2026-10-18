using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore.Text;

public class CanvasManager : MonoBehaviour
{
    public GameObject pauseCanvas;
    public Button resumeButton;

    public GameObject winCanvas;
    public Button playButton;

    public Button retryButton;

    public GameObject gui;
    public Text contadorEstrellas;
    public Text contadorMonedas;

    [SerializeField] private Image _vidaBar;

    
    public static CanvasManager Instance;

    [SerializeField] private float _vidaPorcentaje = 1;




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

    public void UpdateHealthBar(int actualHealth, int maxHealth)
    {
        if (_vidaBar != null)
        {
            float porcentaje = (float)actualHealth / maxHealth;
            _vidaBar.fillAmount = Mathf.Clamp01(porcentaje);
        }
    }

    public void ChangeCanvasStatus(GameObject canvas, Button selectedButton)
    {
        if(canvas.activeInHierarchy)
        {
            canvas.SetActive(false);
        }
        else
        {
            canvas.SetActive(true);
            selectedButton.Select();
        }
        
    }

    public void ChangeScene(string sceneName)
    {
        SceneLoader.Instance.ChangeScene(sceneName);
    }



    void QuitarVidaBarra()
    {
        _vidaPorcentaje -= 0.2f;
        Mathf.Clamp01(_vidaPorcentaje);

        _vidaBar.fillAmount = _vidaPorcentaje;
    }

    public void AddSarText(int numberStars)
    {
        contadorEstrellas.text = numberStars.ToString();
    }

    public void AddCoinText(int numberCoins)
    {
        contadorMonedas.text = numberCoins.ToString();
    }
}
