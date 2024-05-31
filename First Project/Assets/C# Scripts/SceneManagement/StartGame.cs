using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Button StartButton;

    void Start()
    {
        StartButton.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        SceneManager.LoadScene("Stage");
    }
}
