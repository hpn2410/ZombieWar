using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    private void Update()
    {
        if (GameManager.Instance == null)
            return;

        float time = GameManager.Instance.RemainingTime;

        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}