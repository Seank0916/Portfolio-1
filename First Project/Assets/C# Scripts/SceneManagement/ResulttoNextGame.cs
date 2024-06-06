using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResulttoNextGame : MonoBehaviour
{
    public Button NextGameButton;

    void Start()
    {
        NextGameButton.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        SceneManager.LoadScene("Stage");
    }
}