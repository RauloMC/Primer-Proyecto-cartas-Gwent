using UnityEngine;
using UnityEngine.UI;

public class BlurryPlayer : MonoBehaviour
{
    // La imagen del jugador que se va a opacar
    public Image playerImage;

    // Opacidad normal (completa)
    private float defaultOpacity = 1f;

    // Opacidad cuando el jugador es seleccionado
    private float selectedOpacity = 0.5f;

    // Método para establecer la opacidad de la imagen
    public void SetSelected(bool isSelected)
    {
        if (playerImage != null)
        {
            // Obtiene el color actual de la imagen
            Color color = playerImage.color;

            // Cambia la opacidad según la selección
            color.a = isSelected ? selectedOpacity : defaultOpacity;

            // Asigna el color modificado a la imagen
            playerImage.color = color;
        }
        else
        {
            Debug.LogWarning("Player Image is not assigned.");
        }
    }
}
