using MongoDB.Bson;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeitorDeInput : MonoBehaviour
{
    public TMP_InputField meuInputField;
    public MongoManager mongoManager;

    [HideInInspector]
    public ObjectId ultimoDocumentoId;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void QuandoBotaoForClicado()
    {
        string textoDigitado = meuInputField.text;
        Debug.Log("Texto digitado: " + textoDigitado);

        var documento = new BsonDocument
        {
            { "Name", textoDigitado },
            { "Data", BsonDateTime.Create(System.DateTime.UtcNow) } 
        };
        ultimoDocumentoId = mongoManager.Insert(documento);
    }
}
