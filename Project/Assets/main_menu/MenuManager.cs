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

    public void TestDaMon()
    {
       StartCoroutine(Gettest());
    }

    private IEnumerator Gettest()
    {
        string url = "https://localhost:7172/Admin/allClient_Course";
        UnityWebRequest request = UnityWebRequest.Get(url);
        request.SetRequestHeader("UID", "a13fab95-ce9c-4325-896f-5cbc4691aa28");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Response: " + request.downloadHandler.text);
        }
        else
        {
            Debug.Log("Error: " + request.error);
        }
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
