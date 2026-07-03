using Assets.Scripts.Tracker;
using UnityEngine;
using Xasu;
using Xasu.HighLevel;

public class ObjectChoosed : MonoBehaviour
{
    public string objectId;
    public string objectName;
    public string objectDescription;
    public CustomHighLevelTracker.TrackedGameObject objectType = CustomHighLevelTracker.TrackedGameObject.GameObject;

    public void Choosed()
    {
        CustomHighLevelTracker.Instance.ChoosedWithDescription(
            objectId,
            objectType,
            objectName,
            objectDescription 
        );
    }
}
