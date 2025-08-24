using UnityEngine;
using UnityEngine.UI;

public class ButtonTransparency2: MonoBehaviour
{

    public Color normalColor;
    public Color clickedColor;
    private Button button;
    public float normalAlpha = 1.0f; // Valor padr�o de transpar�ncia
    public float clickedAlpha = 0.5f; // Valor de transpar�ncia ao clicar


    private void ChangeColor()
    {
        Color newColor = button.image.color;
        newColor.a = clickedAlpha;
        button.image.color = newColor;

        // Encontrar e chamar o m�todo ChangeTransparency() no segundo bot�o
        ButtonTransparencyChanger otherButton = FindObjectOfType<ButtonTransparencyChanger>();
        if (otherButton != null)
        {
            otherButton.ChangeTransparency();
        }
    }


}