using UnityEngine;

public class FadeManagerBootstrap : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject fadeManagerPrefab;

    void Awake()
    {
        if (SceneTransition.Instance == null)
            Instantiate(fadeManagerPrefab);
    }
}
