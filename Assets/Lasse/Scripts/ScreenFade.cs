using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScreenFade : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1f;

    private Coroutine currentFade;

    private void Awake()
    {
        if (fadeImage == null)
        {
            Debug.LogError("Fade Image is not assigned.");
        }
    }

    private void Start()
    {
        FadeToTransparent();
    }

    public void FadeToBlack()
    {
        StartFade(1f);
    }

    public void FadeToTransparent()
    {
        StartFade(0f);
    }

    public void FadeToBlackAndLoadScene(string sceneName)
    {
        if (currentFade != null)
            StopCoroutine(currentFade);

        currentFade = StartCoroutine(FadeAndLoad(sceneName));
    }

    private void StartFade(float targetAlpha)
    {
        if (currentFade != null)
            StopCoroutine(currentFade);

        currentFade = StartCoroutine(FadeRoutine(targetAlpha));
    }

    private IEnumerator FadeRoutine(float targetAlpha)
    {
        float startAlpha = fadeImage.color.a;
        float time = 0f;

        Color color = fadeImage.color;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float t = time / fadeDuration;

            // Optional easing (smoothstep)
            t = t * t * (3f - 2f * t);

            color.a = Mathf.Lerp(startAlpha, targetAlpha, t);
            fadeImage.color = color;

            yield return null;
        }

        color.a = targetAlpha;
        fadeImage.color = color;
    }

    private IEnumerator FadeAndLoad(string sceneName)
    {
        // Fade to black first
        yield return FadeRoutine(1f);

        // Async load prevents freezing
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
        op.allowSceneActivation = true;

        while (!op.isDone)
            yield return null;
    }
}