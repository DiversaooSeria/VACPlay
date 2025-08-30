using UnityEngine;
using Xasu.HighLevel;

public class EndTutorial : MonoBehaviour
{
    public void CompleteTutorial()
    {
        CompletableTracker.Instance.Completed("tutorial");
        Debug.Log("Tutorial marcado como completo!");
    }
}
