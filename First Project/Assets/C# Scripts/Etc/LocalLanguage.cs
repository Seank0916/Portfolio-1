using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Localization.Settings;

public class LocalLanguage : MonoBehaviour
{
    private bool active = false;
    public void ChangeLocale(int localID)
    {
        if (active == true) return;
        StartCoroutine(SetLocal(localID));
    }
    IEnumerator SetLocal(int _localID)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localID];
        active = false;
    }
}