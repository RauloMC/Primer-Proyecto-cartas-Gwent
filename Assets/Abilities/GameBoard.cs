using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public List<Card>[] rows; // Lista de listas para las filas
    public string currentWeather; // Para almacenar el estado del clima

    // Inicialización del tablero
    private void Start()
    {
        rows = new List<Card>[3]; // Ejemplo para 3 filas, ajusta según tus necesidades
        for (int i = 0; i < rows.Length; i++)
        {
            rows[i] = new List<Card>();
        }
    }

    // Método para obtener las cartas en una fila específica
    public List<Card> GetCardsInRow(int rowIndex)
    {
        if (rowIndex >= 0 && rowIndex < rows.Length)
        {
            return rows[rowIndex];
        }
        return new List<Card>();
    }

    // Método para cambiar el clima
    public void ChangeWeather(string weatherCondition)
    {
        currentWeather = weatherCondition;
        // Implementa la lógica para cambiar el clima aquí
    }

    // Elimina la carta con más poder del campo (propio o del rival)
    public void RemoveHighestPowerCard()
    {
        Card highestCard = null;
        foreach (var row in rows)
        {
            foreach (Card card in row)
            {
                if (highestCard == null || card.Power > highestCard.Power)
                {
                    highestCard = card;
                }
            }
        }
        if (highestCard != null)
        {
            foreach (var row in rows)
            {
                row.Remove(highestCard);
            }
        }
    }

    // Aumenta el poder de todas las cartas en una fila específica
    public void IncreaseRowPower(int rowIndex, int increaseAmount)
    {
        if (rowIndex >= 0 && rowIndex < rows.Length)
        {
            foreach (Card card in rows[rowIndex])
            {
                card.Power += increaseAmount;
            }
        }
    }

    // Multiplica el ataque de una carta por el número de cartas iguales en el campo
    public void MultiplyCardPower(Card card)
    {
        int count = 0;
        foreach (var row in rows)
        {
            foreach (Card c in row)
            {
                if (c.CardName == card.CardName)
                {
                    count++;
                }
            }
        }
        card.Power *= count;
    }

    // Robar una carta (ejemplo simple)
    public Card DrawCard()
    {
        // Implementa la lógica para robar una carta del mazo
        return null; // Cambia esto para devolver una carta real
    }

    // Limpia la fila con menos unidades
    public void ClearRowWithFewestCards()
    {
        int minCards = int.MaxValue;
        int rowToClear = -1;

        for (int i = 0; i < rows.Length; i++)
        {
            if (rows[i].Count < minCards)
            {
                minCards = rows[i].Count;
                rowToClear = i;
            }
        }
        if (rowToClear != -1)
        {
            rows[rowToClear].Clear();
        }
    }

    // Calcula el promedio de poder en todas las cartas en el campo y ajusta
    public void NormalizePowerToAverage()
    {
        List<Card> allCards = new List<Card>();
        foreach (var row in rows)
        {
            allCards.AddRange(row);
        }
        if (allCards.Count == 0) return;

        float averagePower = 0;
        foreach (Card card in allCards)
        {
            averagePower += card.Power;
        }
        averagePower /= allCards.Count;

        foreach (Card card in allCards)
        {
            card.Power = Mathf.RoundToInt(averagePower);
        }
    }

    // Cambia el clima en el campo
    public void SetWeatherCondition(string newWeather)
    {
        ChangeWeather(newWeather);
    }

    // Elimina la carta con menos poder del rival
    public void RemoveLowestPowerCard(bool isPlayerSide)
    {
        int minPower = int.MaxValue;
        Card lowestCard = null;

        foreach (var row in rows)
        {
            foreach (Card card in row)
            {
                if (isPlayerSide) // Suponiendo que hay una manera de distinguir el lado del jugador
                {
                    // Implementa lógica para distinguir cartas del lado del jugador
                }
                else
                {
                    if (card.Power < minPower)
                    {
                        minPower = card.Power;
                        lowestCard = card;
                    }
                }
            }
        }
        if (lowestCard != null)
        {
            foreach (var row in rows)
            {
                row.Remove(lowestCard);
            }
        }
    }
}
