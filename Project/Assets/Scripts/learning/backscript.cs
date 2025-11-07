using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI tbfirst;
    public TextMeshProUGUI tbsecond;
    public TextMeshProUGUI back;

    private string lang = "Ro";

    // Dicționar: Limba -> alt dicționar (cheie -> text)
    private Dictionary<string, Dictionary<string, string>> translations;

    private void Start()
    {
        // Inițializăm textele o singură dată
        translations = new Dictionary<string, Dictionary<string, string>>()
        {
            {
                "En", new Dictionary<string, string>()
                {
                    { "mainText", "Selective waste collection is essential for protecting the environment. By properly separating plastic, paper, glass, and household waste, we help reduce pollution and save natural resources. Every small action matters — recycling helps decrease the amount of waste sent to landfills and transforms old materials into new products. It is everyone’s responsibility to keep the planet clean for future generations." },
                    { "tbfirst", "Romanian" },
                    { "tbsecond", "English" },
                    { "back", "Back?" }
                }
            },
            {
                "Ro", new Dictionary<string, string>()
                {
                    { "mainText", "Colectarea selectivă a deșeurilor este esențială pentru protejarea mediului înconjurător. Prin separarea corectă a plasticului, hârtiei, sticlei și deșeurilor menajere, contribuim la reducerea poluării și la economisirea resurselor naturale. Fiecare gest contează — reciclarea ajută la scăderea cantității de deșeuri depozitate și la transformarea materialelor vechi în produse noi. Este responsabilitatea fiecăruia dintre noi să păstrăm planeta curată pentru generațiile viitoare." },
                    { "tbfirst", "Română" },
                    { "tbsecond", "Engleză" },
                    { "back", "Înapoi?" }
                }
            },
            {
    "Fr", new Dictionary<string, string>()
    {
        { "mainText", "La collecte sélective des déchets est essentielle pour protéger l'environnement..." },
        { "tbfirst", "Roumain" },
        { "tbsecond", "Anglais" },
        { "back", "Retour?" }
    }
}
        };

        ActivateText();
    }

    public void ActivateText()
    {
        if (!translations.ContainsKey(lang))
        {
            Debug.LogWarning($"Language '{lang}' not found, falling back to English.");
            lang = "En";
        }

        text.text = translations[lang]["mainText"];
        tbfirst.text = translations[lang]["tbfirst"];
        tbsecond.text = translations[lang]["tbsecond"];
        back.text = translations[lang]["back"];
    }

    public void RoButtonPress()
    {
        lang = "Ro";
        ActivateText();
    }

    public void EnButtonPress()
    {
        lang = "En";
        ActivateText();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("CharacterCustomisation");
    }
}
