using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class showOrganism : MonoBehaviour
{

    public GameObject eucarionte;
    public GameObject procarionte;   
    public Button selecionarButton;
    //  public TextMeshProUGUI textDisplay;


    void Start()
    {
        selecionarButton = GetComponent<Button>();

    }

    public void Awake()
    {

        Debug.Log("showing organisms");
        string cellType = VariablesController.tipoCelula;
        //        textDisplay.enabled = true;

        if (cellType == "EUCARIONTE")
        {
            eucarionte.GetComponentInChildren<Image>().enabled = true;

        }
        else if (cellType == "PROCARIONTE")
        {
            procarionte.GetComponentInChildren<Image>().enabled = true;

        }
    }
    // Start is called before the first frame update
    public void ShowOrganisms()
    {

        string cellType = VariablesController.tipoCelula;
        //        textDisplay.enabled = true;

        Debug.Log("showing organisms 2: " + cellType);
        if (cellType == "EUCARIONTE")
        {
            eucarionte.GetComponentInChildren<Image>().enabled = true;

        } else if(cellType == "PROCARIONTE")
        {
            procarionte.GetComponentInChildren<Image>().enabled = true;

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
