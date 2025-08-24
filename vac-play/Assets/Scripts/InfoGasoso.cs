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
        Debug.Log("press�o: \n" + VariablesController.pressaoPlanetaGasoso);
        Debug.Log("composi��o: \n" + VariablesController.composicaoPlanetaGasoso);


        //        Debug.Log("composi��o: \n"+VariablesController.composicaoPlanetaGasoso);
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
             "2. Press�o suport�vel: Uma press�o atmosf�rica que permita a exist�ncia de organismos vivos.\r\n" +
             "3. Composi��o atmosf�rica: Presen�a de elementos qu�micos essenciais para a vida, como oxig�nio, carbono e nitrog�nio.\r\n\r\n" +
             "Planeta Rochoso:\r\n1. Temperatura habit�vel: Uma temperatura que permita a exist�ncia de �gua l�quida, considerada essencial para a vida tal como a conhecemos.\r\n" +
             "2. Gravidade adequada: Uma gravidade que seja suficiente para reter uma atmosfera, mas n�o t�o intensa que dificulte a locomo��o dos seres vivos.\r\n" +
             "3. Composi��o atmosf�rica: Uma atmosfera composta por gases apropriados, como oxig�nio e di�xido de carbono.\r\n\r\n" +
             "Planeta An�o:\r\n1. Temperatura toler�vel: Uma temperatura que permita a estabilidade da vida, sem extremos de calor ou frio.\r\n" +
             "2. Press�o atmosf�rica vi�vel: Uma press�o atmosf�rica que permita a exist�ncia de �gua l�quida e outros componentes essenciais para a vida.\r\n" +
             "3. Composi��o atmosf�rica favor�vel: Presen�a de gases como oxig�nio, nitrog�nio e outros necess�rios para a vida.\r\n\r\nLua:\r\n" +
             "1. Temperatura habit�vel: Uma temperatura adequada que possibilite a forma��o e manuten��o de �gua l�quida.\r\n" +
             "2. Gravidade suport�vel: Uma gravidade que n�o seja excessivamente alta para permitir a exist�ncia de atmosfera e n�o seja baixa o suficiente para que n�o haja reten��o de gases essenciais.\r\n3. Composi��o atmosf�rica: Presen�a de uma atmosfera adequada, com os elementos necess�rios, como oxig�nio e carbono.";
     }
    // Debug.Log("formatando a mensagem: \n" + messageGpt);


     string messageParsedRockyTemperature = "";
     string messageParsedRockyPression = "";
     string messageParsedRockyComposition = "";


     int count = 0;
     // Use express�es regulares para extrair informa��es de cada corpo celeste
     string pattern = @"(\w+):\s+- Temperatura:\s+(.+?)[.]+\s+- Press�o:\s+(.+?)[.]+\s+- Composi��o atmosf�rica:\s+(.+?)[.]";
     MatchCollection matches = Regex.Matches(messageGpt, pattern);

     Debug.Log("tipo: " + tipoPlaneta);

     if (matches.Count > 0)
     {
         // Construa um texto com as informa��es extra�das de todos os corpos celestes
         //string info = "Informa��es dos Corpos Celestes:\n";

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
