using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AnswerOptions : MonoBehaviour
{
    private int correctAnswerIndex;
    public Button[] answerButtons;
    public TextMeshProUGUI problemText;
    public TextMeshProUGUI resultText; 
    public TimerController timerController; 

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
            //if (answerButtons[i] == null)
            //{
            //    Debug.LogError($"answerButtons[{i}] is not assigned in the Inspector!");
            //    continue;
            //}

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
            button.onClick.AddListener(() => OnAnswerSelected(index));
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

    public void OnAnswerSelected(int index)
    {
        if (index == correctAnswerIndex)
        {
            resultText.text = "Correct";
            //Debug.Log("Correct!");
        }
        else
        {
            resultText.text = "Wrong";
           //Debug.Log("Wrong!");
        }

        timerController.ResetTimer(); 
        GenerateAndDisplayProblem(); 
    }
}
