using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Xasu.HighLevel;
using System;

public class StartTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            var statementPromise = CompletableTracker.Instance.Initialized("tutorial");

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
