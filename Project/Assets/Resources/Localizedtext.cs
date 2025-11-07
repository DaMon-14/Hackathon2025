using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LocalizedText : MonoBehaviour
{
    [Tooltip("Translation key, e.g. 'mainText' or 'back'")]
    public string key;

    private TextMeshProUGUI _tmp;

    void Awake()
    {
        _tmp = GetComponent<TextMeshProUGUI>();
        UpdateText();
        LanguageManager.OnLanguageChanged += UpdateText;
    }

    void OnDestroy()
    {
        LanguageManager.OnLanguageChanged -= UpdateText;
    }

    public void UpdateText()
    {
        if (LanguageManager.Instance != null)
            _tmp.text = LanguageManager.Instance.GetText(key);
    }
}
