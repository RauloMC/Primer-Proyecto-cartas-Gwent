using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;

    void Awake()
    {
        // Verifica si ya existe una instancia de MusicManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // No destruir este objeto al cambiar de escena
            audioSource = GetComponent<AudioSource>(); // Obtener el AudioSource
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Destruye la nueva instancia si ya existe una
        }
    }

    void OnEnable()
    {
        // Registrar el evento para escuchar los cambios de escena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Quitar el registro del evento para evitar errores cuando el objeto sea destruido
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Detener la música si es la escena del juego principal
        if (scene.name == "Juego Principal") // Reemplaza "Juego Principal" con el nombre exacto de la escena del juego
        {
            audioSource.Stop();
        }
        else
        {
            // Reproducir la música si no es la escena del juego principal
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
