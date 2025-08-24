using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesController : MonoBehaviour
{
  public static string tipoCelula;
  public static string tamanhoCelula;
  public static string tipoMembrana;
  public static string metabolismo;
  public static string nutricao;
  public static string reproducao;
  public static string mecanismoDefesa;
  public static string retornoGpt;
  public static string tipoPlaneta;
  public static string localExperimento;
    public static string tipoEvento;
    public static string retornoGptEvolucao;
    public static string composicaoPlanetaGasoso;
    public static string temperaturaPlanetaGasoso;
    public static string pressaoPlanetaGasoso;

    public static string composicaoPlanetaRochoso;
    public static string temperaturaPlanetaRochoso;
    public static string pressaoPlanetaRochoso;

    public static string composicaoPlanetaAnao;
    public static string temperaturaPlanetaAnao;
    public static string pressaoPlanetaAnao;

    public static string composicaoPlanetaLua;
    public static string temperaturaPlanetaLua;
    public static string pressaoPlanetaLua;

    public static VariablesController Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }


}
