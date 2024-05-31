using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSetting : MonoBehaviour
{
    public GameObject LanguagePanel;
    public Button OpenButton;
    public Button CloseButton;

    void Start()
    {

        OpenButton.onClick.AddListener(OpenPanel);
        CloseButton.onClick.AddListener(ClosePanel);
        LanguagePanel.SetActive(false);
    }

    void OpenPanel()
    {
        LanguagePanel.SetActive(true);
    }

    void ClosePanel()
    {
        LanguagePanel.SetActive(false);
    }
}
