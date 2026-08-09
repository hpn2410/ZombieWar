using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenGuilde()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
