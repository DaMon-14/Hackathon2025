using TMPro;
using UnityEngine;
using Unity.Collections;
using Unity.VisualScripting;

public class hints : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //public TMPro.TMP_Text text;
    public TextMeshProUGUI text;

    void Start()
    {
    }

    public void givehint1()
    {
        text.GetComponent<learn_script>().SetKey("hint1Btn");
    }
    public void givehint2()
    {
        text.GetComponent<learn_script>().SetKey("hint2Btn");
    }
    public void givehint3()
    {
        text.GetComponent<learn_script>().SetKey("hint3Btn");
    }

}
