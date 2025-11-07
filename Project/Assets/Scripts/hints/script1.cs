using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class script1 : MonoBehaviour,IPointerClickHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string sceneToLoad;
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
