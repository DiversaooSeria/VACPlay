using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;


public class InfoAnao : MonoBehaviour
{
    public TextMeshProUGUI textPressaoIdeal;
    public TextMeshProUGUI textTempIdeal;
    public TextMeshProUGUI textCompIdeal;
    public string tipoPlaneta;

    async void Start()
    {
        Debug.Log("temperatura: \n" + VariablesController.temperaturaPlanetaAnao);
        Debug.Log("pressão: \n" + VariablesController.pressaoPlanetaAnao);
        Debug.Log("composição: \n" + VariablesController.composicaoPlanetaAnao);


        //        Debug.Log("composição: \n"+VariablesController.composicaoPlanetaGasoso);
    }

    void Awake()
        {
        string[] composicoes = VariablesController.composicaoPlanetaAnao.Split('.');
        string composicao = composicoes[0].Trim();
        string composicaosemDoisPontos = composicao.Replace(":", "");


        textPressaoIdeal.text = VariablesController.pressaoPlanetaAnao;
            textCompIdeal.text = composicaosemDoisPontos;
            textTempIdeal.text = VariablesController.temperaturaPlanetaAnao;
        }

    
}
