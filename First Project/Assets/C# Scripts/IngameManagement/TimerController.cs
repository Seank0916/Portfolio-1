using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public float timeLimit = 5f; // 문제 풀이 시간
    private float timer;
    public Slider timerSlider;
    public TextMeshProUGUI timerText;
    public ProblemController problemController;

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
    }

    private IEnumerator TimerRoutine()
    {
        while (problemController.ProblemCount < problemController.maxProblems)
        {
            timer -= Time.deltaTime;
            timerSlider.value = timer;
            timerText.text = Mathf.Ceil(timer).ToString(); // Update the timer text*

            if (timer <= 0)
            {
                problemController.TimeOver(); // 타임 오버
                ResetTimer();
            }

            yield return null;
        }

        // 씬 전환
        SceneManager.LoadScene("Result");
    }
}
