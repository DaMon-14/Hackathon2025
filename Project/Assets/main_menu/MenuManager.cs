using System.Collections;
using System.Net;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    public void PlayGame()
    {
        SceneTransition.Instance.FadeToScene("CharacterCustomisation");
    }
    public void Loadlearnscene()
    {
        SceneTransition.Instance.FadeToScene("learnScene");
    }
    public void Playgame1()
    {
        SceneTransition.Instance.FadeToScene("Game_rau");

    }
    public void Playgame2()
    {
        SceneTransition.Instance.FadeToScene("Memory_Game");
    }
    public void Playgame3()
    {
        SceneTransition.Instance.FadeToScene("Fruit_Ninja_Sort");
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
