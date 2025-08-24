using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBackgroundMusic()
    {
        // Iniciar a reprodução do áudio de fundo
    }

    public void PauseBackgroundMusic()
    {
        // Pausar a reprodução do áudio de fundo
    }

    // Outros métodos para retomar e parar a reprodução

    // Você pode chamar esses métodos a partir de outros scripts
}
