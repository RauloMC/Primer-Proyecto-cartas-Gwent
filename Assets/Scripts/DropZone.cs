using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public AttackType zoneType; 

    public void OnDrop(PointerEventData eventData)
    {
        CardDragHandler draggableCard = eventData.pointerDrag.GetComponent<CardDragHandler>();
        if (draggableCard != null)
        {
            CardComponent cardComponent = draggableCard.GetComponent<CardComponent>();
            if (cardComponent != null && CanPlaceCard(cardComponent.cardData))
            {
                // Si la carta puede ser colocada, se pone en esta zona
                draggableCard.transform.SetParent(transform);
                draggableCard.transform.localPosition = Vector3.zero;

                // Activar el efecto de la carta
                Effect effectManager = FindObjectOfType<Effect>(); // Encontrar el objeto Effect en la escena
                if (effectManager != null)
                {
                    effectManager.ApplyEffect(cardComponent.cardData);
                }
                else
                {
                    Debug.LogWarning("No se encontró un objeto Effect en la escena.");
                }
            }
            else
            {
                // Si la carta no puede ser colocada, vuelve a su posición original
                draggableCard.transform.position = draggableCard.originalPosition;
                draggableCard.transform.SetParent(draggableCard.originalParent);
            }
        }
    }

    // Método para verificar si la carta puede ser colocada en esta zona
   public bool CanPlaceCard(Card card)
    {
        // Verifica si el tipo de ataque de la carta es compatible con esta zona
        if (card.Attack == zoneType)
        {
            return true;
        }
        
        switch (card.Attack)
        {
            case AttackType.M:
                return zoneType == AttackType.M;
            case AttackType.S:
                return zoneType == AttackType.S;
            case AttackType.R:
                return zoneType == AttackType.R;  
            case AttackType.MR:
                return zoneType == AttackType.M || zoneType == AttackType.R;
            case AttackType.MS:
                return zoneType == AttackType.M || zoneType == AttackType.S;
            case AttackType.RS:
                return zoneType == AttackType.R || zoneType == AttackType.S;
            case AttackType.MRS:
                return zoneType == AttackType.M || zoneType == AttackType.R || zoneType == AttackType.S;
            case AttackType.C:
                return zoneType == AttackType.C;
            case AttackType.I:
                return zoneType == AttackType.I;
            case AttackType.L:
                return zoneType == AttackType.L;
            default:
                return false;
        }
    }
}
