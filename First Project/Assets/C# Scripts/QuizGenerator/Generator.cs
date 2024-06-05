using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Generator : MonoBehaviour
{
    public static int answer;
    public static string generatedProblem;

    public static void GenerateNums()
    {
        int selectArithmetic = Random.Range(0, 4);
        int firstNum = Random.Range(1, 10);
        int secondNum = Random.Range(1, 10);

        switch (selectArithmetic)
        {
            case 0: // +
                answer = firstNum + secondNum;
                generatedProblem = $"{firstNum} + {secondNum}";
                break;

            case 1: // -
                answer = firstNum - secondNum;
                generatedProblem = $"{firstNum} - {secondNum}";
                break;

            case 2: // *
                answer = firstNum * secondNum;
                generatedProblem = $"{firstNum} x {secondNum}";
                break;

            case 3: // /
                int product = firstNum * secondNum;
                answer = firstNum;
                generatedProblem = $"{product} ÷ {secondNum}";
                break;
        }
    }
}