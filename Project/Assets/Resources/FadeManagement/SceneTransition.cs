using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition Instance;

    [Header("Fade Settings")]
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 1f;
    private bool isFading = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (fadeCanvasGroup != null)
            fadeCanvasGroup.alpha = 1f; // Start black
    }

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "mainGame")
        {
            fadeCanvasGroup.alpha = 0f; // Start black
            StartCoroutine(Fade(0f));
        }
        else
        {
            if (fadeCanvasGroup != null)
                StartCoroutine(Fade(0f)); // Fade in when the game starts
        }
        
    }

    public void FadeToScene(string sceneName)
    {
        if (!isFading)
            StartCoroutine(FadeAndSwitchScenes(sceneName));
    }

    private IEnumerator FadeAndSwitchScenes(string sceneName)
    {
        isFading = true;
        yield return StartCoroutine(Fade(1f)); // Fade to black

        SceneManager.LoadScene(sceneName); // WebGL-safe load

        yield return null; // Let new scene initialize
        yield return StartCoroutine(Fade(0f)); // Fade from black

        isFading = false;
    }

    private IEnumerator Fade(float targetAlpha)
    {
        fadeCanvasGroup.blocksRaycasts = true;
        float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / fadeDuration;

        while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null;
        }

        fadeCanvasGroup.blocksRaycasts = false;
    }
}
