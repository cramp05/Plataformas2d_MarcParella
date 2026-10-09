using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    [SerializeField] private GameObject _loadingCanvas;
    [SerializeField] private Image _loadingBar;

    void Awake()
    {
        if(Instance != null && Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }


    /*public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }*/

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(LoadNewScene(sceneName));
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();

        #else
        Application.Quit();
        #endif
    }

    IEnumerator LoadNewScene(string sceneName)
    {
        yield return null;
        _loadingCanvas.SetActive(true);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;

        float fakeLoadPorcentaje = 0;

        while(!asyncLoad.isDone)
        {
           // _loadingBar.fillAmount = asyncLoad.progress;
            fakeLoadPorcentaje += 0.01f;
            Mathf.Clamp01(fakeLoadPorcentaje);

            _loadingBar.fillAmount = fakeLoadPorcentaje;

            if(asyncLoad.progress >= 0.9f && fakeLoadPorcentaje >= 0.99f)
            {
                asyncLoad.allowSceneActivation = true;
            }

            yield return new WaitForSecondsRealtime(0.1f);

        }

        Time.timeScale = 1;
        _loadingCanvas.SetActive(false);
    }

}
