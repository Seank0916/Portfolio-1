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
    public int maxProblems = 15; // Total number of problems
    private int problemCount = 0;
    private int correctAnswers = 0; // To track the number of correct answers

    private void Start()
    {
        timer = timeLimit;
        timerSlider.maxValue = timeLimit;
        timerSlider.value = timer;
        StartCoroutine(TimerRoutine());
    }

    public void IncrementCorrectAnswers()
    {
        correctAnswers++;
    }

    public void ResetTimer()
    {
        timer = timeLimit;
        timerSlider.value = timer;
        problemCount++;

        if (problemCount >= maxProblems)
        {
            int stars = CalculateStars(correctAnswers);
            PlayerPrefs.SetInt("Stars", stars); // Save the number of stars
            SceneManager.LoadScene("Result");
        }
    }

    private int CalculateStars(int correctAnswers)
    {
        if (correctAnswers == 15)
            return 3;
        else if (correctAnswers == 14)
            return 2;
        else if (correctAnswers == 13)
            return 1;
        else
            return 0;
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
