using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public List<Card> cardsInHand = new List<Card>(); // Lista para almacenar las cartas en la mano
    public Transform handTransform; // Transform donde se ubicarán las cartas en la mano (puede ser un contenedor)

    // Método para agregar una carta a la mano
    public void AddCardToHand(Card card)
    {
        if (card == null)
        {
            Debug.LogError("Intentando agregar una carta nula a la mano.");
            return;
        }

        cardsInHand.Add(card);
        PlaceCardInHand(card);
    }

    // Método para colocar una carta en la mano visualmente
    private void PlaceCardInHand(Card card)
    {
        // Lógica para instanciar y colocar la carta en la posición deseada en la mano
        // Por ejemplo, podrías instanciar un prefab de carta y configurarlo aquí
    }

    // Método para devolver una carta a la mano
    public void ReturnCardToHand(Card card)
    {
        if (card == null)
        {
            Debug.LogError("Intentando devolver una carta nula a la mano.");
            return;
        }

        if (!cardsInHand.Contains(card))
        {
            Debug.LogError("La carta que se intenta devolver no está en la mano.");
            return;
        }

        // Aquí podrías implementar la lógica para visualizar la carta en la mano nuevamente
        // Por ejemplo, moverla al contenedor de cartas en la mano

        // Finalmente, asegúrate de actualizar la lista
        cardsInHand.Remove(card);
    }

    // Método para eliminar una carta de la mano (por ejemplo, cuando se juega una carta)
    public void RemoveCardFromHand(Card card)
    {
        if (card == null)
        {
            Debug.LogError("Intentando eliminar una carta nula de la mano.");
            return;
        }

        if (!cardsInHand.Contains(card))
        {
            Debug.LogError("La carta que se intenta eliminar no está en la mano.");
            return;
        }

        cardsInHand.Remove(card);

        // Lógica para eliminar visualmente la carta de la mano
        // Por ejemplo, destruir el prefab de la carta en la UI
    }
}
