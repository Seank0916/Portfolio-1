using System.Collections;
using UnityEngine;
using TMPro;

public class ResultDisplay : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public float displayDuration = 1.5f; // Duration to display the result text

    private void Start()
    {
        resultText.gameObject.SetActive(false); // Initially hide the result text
    }

    public void DisplayResult(string message)
    {
        resultText.text = message;
        resultText.gameObject.SetActive(true);
        StartCoroutine(HideResultTextAfterDelay());
    }

    private IEnumerator HideResultTextAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration); // Display for the specified duration
        resultText.gameObject.SetActive(false);
    }
}
