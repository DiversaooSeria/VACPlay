using UnityEngine;
using System;
using System.Threading.Tasks;
using Xasu;
using Xasu.HighLevel;
using TinCan;

public class XasuManager : MonoBehaviour
{
    public static XasuManager Instance { get; private set; }
    public bool IsInitialized { get; private set; } = false;

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

            // Envia um exemplo de statement após inicializar
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

    private async void OnApplicationQuit()
    {
        if (IsInitialized)
        {
            Debug.Log("Finalizando o Xasu e salvando os logs...");
            await XasuTracker.Instance.Finalize();
            Debug.Log("Xasu finalizado.");
        }
    }
}
