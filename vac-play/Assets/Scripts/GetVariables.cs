using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetVariables : MonoBehaviour
{
  public void getCellType(string tipo)
    {
        VariablesController.tipoCelula = tipo;
    }

    public void getCellSize(string size)
    {
        VariablesController.tamanhoCelula = size;
    }


    public void getMembraneType(string membrana)
    {
        VariablesController.tipoMembrana = membrana;
    }

    public void getMetabolismType(string metabolismo)
    {
        VariablesController.metabolismo = metabolismo;
    }

    public void getNutricion(string nutricao)
    {
        VariablesController.nutricao = nutricao;
    }

    public void getReprodution(string reproducao)
    {
        VariablesController.reproducao = reproducao;
    }

    public void getDefence(string defesa)
    {
        VariablesController.mecanismoDefesa = defesa;
    }

    public void getPlanetType(string tipo)
    {
        VariablesController.tipoPlaneta = tipo;
    }

    public void getLocalExperimento(string local)
    {
        VariablesController.localExperimento = local;
    }

    public void gettypeEvent(string evento)
    {
        VariablesController.tipoEvento = evento;
    }
}
