using System.Collections.Generic;
using UnityEngine;
using System;

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager Instance { get; private set; }

    public string CurrentLanguage { get; private set; } = "En";
    private Dictionary<string, Dictionary<string, string>> translations = new Dictionary<string, Dictionary<string, string>>();

    public static event Action OnLanguageChanged;

    private const string PLAYERPREFS_KEY = "language";

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadTranslationsFromJSON();

        // load saved language
        if (PlayerPrefs.HasKey(PLAYERPREFS_KEY))
        {
            string saved = PlayerPrefs.GetString(PLAYERPREFS_KEY);
            if (translations.ContainsKey(saved))
                CurrentLanguage = saved;
        }
    }

    private void LoadTranslationsFromJSON()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Languages");
        if (jsonFile == null)
        {
            Debug.LogError("Languages.json not found in Resources folder!");
            return;
        }

        try
        {
            LanguageFile file = JsonUtility.FromJson<LanguageFile>(jsonFile.text);
            translations = file.ToDictionary();
            Debug.Log($"Loaded {translations.Count} languages.");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to parse Languages.json: " + e.Message);
        }
    }

    public void SetLanguage(string code)
    {
        if (!translations.ContainsKey(code))
        {
            Debug.LogWarning($"Language '{code}' not found. No changes made.");
            return;
        }

        CurrentLanguage = code;
        PlayerPrefs.SetString(PLAYERPREFS_KEY, code);
        PlayerPrefs.Save();
        OnLanguageChanged?.Invoke();
    }

    public string GetText(string key)
    {
        if (translations.ContainsKey(CurrentLanguage) && translations[CurrentLanguage].ContainsKey(key))
            return translations[CurrentLanguage][key];

        // fallback to English if available
        if (translations.ContainsKey("En") && translations["En"].ContainsKey(key))
            return translations["En"][key];

        // fallback to key so it's obvious there's a missing translation
        return $"[{key}]";
    }

    // optional helper to get available language codes (for UI)
    public string[] GetAvailableLanguages()
    {
        var keys = new List<string>(translations.Keys);
        return keys.ToArray();
    }

    // optional helper to get the human label for a language (e.g. "English")
    public string GetLocalizedLabel(string languageCode, string labelKey = "tbsecond")
    {
        if (translations.ContainsKey(languageCode) && translations[languageCode].ContainsKey(labelKey))
            return translations[languageCode][labelKey];
        return languageCode;
    }
}
