using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string escolha;
    public Button button;
    public GameObject objetoVazio; // Refer�ncia ao objeto vazio que cont�m o TextMeshProUGUI

    private void Start()
    {
        button = GetComponent<Button>();

    }

    // Fun��o que muda o texto ao ser chamada
    public void ChangeTextOnClick()
    {

        TextMeshProUGUI buttonTextComponent = button.GetComponentInChildren<TextMeshProUGUI>();

        if (buttonTextComponent.text == "DICA")
        {
            textDisplay.text = "Um organismo anaer�bico � um organismo que n�o precisa\n" +
                "de oxig�nio para sua sobreviv�ncia. Estes organismos\ns�o de tr�s tipos:\n\n" +
            "Obrigat�rio: s�o prejudicados pela presen�a de oxig�nio\n" +
            "(o organismo reage negativamente ou at� mesmo morre);\n" +
            "Aerotolerante: n�o usam oxig�nio, mas tolera sua presen�a;\n" +
            "Facultativo: n�o precisam de oxig�nio, mas o usam se estiver\n" +
            "presente.";
            buttonTextComponent.text = "VOLTAR";

            objetoVazio.SetActive(false);


        }
        else if (buttonTextComponent.text == "VOLTAR")
        {
            textDisplay.text = " Se a temperatura for baixa demais, rea��es qu�micas muito\n" +
                "importantes para que o organismo dos seres vivos funcionem n�o\r\n" +
                "podem acontecer, e a vida n�o pode se reproduzir.\n\n" +
                "Existem alguns seres vivos que vivem em temperaturas muito\n" +
                "baixas, como a bact�ria Planococcus halocryophilus, que vivem\n" +
                "em temperaturas de -15�C! Mas a maioria dos seres vivos morrem\n" +
                "quando as temperaturas chegam a menos de 0�C.\n";

            buttonTextComponent.text = "DICA";
            objetoVazio.SetActive(true);



        } else if(buttonTextComponent.text == "CONTINUA..")
        {
            textDisplay.text = "Estima-se que no in�cio da vida na Terra, quando c�lulas que fazem\n" +
                "fotoss�ntese como as cianobact�rias surgiram, muitos seres vivos\n" +
                " morreram intoxicados pela presen�a do oxig�nio, que antes n�o\n" +
                "era t�o presente na Terra.";

            buttonTextComponent.text = "VOLTA";

        } else if(buttonTextComponent.text == "VOLTA")
        {
            textDisplay.text = "O oxig�nio � t�xico para muitos seres vivos anaer�bicos, que n�o\n"+
            "precisam de oxig�nio para sobreviverem, porque se ingerirem o\n"+
            "oxig�nio, a rea��o causada dentro do organismo pode ser fatal.\n\n"+
            "Por isso, os seres anaer�bicos n�o precisam de oxig�nio e n�o\n"+
            "podem entrar em contato com oxig�nio, sen�o ser�o intoxicados\n"+
            "e morrer�o!";

            buttonTextComponent.text = "CONTINUA..";

        }

    }
}
