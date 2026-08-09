using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    private void Start()
    {
        MusicManager.Instance.PlaySound(MusicManager.Instance.BackGroundAudio);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        MusicManager.Instance.StopSound(MusicManager.Instance.BackGroundAudio);
    }

    public void OpenGuilde()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
