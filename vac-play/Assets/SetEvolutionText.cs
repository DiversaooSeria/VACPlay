using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetEvolutionText : MonoBehaviour
{

    public TextMeshProUGUI textEvolucao;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Awake()
    {
        string evolutionText = VariablesController.retornoGptEvolucao;


        textEvolucao.text = "Seu organismo evoluiu: " + evolutionText + "!!";




    }
}
