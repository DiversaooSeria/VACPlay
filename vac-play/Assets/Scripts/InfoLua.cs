using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;


public class InfoLua : MonoBehaviour
{
    public TextMeshProUGUI textPressaoIdeal;
    public TextMeshProUGUI textTempIdeal;
    public TextMeshProUGUI textCompIdeal;
    public string tipoPlaneta;

    async void Start()
    {
        Debug.Log("temperatura: \n" + VariablesController.temperaturaPlanetaLua);
        Debug.Log("pressão: \n" + VariablesController.pressaoPlanetaLua);
        Debug.Log("composição: \n" + VariablesController.composicaoPlanetaLua);


        //        Debug.Log("composição: \n"+VariablesController.composicaoPlanetaGasoso);
    }

    void Awake()
    {

        string[] composicoes = VariablesController.composicaoPlanetaLua.Split('.');
        string composicao = composicoes[0].Trim();
        string composicaosemDoisPontos = composicao.Replace(":", "");


        textPressaoIdeal.text = VariablesController.pressaoPlanetaLua;
        textCompIdeal.text = composicaosemDoisPontos;
        textTempIdeal.text = VariablesController.temperaturaPlanetaLua;
    }
}
