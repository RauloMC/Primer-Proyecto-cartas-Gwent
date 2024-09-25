using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

public class Effect : MonoBehaviour
{
    DropZoneManager dropZoneManager;

    void Start()
    {
        dropZoneManager = FindObjectOfType<DropZoneManager>();
    }

    public void ApplyEffect(Card card, DropZone dropZone)
    {
        Player opponent = dropZone.opponent;
        switch (card.Ability)
        {
            case SpecialAbility.DecoyEffect:
                ApplyDecoyEffect(card);
                break;
            case SpecialAbility.ClearingEffect:
                ApplyClearingEffect(card);
                break;
            case SpecialAbility.CallWeather:
                ApplyCallWeather(card);
                break;
            case SpecialAbility.RemoveHighestPower:
                ApplyRemoveHighestPower(card, opponent);
                break;
            case SpecialAbility.RemoveLowestPower:
                ApplyRemoveLowestPower(card, opponent);
                break;
            case SpecialAbility.DrawCard:
                ApplyDrawCard(card);
                break;
            case SpecialAbility.MultiplyAttack:
                ApplyMultiplyAttack(card);
                break;
            case SpecialAbility.ClearRow:
                ApplyClearRow(card);
                break;
            case SpecialAbility.AveragePower:
                ApplyAveragePower(card);
                break;
            case SpecialAbility.WeatherEffectFog:
                ApplyWeatherEffectFog(card);
                break;
            case SpecialAbility.WeatherEffectRain:
                ApplyWeatherEffectRain(card);
                break;
            case SpecialAbility.WeatherEffectFrost:
                ApplyWeatherEffectFrost(card);
                break;
            case SpecialAbility.IncreaseEffect:
                ApplyIncreaseEffect(card);
                break;
            case SpecialAbility.IncreaseRow:
                ApplyIncreaseRow(card);
                break;
            case SpecialAbility.None:
                ApplyNone(card);
                break;
            default:
                Debug.LogWarning("No hay efecto");
                break;
        }
    }

    private void ApplyNone(Card card) { }

    private void ApplyDecoyEffect(Card card) { }

    private void ApplyClearingEffect(Card card)
    {
        Debug.Log("Aplicando efecto de Clearing: " + card.CardName);
    }

    private void ApplyCallWeather(Card card)
    {
        Debug.Log("Aplicando efecto de CallWeather: " + card.CardName);
    }

private void ApplyRemoveHighestPower(Card card, Player currentPlayer)
{
    Debug.Log("Aplicando efecto de RemoveHighestPower: " + card.CardName);

    // Obtén al oponente usando el método de la clase Player
    Player opponent = currentPlayer.GetOpponentBasedOnCardFaction(card);

    Debug.Log("Current Player: " + currentPlayer.name);
    if(currentPlayer.name == "player1"){opponent.name = "player2";}
    Debug.Log("Opponent Player: " + opponent.name);

    // Faction currentPlayerFaction = currentPlayer.faction; // Supongo que tienes una propiedad para la facción del jugador

    // Verifica si las zonas del oponente se obtienen correctamente
    List<DropZone> opponentZones = GameManager.Instance.playerDropZones[opponent];
    if (opponentZones == null || opponentZones.Count == 0)
    {
        return;
    }

    List<CardComponent> allOpponentCards = new List<CardComponent>();

    // Recorre todas las zonas del oponente para obtener todas las cartas
    foreach (DropZone zone in opponentZones)
    {
        var cardsInZone = zone.GetAllCardsInZone();
        Debug.Log($"Cartas en la zona {zone.name}: {cardsInZone.Count}");
        allOpponentCards.AddRange(cardsInZone);
    }

    // Filtra las cartas por la facción opuesta
    List<CardComponent> opponentFactionCards = allOpponentCards
        .Where(c => c.cardData.CardFaction != currentPlayer.faction)
        .ToList();

    if (opponentFactionCards.Count > 0)
    {
        // Busca la carta con mayor poder
        CardComponent highestPowerCard = opponentFactionCards.OrderByDescending(c => c.cardData.Power).FirstOrDefault();
        //if (highestPowerCard != null)
        {
            Debug.Log($"Carta con mayor poder encontrada: {highestPowerCard.cardData.CardName}, Poder: {highestPowerCard.cardData.Power}");

            DropZone originalZone = highestPowerCard.transform.parent.GetComponent<DropZone>();
            originalZone.RemoveCard(highestPowerCard);
            opponent.cementery.AddCardToCementery(highestPowerCard.cardData);
            Debug.Log("La carta removida es esta: " + highestPowerCard.cardData.CardName);
        }
    }
}

private void ApplyRemoveLowestPower(Card card, Player currentPlayer)
{
    Debug.Log("Aplicando efecto de RemoveLowestPower: " + card.CardName);

    // Obtén al oponente usando el método de la clase Player
    Player opponent = currentPlayer.GetOpponentBasedOnCardFaction(card);

    Debug.Log("Current Player: " + currentPlayer.name);
    if(currentPlayer.name == "player1"){opponent.name = "player2";}
    Debug.Log("Opponent Player: " + opponent.name);

    Faction currentPlayerFaction = currentPlayer.faction;

    // Verifica si las zonas del oponente se obtienen correctamente
    List<DropZone> opponentZones = GameManager.Instance.playerDropZones[opponent];
    if (opponentZones == null || opponentZones.Count == 0)
    {
        return;
    }

    List<CardComponent> allOpponentCards = new List<CardComponent>();

    // Recorre todas las zonas del oponente para obtener todas las cartas
    foreach (DropZone zone in opponentZones)
    {
        var cardsInZone = zone.GetAllCardsInZone();
        Debug.Log($"Cartas en la zona {zone.name}: {cardsInZone.Count}");
        allOpponentCards.AddRange(cardsInZone);
    }

    // Filtra las cartas por la facción opuesta
    List<CardComponent> opponentFactionCards = allOpponentCards
        .Where(c => c.cardData.CardFaction != currentPlayerFaction)
        .ToList();

    if (opponentFactionCards.Count > 0)
    {
        // Busca la carta con menor poder
        CardComponent lowestPowerCard = opponentFactionCards.OrderBy(c => c.cardData.Power).FirstOrDefault();
       // if (lowestPowerCard != null)
        {
            Debug.Log($"Carta con menor poder encontrada: {lowestPowerCard.cardData.CardName}, Poder: {lowestPowerCard.cardData.Power}");
            DropZone originalZone = lowestPowerCard.transform.parent.GetComponent<DropZone>();
            originalZone.RemoveCard(lowestPowerCard);
            opponent.cementery.AddCardToCementery(lowestPowerCard.cardData);
            Debug.Log("La carta removida es esta: " + lowestPowerCard.cardData.CardName);
        }
    }
}





    private void ApplyDrawCard(Card card)
    {
        Debug.Log("Aplicando efecto de DrawCard: " + card.CardName);
    }

    private void ApplyMultiplyAttack(Card card)
    {
        Debug.Log("Aplicando efecto de MultiplyAttack: " + card.CardName);
    }

    private void ApplyClearRow(Card card)
    {
        Debug.Log("Aplicando efecto de ClearRow: " + card.CardName);
    }

    private void ApplyAveragePower(Card card)
    {
        Debug.Log("Aplicando efecto de AveragePower: " + card.CardName);
    }

    private void ApplyWeatherEffectFog(Card card)
    {
        Debug.Log("Aplicando efecto de WeatherEffectFog: " + card.CardName);
    }

    private void ApplyWeatherEffectRain(Card card)
    {
        Debug.Log("Aplicando efecto de WeatherEffectRain: " + card.CardName);
    }

    private void ApplyWeatherEffectFrost(Card card)
    {
        Debug.Log("Aplicando efecto de WeatherEffectFrost: " + card.CardName);
    }

    private void ApplyIncreaseEffect(Card card)
    {
        Debug.Log("Aplicando efecto de IncreaseEffect: " + card.CardName);
    }

    private void ApplyIncreaseRow(Card card)
    {
        Debug.Log("Aplicando efecto de IncreaseRow: " + card.CardName);
    }
}
