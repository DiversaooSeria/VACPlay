using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetFinalText : MonoBehaviour
{

    public TextMeshProUGUI textPressaoIdeal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Awake()
    {
        string planetType = VariablesController.tipoPlaneta;
        string localExperiment = VariablesController.localExperimento;
        string cellType = VariablesController.tipoCelula;

        string complemnetarPlaneta = "";
        if(planetType == "gasoso" || planetType =="rochoso" || planetType == "anao") { complemnetarPlaneta = "no planeta "; } else
        {
            complemnetarPlaneta = "na ";
        }


        textPressaoIdeal.text = "Parabens! Juntando os conhecimentos \n" +
            "interdisciplinares você foi capaz de perpetuar um \n" + cellType+ "\n"+
            "em " + localExperiment + " " +complemnetarPlaneta + planetType + "!!";




    }
}
