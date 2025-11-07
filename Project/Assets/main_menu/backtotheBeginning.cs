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
        SceneTransition.Instance.FadeToScene("mainGame");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
