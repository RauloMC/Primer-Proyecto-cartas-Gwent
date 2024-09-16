using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public Player player;
    public List<CardComponent> cardsInZone = new List<CardComponent>();
    public Zone zone; // Referencia a la clase Zone
    public AttackType zoneType; // Tipo de zona asociado a este DropZone (M, R, S, etc.)

    private void Start()
    {
        // Asignar la referencia a la clase Zone
        zone = GetComponent<Zone>();
        if (zone == null)
        {
            Debug.LogError("No se encontró un componente Zone en el DropZone.");
        }
    }

    public void AddCardToZone(CardComponent cardComponent)
    {
        if (cardComponent != null)
        {
            cardsInZone.Add(cardComponent); // Añadir la carta a la lista
            Debug.Log("Carta añadida a la zona: " + cardComponent.cardData.CardName);
            Debug.Log("Cantidad de cartas en la zona: " + cardsInZone.Count);
        }
        else
        {
            Debug.LogError("Intentaste añadir una carta nula.");
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop Triggered");

        CardDragHandler draggableCard = eventData.pointerDrag.GetComponent<CardDragHandler>();
        if (draggableCard != null)
        {
            CardComponent cardComponent = draggableCard.GetComponent<CardComponent>();
            AddCardToZone(cardComponent);

            if (cardComponent != null)
            {
                if (CanPlaceCard(cardComponent))
                {
                    draggableCard.transform.SetParent(transform);
                    draggableCard.transform.localPosition = Vector3.zero;

                    Effect effectManager = FindObjectOfType<Effect>();
                    if (effectManager != null)
                    {
                        effectManager.ApplyEffect(cardComponent.cardData, this); // Pasar DropZone como parámetro
                    }
                    else
                    {
                        Debug.LogWarning("No se encontró un objeto Effect en la escena.");
                    }

                    if (zone != null)
                    {
                        zone.AddCard(cardComponent); // Añade la carta a la zona usando el método de la clase Zone
                    }
                }
                else
                {
                    Debug.LogWarning("No se puede colocar la carta en esta zona.");
                    draggableCard.transform.position = draggableCard.originalPosition;
                    draggableCard.transform.SetParent(draggableCard.originalParent);
                }
            }
        }
    }

    // Método para verificar si la carta puede ser colocada en esta zona
    public bool CanPlaceCard(CardComponent cardComponent)
    {
        // Verifica si el tipo de ataque de la carta es compatible con esta zona
        return cardComponent.cardData.Attack == zoneType ||
               (cardComponent.cardData.Attack == AttackType.MR && (zoneType == AttackType.M || zoneType == AttackType.R)) ||
               (cardComponent.cardData.Attack == AttackType.MS && (zoneType == AttackType.M || zoneType == AttackType.S)) ||
               (cardComponent.cardData.Attack == AttackType.RS && (zoneType == AttackType.R || zoneType == AttackType.S)) ||
               (cardComponent.cardData.Attack == AttackType.MRS && (zoneType == AttackType.M || zoneType == AttackType.R || zoneType == AttackType.S));
    }

    public void RemoveCard(CardComponent cardComponent)
    {
        if (zone != null)
        {
            zone.RemoveCard(cardComponent); // Remueve la carta de la zona usando el método de la clase Zone
        }

        // También elimina la carta de la lista interna
        cardsInZone.Remove(cardComponent);
    }

    public List<CardComponent> GetAllCardsInZone()
    {
        return new List<CardComponent>(cardsInZone); // Devuelve una lista de CardComponent
    }

    public void OnCardRemoved(CardComponent cardComponent)
    {
        RemoveCard(cardComponent);
        // Aquí podrías manejar otras actualizaciones relacionadas con el retiro de cartas.
    }
}
