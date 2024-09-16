using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Effect : MonoBehaviour
{
    DropZoneManager dropZoneManager;

    void Start()
    {
        dropZoneManager = FindObjectOfType<DropZoneManager>();
    }

    public void ApplyEffect(Card card, DropZone dropZone)
    {
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
                ApplyRemoveHighestPower(card, dropZone);
                break;
            case SpecialAbility.RemoveLowestPower:
                ApplyRemoveLowestPower(card, dropZone);
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

    private void ApplyRemoveHighestPower(Card card, DropZone dropZone)
    {
        Debug.Log("Aplicando efecto de RemoveHighestPower: " + card.CardName);
        // Llama al método para eliminar la carta con el mayor poder en la DropZone
        if (dropZone != null)
        {
            List<CardComponent> cardsInZone = dropZone.GetAllCardsInZone();
            if (cardsInZone.Count > 0)
            {
                CardComponent highestPowerCard = cardsInZone.OrderByDescending(c => c.cardData.Power).FirstOrDefault();
                if (highestPowerCard != null)
                {
                    dropZone.RemoveCard(highestPowerCard);
                }
            }
        }
    }

    private void ApplyRemoveLowestPower(Card card, DropZone dropZone)
    {
        Debug.Log("Aplicando efecto de RemoveLowestPower: " + card.CardName);
        // Llama al método para eliminar la carta con el menor poder en la DropZone
        if (dropZone != null)
        {
            List<CardComponent> cardsInZone = dropZone.GetAllCardsInZone();
            if (cardsInZone.Count > 0)
            {
                CardComponent lowestPowerCard = cardsInZone.OrderBy(c => c.cardData.Power).FirstOrDefault();
                if (lowestPowerCard != null)
                {
                    dropZone.RemoveCard(lowestPowerCard);
                }
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
