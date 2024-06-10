using UnityEngine;
using UnityEngine.UI;

public class TimePause : MonoBehaviour // 패널 오픈시 시간 정지 스크립트
{
    public Button pauseButton;
    public Button resumeButton;

    void Start()
    {
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
