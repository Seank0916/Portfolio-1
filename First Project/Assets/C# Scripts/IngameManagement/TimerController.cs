using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    public float timeLimit = 5f; // 5 seconds
    private float timer;
    public Slider timerSlider;
    public Image timerImage;
    public AnswerOptions answerOptions;

    private void Start()
    {
        timer = timeLimit;
        timerSlider.maxValue = timeLimit;
        timerSlider.value = timer;
        StartCoroutine(TimerRoutine());
    }

    private IEnumerator TimerRoutine()
    {
        while (true)
        {
            timer -= Time.deltaTime;
            timerSlider.value = timer;

            if (timer <= 0)
            {
                timer = timeLimit;
                answerOptions.GenerateAndDisplayProblem();
            }

            yield return null;
        }
    }
}
