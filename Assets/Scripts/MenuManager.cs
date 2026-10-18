using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneLoader.Instance.ChangeScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Start()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayMenuMusic();
        }
    }
}
