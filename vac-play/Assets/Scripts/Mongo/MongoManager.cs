using MongoDB.Bson;
using MongoDB.Driver;
using UnityEngine;

public class MongoManager : MonoBehaviour
{
    private IMongoCollection<BsonDocument> collection;

    void Awake()
    {
        string connectionString = "mongodb+srv://destinoCosmico:PASSWORD@cluster0.8tqbe.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("destino_cosmico");
        collection = database.GetCollection<BsonDocument>("user_profile");
    }

    public void Insert(string body)
    {
        if (string.IsNullOrEmpty(body))
        {
            Debug.LogWarning("Body vazio.");
            return;
        }

        try
        {
            var documento = BsonDocument.Parse(body);
            collection.InsertOne(documento);
            Debug.Log("Documento inserido com sucesso!");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Erro ao inserir no MongoDB: " + e.Message);
        }
    }
}
