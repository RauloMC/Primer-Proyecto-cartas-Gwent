using UnityEngine;
using UnityEngine.UI;

public class Mulligan : MonoBehaviour
{
    public GameObject mulliganPanel; 
    public Player player; 
    public Button YesButton; 
    public Button NoButton; 

    private void Start()
    {
        HideMulliganPanel();
    }

    public void ManageMulligan()
    {
        if (player != null)
        {
            Debug.Log("Cartas en la mano: " + player.GetHandCardCount());
            if (player.GetHandCardCount() == 10)
            {
                ShowMulliganPanel();
            }
            else
            {
                HideMulliganPanel();
            }
        }
        else
        {
            Debug.LogError("El jugador no está asignado.");
        }
    }

    public void ShowMulliganPanel()
    {
        mulliganPanel.SetActive(true);
    }

    public void HideMulliganPanel()
    {
        mulliganPanel.SetActive(false);
    }

    public void OnMulliganYes()
    {
        player.selectedCardsForMulligan.Clear(); // Limpia las cartas seleccionadas previamente
        HideMulliganPanel();
        // Permitir seleccionar cartas para el mulligan
        EnableCardSelectionForMulligan();
    }

    public void EnableCardSelectionForMulligan()
    {
    }

    public void OnMulliganNo()
    {
        HideMulliganPanel();
    }
}
