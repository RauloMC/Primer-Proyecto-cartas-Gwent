using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class PlayerSelectionManager : MonoBehaviour
{
    public TextMeshProUGUI playerCounterText; 
    public GameObject Nina; 
    public GameObject Lia; 
    public GameObject Rico; 
    public GameObject Leo; 
    public Button acceptButton; 

    private Queue<PlayerInfo> selectedPlayers = new Queue<PlayerInfo>(); // Cola para almacenar los jugadores seleccionados
    private const int maxPlayers = 2; // Número máximo de jugadores que se pueden seleccionar

    // Método para seleccionar o deseleccionar un jugador
    public void SelectPlayer(GameObject playerPanel)
    {
        PlayerInfo playerInfo = playerPanel.GetComponent<PlayerInfo>();

        if (selectedPlayers.Contains(playerInfo))
        {
            // Si el jugador ya está seleccionado, lo deselecciona
            selectedPlayers = new Queue<PlayerInfo>(selectedPlayers.Where(p => p != playerInfo));
            playerPanel.GetComponent<BlurryPlayer>().SetSelected(false); // Restaura la opacidad de la imagen
        }
        else
        {
            if (selectedPlayers.Count < maxPlayers)
            {
                // Si el jugador no está seleccionado y no se ha alcanzado el límite, lo selecciona
                selectedPlayers.Enqueue(playerInfo);
                playerPanel.GetComponent<BlurryPlayer>().SetSelected(true); // Opaca la imagen
            }
        }

        UpdatePlayerCounter(); // Actualiza el contador de jugadores seleccionados
    }

    // Método que se llama cuando se presiona el botón de aceptar
    public void OnAcceptButtonPressed()
    {
        if (selectedPlayers.Count == maxPlayers)
        {
            AssignPlayersToGame(); // Asigna los jugadores seleccionados al juego
            gameObject.SetActive(false); // Oculta el canvas de selección
        }
    }

    // Actualiza el texto del contador de jugadores y el estado del botón de aceptar
    private void UpdatePlayerCounter()
    {
        playerCounterText.text = selectedPlayers.Count + "/2";
        acceptButton.interactable = selectedPlayers.Count == maxPlayers;
    }

    // Asigna los jugadores seleccionados al GameManager
    private void AssignPlayersToGame()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null && selectedPlayers.Count == maxPlayers)
        {
            PlayerInfo[] playerArray = selectedPlayers.ToArray();
            gameManager.SetPlayers(playerArray[0], playerArray[1]); // Asigna los jugadores seleccionados
        }
    }
}
