using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Xasu.HighLevel;
using System;

public class StartTracker : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(InitTracker());
    }

    IEnumerator InitTracker()
    {
        while (XasuManager.Instance == null || !XasuManager.Instance.IsInitialized)
        {
            yield return null;
        }

        try
        {
            var statementPromise = CompletableTracker.Instance.Initialized("DestinoCosmico", CompletableTracker.CompletableType.Game);

            var statement = statementPromise.Promise;
            Debug.Log("Initialized statement sent with id: " + statementPromise.Statement.id);
        }
        catch (AggregateException aggEx)
        {
            Debug.Log("Failed! " + aggEx.GetType().ToString());
            foreach (var ex in aggEx.InnerExceptions)
            {
                Debug.Log("Inner Exception: " + ex.GetType().ToString());
            }
        }
    }

}
