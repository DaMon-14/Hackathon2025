using UnityEngine;
using UnityEngine.SceneManagement;

public class backscript : MonoBehaviour
{
    public GameObject text = new GameObject();
   public void backtomenu()
    {
        SceneManager.LoadScene("CharacterCustomisation");
    }


    public void Start()
    {
        text.SetActive(false);
    }
}
