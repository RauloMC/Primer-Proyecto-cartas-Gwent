using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDeck : MonoBehaviour, IPointerClickHandler
{
    public GameObject cardPrefab;
    public Transform cardZone;
    public int maxCardsToDraw = 10;
    public Player player; // Asume que player tiene una propiedad "Name" para identificar al jugador

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
            
            // Llena el mazo con cartas filtradas por facción según el jugador
            if (player.Name == "Player1")
            {
                // Jugador 1 solo toma cartas de Gryffindor
                deck = CardDataBase.cardList.FindAll(card => card.CardFaction == Faction.Gryffindor);
            }
            else if (player.Name == "Player2")
            {
                // Jugador 2 solo toma cartas de Slytherin
                deck = CardDataBase.cardList.FindAll(card => card.CardFaction == Faction.Slytherin);
            }
            
            // Mezclar el mazo
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
    }
}
