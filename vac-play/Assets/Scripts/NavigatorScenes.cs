using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigatorScenes : MonoBehaviour
{
    public void movingBetweenScenes(int sceneID)
    {
        Debug.Log("navegando..");
        SceneManager.LoadScene(sceneID);
    }

}
