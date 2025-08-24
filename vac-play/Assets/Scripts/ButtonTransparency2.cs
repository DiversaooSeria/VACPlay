using UnityEngine;
using UnityEngine.UI;

public class ButtonTransparency2: MonoBehaviour
{

    public Color normalColor;
    public Color clickedColor;
    private Button button;
    public float normalAlpha = 1.0f; // Valor padrão de transparência
    public float clickedAlpha = 0.5f; // Valor de transparência ao clicar


    private void ChangeColor()
    {
        Color newColor = button.image.color;
        newColor.a = clickedAlpha;
        button.image.color = newColor;

        // Encontrar e chamar o método ChangeTransparency() no segundo botão
        ButtonTransparencyChanger otherButton = FindObjectOfType<ButtonTransparencyChanger>();
        if (otherButton != null)
        {
            otherButton.ChangeTransparency();
        }
    }


}