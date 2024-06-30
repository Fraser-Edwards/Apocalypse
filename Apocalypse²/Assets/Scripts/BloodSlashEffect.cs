using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BloodSlashEffect : MonoBehaviour
{
    public Image bloodSlashImage;
    public float fadeDuration = 1f; // Duration for the fade-out

    private void Start()
    {
        // Ensure the image is initially invisible
        bloodSlashImage.color = new Color(bloodSlashImage.color.r, bloodSlashImage.color.g, bloodSlashImage.color.b, 0);
    }

    public void ShowBloodSlash()
    {
        // Stop any ongoing fade coroutine
        StopAllCoroutines();
        // Start the fade-in and fade-out coroutine
        StartCoroutine(FadeInAndOut());
    }

    private IEnumerator FadeInAndOut()
    {
        // Fade in
        float elapsedTime = 0f;
        Color color = bloodSlashImage.color;
        while (elapsedTime < fadeDuration / 2)
        {
            color.a = Mathf.Lerp(0, 1, elapsedTime / (fadeDuration / 2));
            bloodSlashImage.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        color.a = 1;
        bloodSlashImage.color = color;

        // Wait a moment before fading out
        yield return new WaitForSeconds(0.5f);

        // Fade out
        elapsedTime = 0f;
        while (elapsedTime < fadeDuration / 2)
        {
            color.a = Mathf.Lerp(1, 0, elapsedTime / (fadeDuration / 2));
            bloodSlashImage.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        color.a = 0;
        bloodSlashImage.color = color;
    }
}
