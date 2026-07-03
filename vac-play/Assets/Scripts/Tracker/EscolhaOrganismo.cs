using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Xasu.HighLevel;

public class EscolhaOrganismo : MonoBehaviour
{
    public void EscolhaOrganismoZero()
    {
        GameObjectTracker.Instance.Interacted("organismo-do-zero");
    }
    public void EscolhaOrganismoPronto()
    {
        GameObjectTracker.Instance.Interacted("organismo-pronto");
    }
}
