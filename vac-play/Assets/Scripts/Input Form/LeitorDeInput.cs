using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeitorDeInput : MonoBehaviour
{
    public TMP_InputField meuInputField;
    public MongoManager mongoManager;

    public void QuandoBotaoForClicado()
    {
        string textoDigitado = meuInputField.text;
        Debug.Log("Texto digitado: " + textoDigitado);

        string jsonBody = $"{{\"name\": \"{textoDigitado}\", \"date\": \"{System.DateTime.UtcNow:O}\"}}";
        mongoManager.Insert(jsonBody);
    }
}
