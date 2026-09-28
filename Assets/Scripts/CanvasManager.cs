using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseCanvas;
    
    public static CanvasManager Instance;

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

    public void ChangeCanvasStatus()
    {
        if(_pauseCanvas.activeInHierarchy)
        {
            _pauseCanvas.SetActive(false);
        }
        else
        {
            _pauseCanvas.SetActive(true);
        }
        
    }
}
