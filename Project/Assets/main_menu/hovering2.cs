using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonPreview2 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("References")]
    public RawImage videoPreview;
    public Image backgroundImage;
    public VideoPlayer videoPlayer;

    [Header("Settings")]
    public string sceneToLoad;
    public float fadeDuration = 0.4f;

    private Coroutine fadeRoutine;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (fadeRoutine != null) StopCoroutine(fadeRoutine);
        fadeRoutine = StartCoroutine(FadeInVideo());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (fadeRoutine != null) StopCoroutine(fadeRoutine);
        fadeRoutine = StartCoroutine(FadeOutVideo());
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    private IEnumerator FadeInVideo()
    {
        if (videoPlayer == null || videoPreview == null) yield break;

        // Restart video from beginning every time
        videoPlayer.Stop();
        videoPlayer.Play();

        float elapsed = 0f;
        Color c = videoPreview.color;

        while (elapsed < fadeDuration)
        {
            c.a = Mathf.Lerp(0f, 1f, elapsed / fadeDuration);
            videoPreview.color = c;
            elapsed += Time.deltaTime;
            yield return null;
        }

        c.a = 1f;
        videoPreview.color = c;
    }

    private IEnumerator FadeOutVideo()
    {
        if (videoPlayer == null || videoPreview == null) yield break;

        float elapsed = 0f;
        Color c = videoPreview.color;

        while (elapsed < fadeDuration)
        {
            c.a = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            videoPreview.color = c;
            elapsed += Time.deltaTime;
            yield return null;
        }

        c.a = 0f;
        videoPreview.color = c;

        // Stop video to reset frame
        videoPlayer.Stop();
    }
}
