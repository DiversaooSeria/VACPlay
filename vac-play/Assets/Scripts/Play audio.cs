using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Xasu;
using Xasu.HighLevel;
using System;

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

        try
        {
            var statementPromise = GameObjectTracker.Instance.Interacted("botao");

            // Doing any modifications to the Statement in traceTask.Statement property is safe.

            var statement = statementPromise.Promise;
            Debug.Log("Completed statement sent with id: " + statementPromise.Statement.id);
        }
        catch (AggregateException aggEx)
        {
            Debug.Log("Failed! " + aggEx.GetType().ToString());
            // You can check the inner exceptions from each working mode.
            foreach (var ex in aggEx.InnerExceptions)
            {
                Debug.Log("Inner Exception: " + ex.GetType().ToString());
            }
        }
    }
}