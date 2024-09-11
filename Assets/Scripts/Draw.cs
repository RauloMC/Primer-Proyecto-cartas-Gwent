using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    public GameObject Hand; // Referencia al objeto de la mano del jugador
    public List<GameObject> CardsInHands; // Lista para almacenar las cartas en la mano
    public List<GameObject> Deck; // Lista de cartas en el mazo

    // Inicialización
    void Start()
    {
        CardsInHands = new List<GameObject>(); // Inicializa la lista de cartas en la mano
    }
    
    // Método que se llama cuando se hace clic para robar una carta
    public void OnClick()
    {
        // Verifica si la mano ya tiene el máximo de 12 cartas
        if (CardsInHands.Count >= 12)
        {
            Debug.Log("Hand is full. You cannot add more cards."); // Mensaje si la mano está llena
            return; // Sale del método si la mano está llena
        }

        // Verifica si hay cartas en el mazo
        if (Deck.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, Deck.Count); // Selecciona un índice aleatorio del mazo
            GameObject cardToDraw = Deck[randomIndex]; // Obtiene la carta en ese índice

            // Si hay espacio en la mano
            if (CardsInHands.Count < 12)
            {
                // Instancia la carta y la agrega a la mano
                GameObject newCard = Instantiate(cardToDraw, Hand.transform.position, Quaternion.identity, Hand.transform);
                CardsInHands.Add(newCard); // Añade la nueva carta a la lista de cartas en la mano

                // Elimina la carta del mazo
                Deck.RemoveAt(randomIndex);
            }       
        }
        else
        {
            Debug.Log("The Deck is empty."); // Mensaje si el mazo está vacío
        }   
    }
}
