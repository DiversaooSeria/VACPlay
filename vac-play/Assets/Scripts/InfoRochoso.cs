using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;


public class InfoRochoso : MonoBehaviour
{
    public TextMeshProUGUI textPressaoIdeal;
    public TextMeshProUGUI textTempIdeal;
    public TextMeshProUGUI textCompIdeal;
    public string tipoPlaneta;

    async void Start()
    {
        Debug.Log("temperatura: \n" + VariablesController.temperaturaPlanetaRochoso);
        Debug.Log("pressão: \n" + VariablesController.pressaoPlanetaRochoso);
        Debug.Log("composição: \n" + VariablesController.composicaoPlanetaRochoso);


        //        Debug.Log("composição: \n"+VariablesController.composicaoPlanetaGasoso);
    }

    void Awake()
    {

        string[] composicoes = VariablesController.composicaoPlanetaRochoso.Split('.');
        string composicao = composicoes[0].Trim();
        string composicaosemDoisPontos = composicao.Replace(":", "");

        textPressaoIdeal.text = VariablesController.pressaoPlanetaRochoso;
        textCompIdeal.text = composicaosemDoisPontos;
        textTempIdeal.text = VariablesController.temperaturaPlanetaRochoso;
    }
}
