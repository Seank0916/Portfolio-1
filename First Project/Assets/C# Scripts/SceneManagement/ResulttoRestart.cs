using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResulttoRestart : MonoBehaviour
{
    public Button RestartButton;

    void Start()
    {
        RestartButton.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        SceneManager.LoadScene("Ingame");
    }
}