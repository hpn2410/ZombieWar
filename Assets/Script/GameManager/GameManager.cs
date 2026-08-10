using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float RemainingTime { get; private set; }

    [SerializeField] private float levelDuration = 180f;

    private bool isRunning;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        StartLevel();
        MusicManager.Instance.PlaySound(MusicManager.Instance.LevelBgAudio);
    }

    private void Update()
    {
        if (!isRunning)
            return;

        RemainingTime -= Time.deltaTime;

        if (RemainingTime <= 0f)
        {
            RemainingTime = 0f;
            EndLevel();
        }
    }

    private void StartLevel()
    {
        RemainingTime = levelDuration;
        isRunning = true;
    }

    private void EndLevel()
    {
        isRunning = false;

        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene == 1)
        {
            SceneManager.LoadScene(2);

            // reset timer
            RemainingTime = levelDuration;
            isRunning = true;
        }
        else if (currentScene == 2)
        {
            Debug.Log("Victory!");
            //UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
}