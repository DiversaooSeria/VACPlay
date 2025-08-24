using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioClip clickSound;
    public AudioSource audioSource;
    public Button button;

    public void Start()
    {
        button = GetComponent<Button>();
       // button.onClick.AddListener(PlayClickSound); // Associa o m�todo ao evento de clique do bot�o
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound); // Reproduz o som de clique
    }
}