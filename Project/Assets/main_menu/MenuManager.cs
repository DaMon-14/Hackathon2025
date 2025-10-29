using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    public void PlayGame()
    {
        SceneManager.LoadScene("CharacterCustomisation");
    }
    public void Playgame1()
    {
        SceneManager.LoadScene("SampleScene");

    }
    public void Playgame2()
    {
        SceneManager.LoadScene("Memory_Game");
    }
    public void Playgame3()
    {
        SceneManager.LoadScene("Fruit_Ninja_Sort");
    }


    public void QuitGame()
    {
        Debug.Log("game quitted!!");
        Application.Quit();
    }


    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.isPressed)
        {
            QuitGame();
        }
    }
}
