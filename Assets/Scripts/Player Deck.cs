using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PlayerDeck : MonoBehaviour, IPointerClickHandler
{
    public GameObject cardPrefab; 
    public Transform cardZone;  
    public int maxCardsToDraw = 10;  
    public Player player; 

    private List<Card> deck = new List<Card>();
    private int cardsDrawn = 0;  
    void Start()
    {
        ResetDeck();
    }
    

    void ResetDeck()
{
    // Asegúrate de que la base de datos de cartas esté inicializada
    if (CardDataBase.cardList != null && CardDataBase.cardList.Count > 0)
    {
        Debug.Log("Card list is initialized with " + CardDataBase.cardList.Count + " cards.");

        // Crear un conjunto para almacenar las cartas únicas
        HashSet<Card> uniqueCards = new HashSet<Card>();

        // Llenar el mazo con cartas únicas
        while (uniqueCards.Count < 25)
        {
            Card cardToAdd = CardDataBase.cardList[Random.Range(0, CardDataBase.cardList.Count)];
            if (cardToAdd != null)
            {
                uniqueCards.Add(cardToAdd);
            }
        }

        // Convertir el conjunto a una lista y asignarla al mazo
        deck = new List<Card>(uniqueCards);

        ShuffleDeck();
    }
    else
    {
        Debug.LogError("CardDataBase.cardList is null or empty.");
    }
}


    void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            Card temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (cardsDrawn < maxCardsToDraw)
        {
            if (deck.Count > 0)
            {
                Card card = deck[0];
                deck.RemoveAt(0);

                if (card != null)
                {
                    PlaceCardInZone(card);
                    cardsDrawn++;
                }
                else
                {
                    Debug.LogError("Tried to draw a card, but the card is null.");
                }
            }
            else
            {
                Debug.LogError("No more cards in the deck.");
            }
        }
        else
        {
            Debug.Log("Card draw limit reached.");
        }
    }

    void PlaceCardInZone(Card card)
    {
        if (cardZone == null)
        {
            Debug.LogError("cardZone no está asignado en el Inspector.");
            return;
        }

        if (card == null)
        {
            Debug.LogError("La carta es nula.");
            return;
        }

        if (cardPrefab == null)
        {
            Debug.LogError("cardPrefab no está asignado en el Inspector.");
            return;
        }

        // Instancia el prefab de la carta
        GameObject cardObject = Instantiate(cardPrefab, cardZone);
        
        // Configura el componente CardComponent del prefab con los datos de la carta
        CardComponent cardComponent = cardObject.GetComponent<CardComponent>();
        if (cardComponent != null)
        {
            cardComponent.Initialize(card);
        }
        else
        {
            Debug.LogError("CardComponent no encontrado en el prefab.");
        }

        // Configura el componente CanvasGroup para la gestión de raycast y transparencia
        CanvasGroup canvasGroup = cardObject.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = cardObject.AddComponent<CanvasGroup>();
        }

        // Configura el componente CardDragHandler
        CardDragHandler dragHandler = cardObject.GetComponent<CardDragHandler>();
        if (dragHandler == null)
        {
            dragHandler = cardObject.AddComponent<CardDragHandler>();
        }

    // Instanciar el prefab de la carta en el contenedor de la mano
    // Inicializar los datos de la carta
    cardComponent.Initialize(card);
    }
}
