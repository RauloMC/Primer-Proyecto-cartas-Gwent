using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Jugar()
    {
        Debug.Log("Iniciar el juego");
        SceneManager.LoadScene("Juego Principal");
    }

    public void Opciones()
    {
        Debug.Log("Abrir opciones");
        SceneManager.LoadScene("Opciones");
    }

    public void Salir()
    {
        Debug.Log("Salir del juego");
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
