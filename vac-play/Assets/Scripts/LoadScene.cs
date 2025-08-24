using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndCredits : MonoBehaviour
{
    private void Start()
    {
        Invoke("WaitToEnd", 6);
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

    }

    public void WaitToEnd()
    {
        SceneManager.LoadScene("Loader");

    }
}
