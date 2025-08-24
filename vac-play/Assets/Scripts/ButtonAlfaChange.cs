using UnityEngine;
using UnityEngine.UI;

public class ButtonTransparencyChanger : MonoBehaviour
{
    public float normalAlpha = 1.0f; // Valor padr�o de transpar�ncia
    public float clickedAlpha = 0.5f; // Valor de transpar�ncia ao clicar

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    public void ChangeTransparency()
    {
        Color newColor = button.image.color;
        newColor.a = clickedAlpha;
        button.image.color = newColor;
    }
}
