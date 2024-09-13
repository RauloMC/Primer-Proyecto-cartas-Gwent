using UnityEngine;
using UnityEngine.EventSystems;

public class CardClickHandler : MonoBehaviour, IPointerClickHandler{

    // Variables asignadas en el Inspector
    public Sprite cardImage;      
    public string cardName;        
    public int cardCost;            
    public string cardDescription;  

    private CardDetailDisplay cardDetailDisplay;  // Referencia al componente que muestra detalles de la carta

    private void Start()
    {
        // Buscar el componente CardDetailDisplay en la escena
        cardDetailDisplay = FindObjectOfType<CardDetailDisplay>();
        if (cardDetailDisplay == null)
        {
            Debug.LogError("CardDetailDisplay no encontrado en la escena.");
        }
    }

    // Método llamado cuando se hace clic en la carta
    public void OnPointerClick(PointerEventData eventData)
    {
        if (cardDetailDisplay != null)
        {
            // Mostrar los detalles de la carta
            cardDetailDisplay.ShowCardDetails(cardImage, cardName, cardCost, cardDescription);
        }
    }
}
