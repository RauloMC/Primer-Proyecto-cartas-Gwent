using UnityEngine;
using UnityEngine.EventSystems;

public class CardDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private CanvasGroup canvasGroup;
    public Transform originalParent;
    public Vector3 originalPosition;
    private CardComponent cardComponent; // Referencia al componente de la carta

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        cardComponent = GetComponent<CardComponent>(); // Obtener el componente CardComponent
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        originalPosition = transform.position; // Guardar la posición original
        transform.SetParent(transform.root);   // Poner la carta en el root para que no esté limitada por su contenedor
        canvasGroup.blocksRaycasts = false;    // Permitir que otros objetos detecten raycast
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position; // Actualizar la posición de la carta al arrastrar
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true; // Volver a habilitar los raycasts

        if (IsPointerOverDropZone(eventData))
        {
            var dropZone = eventData.pointerCurrentRaycast.gameObject.GetComponent<DropZone>();
            if (dropZone != null)
            {
                // Verifica si la carta puede ser colocada en la zona
                if (dropZone.CanPlaceCard(cardComponent.cardData))
                {
                    transform.SetParent(dropZone.transform); // Cambia el padre de la carta a la zona de juego
                    transform.localPosition = Vector3.zero; // Alinear la carta al centro de la zona

                    // Activar el efecto de la carta en la zona
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
                    // Si la carta no puede ser colocada en la zona, vuelve a su posición original
                    transform.position = originalPosition;
                    transform.SetParent(originalParent);
                }
            }
        }
        else
        {
            // Si no se suelta sobre una "DropZone", vuelve a su posición original
            transform.position = originalPosition;
            transform.SetParent(originalParent);
        }
    }

    private bool IsPointerOverDropZone(PointerEventData eventData)
    {
        return eventData.pointerCurrentRaycast.gameObject != null &&
               eventData.pointerCurrentRaycast.gameObject.CompareTag("DropZone");
    }
}
