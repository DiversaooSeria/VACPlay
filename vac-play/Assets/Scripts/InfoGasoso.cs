using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class InfoGasoso : MonoBehaviour
{
    public TextMeshProUGUI textPressaoIdeal;
    public TextMeshProUGUI textTempIdeal;
    public TextMeshProUGUI textCompIdeal;
    public string tipoPlaneta;
    private bool deu = false;

    async void Start()
    {
        Debug.Log("temperatura: \n" + VariablesController.temperaturaPlanetaGasoso);
        Debug.Log("pressão: \n" + VariablesController.pressaoPlanetaGasoso);
        Debug.Log("composição: \n" + VariablesController.composicaoPlanetaGasoso);


        //        Debug.Log("composição: \n"+VariablesController.composicaoPlanetaGasoso);
    }


    void Awake()
    {

        string[] composicoes = VariablesController.composicaoPlanetaGasoso.Split('.');
        string composicao = composicoes[0].Trim();
        string composicaosemDoisPontos = composicao.Replace(":", "");

        textPressaoIdeal.text = VariablesController.pressaoPlanetaGasoso;
        textCompIdeal.text = composicaosemDoisPontos;
        textTempIdeal.text = VariablesController.temperaturaPlanetaGasoso;
    }
    /* bool sucesso = await CarregaInfo();

     if (sucesso)
     {
         textCompIdeal.enabled = true;
     }
     else
     {
         textCompIdeal.text = "deu erro";
         textPressaoIdeal.enabled = true;
     }
 }

 private async Task<bool> CarregaInfo()
 {
     string messageGpt = VariablesController.retornoGpt;


     if (string.IsNullOrEmpty(messageGpt))
     {
         messageGpt = "Planeta Gasoso: \n" +
             " Temperatura ideal para a vida: Uma faixa de temperatura que seja adequada para a vida, nem muito quente nem muito fria.\n" +
             "2. Pressão suportável: Uma pressão atmosférica que permita a existência de organismos vivos.\r\n" +
             "3. Composição atmosférica: Presença de elementos químicos essenciais para a vida, como oxigênio, carbono e nitrogênio.\r\n\r\n" +
             "Planeta Rochoso:\r\n1. Temperatura habitável: Uma temperatura que permita a existência de água líquida, considerada essencial para a vida tal como a conhecemos.\r\n" +
             "2. Gravidade adequada: Uma gravidade que seja suficiente para reter uma atmosfera, mas não tão intensa que dificulte a locomoção dos seres vivos.\r\n" +
             "3. Composição atmosférica: Uma atmosfera composta por gases apropriados, como oxigênio e dióxido de carbono.\r\n\r\n" +
             "Planeta Anão:\r\n1. Temperatura tolerável: Uma temperatura que permita a estabilidade da vida, sem extremos de calor ou frio.\r\n" +
             "2. Pressão atmosférica viável: Uma pressão atmosférica que permita a existência de água líquida e outros componentes essenciais para a vida.\r\n" +
             "3. Composição atmosférica favorável: Presença de gases como oxigênio, nitrogênio e outros necessários para a vida.\r\n\r\nLua:\r\n" +
             "1. Temperatura habitável: Uma temperatura adequada que possibilite a formação e manutenção de água líquida.\r\n" +
             "2. Gravidade suportável: Uma gravidade que não seja excessivamente alta para permitir a existência de atmosfera e não seja baixa o suficiente para que não haja retenção de gases essenciais.\r\n3. Composição atmosférica: Presença de uma atmosfera adequada, com os elementos necessários, como oxigênio e carbono.";
     }
    // Debug.Log("formatando a mensagem: \n" + messageGpt);


     string messageParsedRockyTemperature = "";
     string messageParsedRockyPression = "";
     string messageParsedRockyComposition = "";


     int count = 0;
     // Use expressões regulares para extrair informações de cada corpo celeste
     string pattern = @"(\w+):\s+- Temperatura:\s+(.+?)[.]+\s+- Pressão:\s+(.+?)[.]+\s+- Composição atmosférica:\s+(.+?)[.]";
     MatchCollection matches = Regex.Matches(messageGpt, pattern);

     Debug.Log("tipo: " + tipoPlaneta);

     if (matches.Count > 0)
     {
         // Construa um texto com as informações extraídas de todos os corpos celestes
         //string info = "Informações dos Corpos Celestes:\n";

         foreach (Match match in matches)
         {
             Debug.Log("matching");
             string bodyName = match.Groups[1].Value;
             string temperature = match.Groups[2].Value;
             string pressure = match.Groups[3].Value;
             string composition = match.Groups[4].Value;
             //name = bodyName;

             if (count == 0)
             {
                 Debug.Log("eh gasoso 1");
                 // rochosos
                 messageParsedRockyComposition = composition;
                 messageParsedRockyPression = pressure;
                 messageParsedRockyTemperature = temperature;
                 //break;

             }

             if(count == 3) { deu = true; }

             count += 1;
         }
     }

     //deu bom
     // textDisplay.text = name;
     Debug.Log("eh gasoso 2");
     textPressaoIdeal.text = messageParsedRockyPression;
     textCompIdeal.text = messageParsedRockyComposition;
     textTempIdeal.text = messageParsedRockyTemperature;

     return true;

 }*/
}
