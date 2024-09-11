using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpcionesMenu : MonoBehaviour
{
    public Slider volumeSlider; 
    private void Start()
    {
        // Inicializa el valor del slider con el volumen actual
        if (volumeSlider != null)
        {
            volumeSlider.value = AudioListener.volume;

            // Suscribirse al evento del slider
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
        else
        {
            //Debug.LogError("Slider de volumen no asignado en el Inspector.");
        }
    }

    // Función para ajustar el volumen
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume; // Ajusta el volumen global
    }

    private void OnDestroy()
    {
        // Verifica si volumeSlider no es null antes de eliminar el listener
        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.RemoveListener(SetVolume);
        }
    }


    public void VolverAlMenuPrincipal()
    {
        // Cargar la escena del menú principal
        SceneManager.LoadScene("Menu Principal");
    }
}
