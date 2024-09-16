using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    private List<CardComponent> cardsInZone = new List<CardComponent>();

    // Añade una carta a la lista de cartas en la zona
    public void AddCard(CardComponent cardComponent)
    {
        if (!cardsInZone.Contains(cardComponent))
        {
            cardsInZone.Add(cardComponent);
            Debug.Log("Card added to zone: " + cardComponent.cardData.CardName);
        }
    }

    // Elimina una carta de la lista de cartas en la zona
    public void RemoveCard(CardComponent cardComponent)
    {
        if (cardsInZone.Contains(cardComponent))
        {
            cardsInZone.Remove(cardComponent);
            Debug.Log("Card removed from zone: " + cardComponent.cardData.CardName);
        }
    }

    // Devuelve una lista de todas las cartas en la zona
    public List<CardComponent> GetCardsInZone()
    {
        return new List<CardComponent>(cardsInZone);
    }
}