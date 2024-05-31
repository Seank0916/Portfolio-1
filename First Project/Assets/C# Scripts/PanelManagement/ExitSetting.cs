using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitSetting : MonoBehaviour
{
    public GameObject ExitPanel;
    public Button OpenButton;
    public Button CloseButton;

    void Start()
    {

        OpenButton.onClick.AddListener(OpenPanel);
        CloseButton.onClick.AddListener(ClosePanel);
        ExitPanel.SetActive(false);
    }

    void OpenPanel()
    {
        ExitPanel.SetActive(true);
    }

    void ClosePanel()
    {
        ExitPanel.SetActive(false);
    }
}
