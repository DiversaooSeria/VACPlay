using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChooseFinal : MonoBehaviour
{
    public void ChooseFinalPlanet()
    {
        string planetType = VariablesController.tipoPlaneta;

        if(planetType == "rochoso")
        {
            SceneManager.LoadScene("Final da Evolucao rochoso");
        } else if(planetType == "gasoso")
        {
            SceneManager.LoadScene("Final da Evolucao Gasoso");
        }
        else if (planetType == "lua")
        {
            SceneManager.LoadScene("Final da Evolucao Lua");
        }
        else if (planetType == "anao")
        {
            SceneManager.LoadScene("Final da Evolucao Anao");
        }


    }

    public void ChooseLocalPlanet()
    {
        string planetType = VariablesController.tipoPlaneta;

        if (planetType == "rochoso")
        {
            SceneManager.LoadScene("ROCHOSO");
        }
        else if (planetType == "gasoso")
        {
            SceneManager.LoadScene("GASOSO");
        }
        else if (planetType == "lua")
        {
            SceneManager.LoadScene("LUA");
        }
        else if (planetType == "anao")
        {
            SceneManager.LoadScene("ANAO");
        }


    }
}
