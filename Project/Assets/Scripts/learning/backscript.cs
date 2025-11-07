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

    public void BackToMenu()
    {
        SceneTransition.Instance.FadeToScene("CharacterCustomisation");
    }
}
