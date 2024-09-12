using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public string Name;
    public Sprite Photo;
    public TMP_Text nameText;
    public Image photoImage;

    public List<Card> hand = new List<Card>(); // La mano del jugador
    public List<Card> deck = new List<Card>(); // El mazo del jugador
    public int maxHandSize = 10; // Tamaño máximo de la mano
    public List<Card> selectedCardsForMulligan = new List<Card>();

    private Mulligan mulliganManager;

    private void Start()
    {
        mulliganManager = FindObjectOfType<Mulligan>();
    }

    public void AddCardToHand(Card card)
    {
        if (hand.Count < maxHandSize)
        {
            hand.Add(card);
            UpdateHandUI();
            //mulliganManager.ManageMulligan(); // Revisa el estado del mulligan cada vez que se añade una carta
        }
        else
        {
            Debug.Log("La mano está llena, no se puede añadir más cartas.");
        }
    }

    public void DrawInitialCards()
    {
        DrawCards(maxHandSize); // Roba las cartas iniciales
    }

    public void DrawCards(int number)
    {
        for (int i = 0; i < number; i++)
        {
            if (deck.Count > 0)
            {
                Card drawnCard = deck[Random.Range(0, deck.Count)];
                deck.Remove(drawnCard);
                AddCardToHand(drawnCard); // Añade la carta a la mano
            }
        }
    }

    private void UpdateHandUI()
    {
    }

    public void OnCardSelected(Card card)
    {
        if (selectedCardsForMulligan.Count < 2)
        {
            selectedCardsForMulligan.Add(card);
            // IDEAAAAA: Aquí se resalta la carta visualmente si es necesario
        }

        if (selectedCardsForMulligan.Count == 2)
        {
            Mulligan(selectedCardsForMulligan);
        }
    }

    public void Mulligan(List<Card> cardsToExchange)
    {
        // Devolver las cartas seleccionadas al mazo
        foreach (Card card in cardsToExchange)
        {
            hand.Remove(card);
            deck.Add(card);
        }

        // Mezclar el mazo después del mulligan
        ShuffleDeck();

        // Robar la misma cantidad de cartas que fueron intercambiadas
        DrawCards(cardsToExchange.Count);
    }

    private void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            Card temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    public void UpdatePanel()
    {
        if (nameText != null)
        {
            nameText.text = Name;
        }
        if (photoImage != null)
        {
            photoImage.sprite = Photo;
        }
    }

    public int GetHandCardCount()
    {
        return hand.Count;
    }
}
