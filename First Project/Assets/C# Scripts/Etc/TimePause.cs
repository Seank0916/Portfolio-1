using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class TimePause : MonoBehaviour
{
    public Button pauseButton;
    public Button resumeButton;
    public GameObject countdownImage; // Reference to the countdown panel with both image and text
    public TextMeshProUGUI countdownText; // Reference to the countdown text

    void Start()
    {
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);
        StartCoroutine(StartWithDelay());
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    IEnumerator StartWithDelay()
    {
        Time.timeScale = 0; // Pause the game initially
        countdownImage.SetActive(true);

        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSecondsRealtime(1); // Wait for 1 second in real time
        }

        countdownImage.SetActive(false);
        Time.timeScale = 1; // Resume the game after the delay
    }
}
