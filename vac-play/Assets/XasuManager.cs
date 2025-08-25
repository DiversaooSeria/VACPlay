using UnityEngine;
using System.Threading.Tasks;
using Xasu;// Namespace correto para a API de alto nível
using Xasu.HighLevel;

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

            // ADICIONE ISSO: Define o ator para os próximos eventos
            //Xasu.Instance.Login("player_test_01");

            // Envia o evento de inicialização utilizando a API de alto nível
            GameObjectTracker.Instance.Interacted("mesita");
            Debug.Log("Evento 'Game Initialized' enviado para o Xasu!");
        }
        catch (System.Exception ex)
        {
            IsInitialized = false;
            Debug.LogError($"Falha ao inicializar o Xasu: {ex.Message}\n{ex.StackTrace}");
        }
    }

    private async void OnApplicationQuit()
    {
        if (IsInitialized)
        {
            Debug.Log("Finalizando o Xasu e salvando os logs...");
            XasuTracker.Instance.Finalize().Wait();
            Debug.Log("Xasu finalizado.");
        }
    }
}
