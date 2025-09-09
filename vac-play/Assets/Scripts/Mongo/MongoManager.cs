using MongoDB.Bson;
using MongoDB.Driver;
using UnityEngine;

public class MongoManager : MonoBehaviour
{
    private IMongoCollection<BsonDocument> collection;

    void Awake()
    {
        string connectionString = "mongodb+srv://destinoCosmico:@cluster0.8tqbe.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("destino_cosmico");
        collection = database.GetCollection<BsonDocument>("user_profile");
        DontDestroyOnLoad(gameObject);
    }

    public ObjectId Insert(BsonDocument documento)
    {
        if (documento == null || documento.ElementCount == 0)
        {
            Debug.LogWarning("Documento vazio.");
            return ObjectId.Empty;
        }

        try
        {
            collection.InsertOne(documento);
            Debug.Log("Documento inserido com sucesso!");
            return documento["_id"].AsObjectId;
        }
        catch (System.Exception e)
        {
            Debug.LogError("Erro ao inserir no MongoDB: " + e.Message);
            return ObjectId.Empty;
        }
    }

    public void UpdateLogPath(ObjectId id, string logPath)
    {
        if (id == ObjectId.Empty)
        {
            Debug.LogWarning("ID inválido para update.");
            return;
        }

        var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
        var update = Builders<BsonDocument>.Update.Set("FileName", logPath);

        try
        {
            collection.UpdateOne(filter, update);
            Debug.Log("Documento atualizado com logPath.");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Erro ao atualizar documento: " + e.Message);
        }
    }


}
