using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Script : MonoBehaviour
{
    Item_Manager Item_Manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Item_Manager = GameObject.Find("Item_Manager").GetComponent<Item_Manager>();
    }

    public void OnButtonClick()
    {
        SceneTransition.Instance.FadeToScene("mainGame");
        //SceneManager.LoadScene("mainGame");
    }

    // Update is called once per frame
    void Update()
    {
        if(Item_Manager.mistakes_left <= 0)
        {
            SceneManager.LoadScene("mainGame");
        }
    }
}
