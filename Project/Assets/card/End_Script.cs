using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit_Button : MonoBehaviour
{
    Card_Manager Card_Manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnButtonClick()
    {
        SceneManager.LoadScene("mainGame");
    }
    private void Start()
    {
        Card_Manager = GameObject.Find("Card_Manager").GetComponent<Card_Manager>();
    }

    void Update()
    {
        if(Card_Manager.score >=10 || Card_Manager.attempts <= 0)
        {
            SceneManager.LoadScene("mainGame");
        }
    }
}
