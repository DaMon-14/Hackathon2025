using UnityEngine;
using TMPro;
using System.Collections.Generic;

[RequireComponent(typeof(TMP_Dropdown))]
public class LanguageSelector : MonoBehaviour
{
    private TMP_Dropdown dropdown;

    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        PopulateDropdown();
        // set initial value based on LanguageManager
        var codes = LanguageManager.Instance.GetAvailableLanguages();
        int idx = System.Array.IndexOf(codes, LanguageManager.Instance.CurrentLanguage);
        if (idx >= 0) dropdown.value = idx;
        dropdown.onValueChanged.AddListener(OnDropdownChanged);
    }

    void PopulateDropdown()
    {
        var codes = LanguageManager.Instance.GetAvailableLanguages();
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        foreach (var code in codes)
        {
            // Use a label defined in the language file (tbsecond) if exists, otherwise show code
            string label = LanguageManager.Instance.GetLocalizedLabel(code, "tbsecond");
            options.Add(new TMP_Dropdown.OptionData(label + " (" + code + ")"));
        }
        dropdown.options = options;
        dropdown.RefreshShownValue();
    }

    void OnDropdownChanged(int index)
    {
        var codes = LanguageManager.Instance.GetAvailableLanguages();
        if (index >= 0 && index < codes.Length)
        {
            LanguageManager.Instance.SetLanguage(codes[index]);
        }
    }
}
