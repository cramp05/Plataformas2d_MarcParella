using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject pauseCanvas;
    public Button resumeButton;

    public GameObject gameOverCanvas;
    public Button retryButton;

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


}
