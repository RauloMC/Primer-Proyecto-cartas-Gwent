using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCardHand : MonoBehaviour
{
    public bool isDragging = false; 
    public GameObject cardBeingDragged; 
    public Vector2 originalPosition; 
    private bool cardSelected = false; 

    void Update()
    {
        // Verificar si hay al menos un toque en la pantalla
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Obtiene el primer toque

            if (touch.phase == TouchPhase.Began)
            {
                HandleTouchBegin(touch); // Maneja el inicio del toque
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                HandleTouchEnd(touch); // Maneja el final del toque
            }
        }
    }

    // Método para manejar el inicio de un toque
    private void HandleTouchBegin(Touch touch)
    {
        Ray ray = Camera.main.ScreenPointToRay(touch.position); // Crea un rayo desde la cámara a la posición del toque
        RaycastHit hit;

        // Verifica si el rayo golpea algún objeto en la escena
        if (Physics.Raycast(ray, out hit))
        {
            // Verifica si el objeto golpeado tiene la etiqueta "Card"
            if (hit.collider.CompareTag("Card"))
            {
                cardSelected = true; // Marca que una carta ha sido seleccionada
                cardBeingDragged = hit.collider.gameObject; // Guarda la referencia a la carta seleccionada
                originalPosition = cardBeingDragged.transform.position; // Guarda la posición original de la carta
            }
        }
    }

    // Método para manejar el final de un toque
    private void HandleTouchEnd(Touch touch)
    {
        if (cardSelected)
        {
            Ray ray = Camera.main.ScreenPointToRay(touch.position); // Crea un rayo desde la cámara a la posición del toque
            RaycastHit hit;

            // Verifica si el rayo golpea algún objeto en la escena
            if (Physics.Raycast(ray, out hit))
            {
                // Mueve la carta seleccionada a la posición donde termina el toque
                cardBeingDragged.transform.position = hit.point;
            }
            cardSelected = false; // Marca que ninguna carta está seleccionada
        }
    }
}
