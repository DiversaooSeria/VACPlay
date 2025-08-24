using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TypewriterEffect : MonoBehaviour
{
    public float typingSpeed = 0.05f;
    private string fullText;
    private string currentText = "";
    private TextMeshProUGUI textComponent;
    public float zoomDuration = 1.5f;
    public float zoomScale = 1.2f;
    public float maxScale = 1.1f;
    public float delayBeforeStart = 2.0f; // Tempo de espera em segundos


    private void Start()
    {
        textComponent = GetComponentInChildren<TextMeshProUGUI>();
        fullText = textComponent.text;
        textComponent.text = "";
        StartCoroutine(TypeText());

    }

    private IEnumerator TypeText()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        foreach (char letter in fullText)
        {

            currentText += letter;
            textComponent.text = currentText;
            yield return new WaitForSeconds(typingSpeed);

            if(sceneName == "Main" || sceneName == "Regras" || sceneName == "Explicação inicial")
            {
                float scale = Mathf.Lerp(0.8f, maxScale, textComponent.text.Length / (float)fullText.Length);
                textComponent.transform.localScale = new Vector3(scale, scale, scale);
            }

        }

/*        Vector3 originalScale = textComponent.transform.localScale;
        float zoomStartTime = Time.time;

        while (Time.time < zoomStartTime + zoomDuration)
        {
            float progress = (Time.time - zoomStartTime) / zoomDuration;
            float scale = Mathf.Lerp(originalScale.x, originalScale.x * zoomScale, progress);
            textComponent.transform.localScale = new Vector3(scale, scale, scale);
            yield return null;
        }*/
    }
}
