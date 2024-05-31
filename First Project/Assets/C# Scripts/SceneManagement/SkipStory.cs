using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkipStory : MonoBehaviour
{
    public Button SkipButton;

    void Start()
    {
        SkipButton.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        SceneManager.LoadScene("Start");
    }
}
