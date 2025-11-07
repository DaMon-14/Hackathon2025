using UnityEngine;
using UnityEngine.SceneManagement;

public class backscript : MonoBehaviour
{
    public GameObject text;
   public void backtomenu()
    {
        SceneTransition.Instance.FadeToScene("CharacterCustomisation");
    }


    public void Start()
    {
        text = new GameObject();
        //text.SetActive(false);
    }
}
