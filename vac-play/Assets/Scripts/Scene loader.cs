using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Image fadeImage; // O objeto de tela preta para o fade
    public float fadeDuration = 0.5f; // Duração do fade em segundos

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0.0f;
        Color startColor = fadeImage.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0.0f);

        while (elapsedTime < fadeDuration)
        {
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = Color.Lerp(startColor, endColor, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Carregar a próxima cena
        SceneManager.LoadScene("Menu");
    }
}
