using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDeck : MonoBehaviour, IPointerClickHandler
{
    public GameObject cardPrefab;
    public Transform cardZone;
    public int maxCardsToDraw = 10;
    public Player player;

    private List<Card> deck = new List<Card>();
    private int cardsDrawn = 0;
    public bool canPlayCards = false;

    void Start()
    {
        ResetDeck();
    }

    void ResetDeck()
    {
        if (CardDataBase.cardList != null && CardDataBase.cardList.Count > 0)
        {
            Debug.Log("Card list is initialized with " + CardDataBase.cardList.Count + " cards.");

            if (player.Name == "Player1")
            {
                deck = CardDataBase.cardList.FindAll(card => card.CardFaction == Faction.Gryffindor);
            }
            else if (player.Name == "Player2")
            {
                deck = CardDataBase.cardList.FindAll(card => card.CardFaction == Faction.Slytherin);
            }

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
        if (canPlayCards && cardsDrawn < maxCardsToDraw)
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
        else if (!canPlayCards)
        {
            Debug.Log("No se pueden jugar cartas en este turno.");
        }
        else
        {
            Debug.Log("Límite de cartas dibujadas alcanzado.");
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

        GameObject cardObject = Instantiate(cardPrefab, cardZone);

        CardComponent cardComponent = cardObject.GetComponent<CardComponent>();
        if (cardComponent != null)
        {
            cardComponent.Initialize(card);
        }
        else
        {
            Debug.LogError("CardComponent no encontrado en el prefab.");
        }

        CanvasGroup canvasGroup = cardObject.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = cardObject.AddComponent<CanvasGroup>();
        }

        CardDragHandler dragHandler = cardObject.GetComponent<CardDragHandler>();
        if (dragHandler == null)
        {
            dragHandler = cardObject.AddComponent<CardDragHandler>();
        }
    }
}
