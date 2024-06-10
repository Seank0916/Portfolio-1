using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProblemController : MonoBehaviour
{
    private int correctAnswerIndex;
    public Button[] answerButtons;
    public TextMeshProUGUI problemText;
    public TextMeshProUGUI resultText; // 결과
    public TimerController timerController; // TimerController 연결 
    public int maxProblems = 15; // 총 문제 
    private int problemCount = 0;
    private int correctAnswers = 0; // 정답 확인 로직
    public float resultDisplayDuration = 1.5f; // 결과 시간

    public int ProblemCount => problemCount; // Public getter for problemCount

    private void Start()
    {
        resultText.gameObject.SetActive(false); // 문제 풀기 전까지 결과 숨김
        GenerateAndDisplayProblem();
    }

    public void GenerateAndDisplayProblem()
    {
        Generator.GenerateNums();
        problemText.text = Generator.generatedProblem;
        GenerateAnswerOptions();
    }

    public void GenerateAnswerOptions()
    {
        correctAnswerIndex = Random.Range(0, answerButtons.Length);
        List<int> availableIndices = new List<int>();
        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i != correctAnswerIndex)
            {
                availableIndices.Add(i);
            }
        }

        int[] usedAnswers = new int[answerButtons.Length];
        usedAnswers[correctAnswerIndex] = Generator.answer;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (answerButtons[i] == null)
            {
                Debug.LogError($"answerButtons[{i}] is not assigned in the Inspector!");
                continue;
            }

            if (i != correctAnswerIndex)
            {
                int randomWrongAnswer;
                do
                {
                    randomWrongAnswer = GenerateUniqueWrongAnswer(usedAnswers);
                } while (System.Array.IndexOf(usedAnswers, randomWrongAnswer) != -1);

                usedAnswers[i] = randomWrongAnswer;
            }
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = usedAnswers[i].ToString();

            Button button = answerButtons[i].GetComponent<Button>();
            button.onClick.RemoveAllListeners(); // listeners 중복 삭제
            int index = i;
            button.onClick.AddListener(() => OnAnswerSelected(index, correctAnswerIndex));
        }
    }

    private int GenerateUniqueWrongAnswer(int[] usedAnswers)
    {
        int newWrongAnswer;
        do
        {
            newWrongAnswer = Generator.answer + Random.Range(-10, 11);
        } while (System.Array.IndexOf(usedAnswers, newWrongAnswer) != -1 || newWrongAnswer == Generator.answer);

        return newWrongAnswer;
    }

    public void OnAnswerSelected(int index, int correctAnswerIndex)
    {
        if (index == correctAnswerIndex)
        {
            DisplayResult("Correct!");
            Debug.Log("Correct!");
            correctAnswers++;
        }
        else
        {
            DisplayResult("Wrong!");
            Debug.Log("Wrong!");
        }

        problemCount++;
        timerController.ResetTimer(); // Reset the timer

        if (problemCount >= maxProblems)
        {
            int stars = CalculateStars(correctAnswers);
            PlayerPrefs.SetInt("Stars", stars); // 결과 씬 별 저장 
            SceneManager.LoadScene("Result");
        }
        else
        {
            GenerateAndDisplayProblem(); // 다음 문제 생성
            StartCoroutine(HideResultAfterDelay());
        }
    }

    public void TimeOver()
    {
        DisplayResult("Time Over!");
        Debug.Log("Time Over!");
        problemCount++;
        GenerateAndDisplayProblem(); // 다음 문제 생성
        StartCoroutine(HideResultAfterDelay());
    }

    private void DisplayResult(string message)
    {
        resultText.text = message;
        resultText.gameObject.SetActive(true);
    }

    private IEnumerator HideResultAfterDelay()
    {
        yield return new WaitForSeconds(resultDisplayDuration); // Display for the specified duration
        resultText.gameObject.SetActive(false);
    }

    private int CalculateStars(int correctAnswers) // 정답 수 따라 별 수정
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
}
