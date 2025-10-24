using UnityEngine;
using UnityEngine.SceneManagement;

public class backtotheBeginning : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void backtothebeginning()
    {
        SceneManager.LoadScene("mainGame");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
