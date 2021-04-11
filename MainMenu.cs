using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame ()
    {
        SceneManager.LoadSceneAsync("Main");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
