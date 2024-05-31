using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameSetting : MonoBehaviour
{
    public GameObject IngamePanel;
    public Button OpenButton;
    public Button CloseButton;

    void Start()
    {

        OpenButton.onClick.AddListener(OpenPanel);
        CloseButton.onClick.AddListener(ClosePanel);
        IngamePanel.SetActive(false);
    }

    void OpenPanel()
    {
        IngamePanel.SetActive(true);
    }

    void ClosePanel()
    {
        IngamePanel.SetActive(false);
    }
}
