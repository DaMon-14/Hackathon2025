using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit_Button : MonoBehaviour
{
    Card_Manager Card_Manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnButtonClick()
    {
        SceneTransition.Instance.FadeToScene("CharacterCustomisation");
    }
    private void Start()
    {
        Card_Manager = GameObject.Find("Card_Manager").GetComponent<Card_Manager>();
    }

    void Update()
    {
        if ((Card_Manager.score >= 10 && GameObject.Find("Card_Manager").GetComponent<Card_Manager>().allCardsCleared) || Card_Manager.attempts <= 0)
        {
            SceneTransition.Instance.FadeToScene("CharacterCustomisation");
        }
    }
}
