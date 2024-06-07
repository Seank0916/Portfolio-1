using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public float timeLimit = 5f; // 5 seconds
    private float timer;
    public Slider timerSlider;
    public TextMeshProUGUI timerText;
    public AnswerOptions answerOptions;
    public int maxProblems = 30; // Total number of problems
    private int problemCount = 0;

    private void Start()
    {
        timer = timeLimit;
        timerSlider.maxValue = timeLimit;
        timerSlider.value = timer;
        StartCoroutine(TimerRoutine());
    }

    public void ResetTimer()
    {
        timer = timeLimit;
        timerSlider.value = timer;
        problemCount++;

        if (problemCount >= maxProblems)
        {
            SceneManager.LoadScene("Result");
        }
    }

    private IEnumerator TimerRoutine()
    {
        while (problemCount < maxProblems)
        {
            timer -= Time.deltaTime;
            timerSlider.value = timer;
            timerText.text = Mathf.Ceil(timer).ToString(); // Update the timer text

            if (timer <= 0)
            {
                ResetTimer();
                answerOptions.GenerateAndDisplayProblem();
            }

            yield return null;
        }

        // Load the Result scene after completing all problems
        SceneManager.LoadScene("Result");
    }
}
