using UnityEngine;
using System;
using System.Threading.Tasks;
using Xasu;
using Xasu.HighLevel;
using TinCan;
using System.IO;
using System.IO.Enumeration;

public class XasuManager : MonoBehaviour
{
    public static XasuManager Instance { get; private set; }
    public bool IsInitialized { get; private set; } = false;

    public LeitorDeInput leitorDeInput;
    public MongoManager mongoManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        leitorDeInput = FindObjectOfType<LeitorDeInput>();
        mongoManager = FindObjectOfType<MongoManager>();
    }

    private void Start()
    {
        _ = InitializeXasu();
    }

    private async Task InitializeXasu()
    {
        Debug.Log("Iniciando a inicialização do Xasu...");
        try
        {
            await XasuTracker.Instance.Init();

            IsInitialized = true;
            Debug.Log("Xasu inicializado com SUCESSO!");

            await SendExampleStatement();

        }
        catch (Exception ex)
        {
            IsInitialized = false;
            Debug.LogError($"Falha ao inicializar o Xasu: {ex.Message}\n{ex.StackTrace}");
        }
    }

    private async Task SendExampleStatement()
    {
        var actor = new Agent();
        actor.name = "Guilherme";

        //var verb = new Verb();
        //verb.id = new Uri("http://adlnet.gov/expapi/verbs/experienced");
        //verb.display = new LanguageMap();
        //verb.display.Add("en-US", "experienced");

        //var activity = new Activity();
        //activity.id = "http://rusticisoftware.github.io/TinCan.NET";

        var statement = new Statement();
        statement.actor = actor;
        //statement.verb = verb;
        //statement.target = activity;

        await XasuTracker.Instance.Enqueue(statement);
        Debug.Log($"Statement {statement.id} enviado com sucesso!");
    }

    private async Task OnApplicationQuit()
    {
        if (IsInitialized)
        {
            Debug.Log("Finalizando o Xasu e salvando os logs...");
            XasuTracker.Instance.Finalize().Wait();

            string logPath = Path.Combine(Application.persistentDataPath, "traces.log");
            
            Debug.Log(File.Exists(logPath) ? $"Log encontrado em: {logPath}" : "Log não encontrado.");

            if (File.Exists(logPath))
            {
                var s3Writer = new S3LogWriter("AKIAVVZPCIPVER5Z3XWL", "", Amazon.RegionEndpoint.USEast2);
                string fileName = $"log_{System.DateTime.UtcNow:yyyyMMdd_HHmmss}.json";
                await s3Writer.UploadFileAsync(logPath, fileName);

                mongoManager.UpdateLogPath(leitorDeInput.ultimoDocumentoId, fileName);

                File.Delete(logPath);
            }

            Debug.Log("Xasu finalizado e log enviado para S3.");
        }
    }

}
