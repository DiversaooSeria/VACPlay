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
        // Iniciar a reprodu��o do �udio de fundo
    }

    public void PauseBackgroundMusic()
    {
        // Pausar a reprodu��o do �udio de fundo
    }

    // Outros m�todos para retomar e parar a reprodu��o

    // Voc� pode chamar esses m�todos a partir de outros scripts
}
