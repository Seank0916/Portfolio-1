using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenSetting : MonoBehaviour
{
    public GameObject UIPanel;
    public Button OpenButton;
    public Button CloseButton;

    void Start()
    {

        OpenButton.onClick.AddListener(OpenPanel);
        CloseButton.onClick.AddListener(ClosePanel);
        UIPanel.SetActive(false);
    }

    void OpenPanel()
    {
        UIPanel.SetActive(true);
    }

    void ClosePanel()
    {
        UIPanel.SetActive(false);
    }
}
