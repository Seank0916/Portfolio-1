using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProblemController : MonoBehaviour
{
    public Button[] answerButtons;
    public TextMeshProUGUI problemText;
    public TextMeshProUGUI resultText; // Field for displaying the result
    public TimerController timerController; // Reference to the TimerController
    public int maxProblems = 15; // Total number of problems
    private int problemCount = 0;
    private int correctAnswers = 0; // To track the number of correct answers

    public int ProblemCount => problemCount; // Public getter for problemCount

    private void Start()
    {
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
        int correctAnswerIndex = Random.Range(0, answerButtons.Length);
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
            button.onClick.RemoveAllListeners(); // Ensure no duplicate listeners
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
            resultText.text = "Correct!";
            Debug.Log("Correct!");
            correctAnswers++;
        }
        else
        {
            resultText.text = "Wrong!";
            Debug.Log("Wrong!");
        }

        problemCount++;
        timerController.ResetTimer(); // Reset the timer

        if (problemCount >= maxProblems)
        {
            int stars = CalculateStars(correctAnswers);
            PlayerPrefs.SetInt("Stars", stars); // Save the number of stars
            SceneManager.LoadScene("Result");
        }
        else
        {
            GenerateAndDisplayProblem(); // Generate the next problem
        }
    }

    public void TimeOver()
    {
        resultText.text = "Time Over!";
        Debug.Log("Time Over!");
        problemCount++;
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
}
