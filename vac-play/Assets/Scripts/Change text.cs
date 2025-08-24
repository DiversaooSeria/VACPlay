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
    public GameObject objetoVazio; // Referência ao objeto vazio que contém o TextMeshProUGUI

    private void Start()
    {
        button = GetComponent<Button>();

    }

    // Função que muda o texto ao ser chamada
    public void ChangeTextOnClick()
    {

        TextMeshProUGUI buttonTextComponent = button.GetComponentInChildren<TextMeshProUGUI>();

        if (buttonTextComponent.text == "DICA")
        {
            textDisplay.text = "Um organismo anaeróbico é um organismo que não precisa\n" +
                "de oxigênio para sua sobrevivência. Estes organismos\nsão de três tipos:\n\n" +
            "Obrigatório: são prejudicados pela presença de oxigênio\n" +
            "(o organismo reage negativamente ou até mesmo morre);\n" +
            "Aerotolerante: não usam oxigênio, mas tolera sua presença;\n" +
            "Facultativo: não precisam de oxigênio, mas o usam se estiver\n" +
            "presente.";
            buttonTextComponent.text = "VOLTAR";

            objetoVazio.SetActive(false);


        }
        else if (buttonTextComponent.text == "VOLTAR")
        {
            textDisplay.text = " Se a temperatura for baixa demais, reações químicas muito\n" +
                "importantes para que o organismo dos seres vivos funcionem não\r\n" +
                "podem acontecer, e a vida não pode se reproduzir.\n\n" +
                "Existem alguns seres vivos que vivem em temperaturas muito\n" +
                "baixas, como a bactéria Planococcus halocryophilus, que vivem\n" +
                "em temperaturas de -15ºC! Mas a maioria dos seres vivos morrem\n" +
                "quando as temperaturas chegam a menos de 0ºC.\n";

            buttonTextComponent.text = "DICA";
            objetoVazio.SetActive(true);



        } else if(buttonTextComponent.text == "CONTINUA..")
        {
            textDisplay.text = "Estima-se que no início da vida na Terra, quando células que fazem\n" +
                "fotossíntese como as cianobactérias surgiram, muitos seres vivos\n" +
                " morreram intoxicados pela presença do oxigênio, que antes não\n" +
                "era tão presente na Terra.";

            buttonTextComponent.text = "VOLTA";

        } else if(buttonTextComponent.text == "VOLTA")
        {
            textDisplay.text = "O oxigênio é tóxico para muitos seres vivos anaeróbicos, que não\n"+
            "precisam de oxigênio para sobreviverem, porque se ingerirem o\n"+
            "oxigênio, a reação causada dentro do organismo pode ser fatal.\n\n"+
            "Por isso, os seres anaeróbicos não precisam de oxigênio e não\n"+
            "podem entrar em contato com oxigênio, senão serão intoxicados\n"+
            "e morrerão!";

            buttonTextComponent.text = "CONTINUA..";

        }

    }
}
