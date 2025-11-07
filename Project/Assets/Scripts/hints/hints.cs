using TMPro;
using UnityEngine;
using Unity.Collections;
using Unity.VisualScripting;

public class hints : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI text;

    private string lang = "Ro";

    public void givehint1()
    {
        if (lang == "Ro")
        {
            text.text = "Scopul jocului ii de a aduna gunoaiele din rau (controale a si d sau sageata stanga si dreapta)";
      
        }
       
        
    }
    public void givehint2()
    {
        if (lang == "Ro")
        {
            text.text = "Scopul jocului ii de a alege 2 carti de acelasi tip de gunoi, chiar daca imaginea este diferita";

        }
        else
        {

        }
    }
    public void givehint3()
    {
        if(lang == "Ro")
        {
            text.text = "Scopul jocului ii sa arunci gunoaiele in gunoiul in care tipul de obiect trebuie aruncat.";
        }
        else
        {
            text.text = "the purpose of the game is to throw the trash in their respective place!";
        }

    }
    public void switchLang()
    {
        if (lang == "Ro")
        {
            lang = "En";
        }
        else
        {
            lang = "Ro";
        }
    }


    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
