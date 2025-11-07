using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LanguageFile
{
    public LanguageEntry[] languages;

    // Convert to Dictionary<string, Dictionary<string,string>>
    public Dictionary<string, Dictionary<string, string>> ToDictionary()
    {
        var result = new Dictionary<string, Dictionary<string, string>>();
        if (languages == null) return result;

        foreach (var lang in languages)
        {
            if (lang == null || string.IsNullOrEmpty(lang.code)) continue;

            var map = new Dictionary<string, string>();
            if (lang.entries != null)
            {
                foreach (var kv in lang.entries)
                {
                    if (kv == null || string.IsNullOrEmpty(kv.key)) continue;
                    map[kv.key] = kv.value ?? "";
                }
            }
            result[lang.code] = map;
        }
        return result;
    }
}

[Serializable]
public class LanguageEntry
{
    public string code;
    public EntryKV[] entries;
}

[Serializable]
public class EntryKV
{
    public string key;
    public string value;
}
