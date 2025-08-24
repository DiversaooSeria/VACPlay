using UnityEngine;
using TMPro;
using System.Collections;

public class TextFadeIn : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public float fadeInDuration = 3.0f;
    public float delayBeforeFade = 2.0f;

    private void Start()
    {
        StartCoroutine(FadeInText());
    }

    IEnumerator FadeInText()
    {
//        yield return new WaitForSeconds(delayBeforeFade);

        if (textDisplay == null)
        {
            Debug.LogError("TextMeshProUGUI component not assigned!");
            yield break;
        }

        Color originalColor = textDisplay.color;
        Color transparentColor = originalColor;
        transparentColor.a = 0;

        float elapsedTime = 0;

        yield return new WaitForSeconds(delayBeforeFade);

        while (elapsedTime < fadeInDuration)
        {

            textDisplay.color = Color.Lerp(transparentColor, originalColor, elapsedTime / fadeInDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }


        textDisplay.color = originalColor;
    }
}
