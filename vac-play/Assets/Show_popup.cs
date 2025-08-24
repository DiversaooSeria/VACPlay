using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Show_popup : MonoBehaviour
{
    public Button ativarPopup;
    public GameObject popup;
    public TextMeshProUGUI textDisplay;
    public GameObject closeIcon;
    public GameObject closeIconFundo;


    // Start is called before the first frame update
    void Start()
    {
        ativarPopup = GetComponent<Button>();

    }

    // Função que faz aparecer o popup
    public void ShowPopUpWindow()
    {
        // mostra o popup, imagem de fundo
        Image popupFundo = popup.GetComponentInChildren<Image>();
         popupFundo.enabled = true;
        // mostra tyexto popup
        textDisplay.enabled = true;
        // mostrar o close
        // Image closeIconImage = closeIcon.GetComponentInChildren<Image>();
        closeIcon.GetComponentInChildren<Image>().enabled = true;
        closeIconFundo.GetComponentInChildren<Image>().enabled = true;


    }
    // Função que fecha o popup
    public void ClosePopUpWindow()
    {
        // mostra o popup, imagem de fundo
        Image popupFundo = popup.GetComponentInChildren<Image>();
        popupFundo.enabled = false;
        // mostra tyexto popup
        textDisplay.enabled = false;
        // mostrar o close
        // Image closeIconImage = closeIcon.GetComponentInChildren<Image>();
        closeIcon.GetComponentInChildren<Image>().enabled = false;
        closeIconFundo.GetComponentInChildren<Image>().enabled = false;


    }

}
