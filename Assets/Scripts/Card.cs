using System;
using UnityEngine;

public enum Faction
{
    Gryffindor,
    Slytherin,
}

public enum Unidad{
    Unidad,
    Especial
}

public enum CardType
{
    Hero,
    Leader,
    Increase,
    Weather,
    Decoy,
    Clearing,
    Silver
}

public enum AttackType
{
    M, R, S, MR, MS, RS, MRS, C, L, I, DespejarClima, DevolverCarta
}

public enum SpecialAbility
{
    DecoyEffect,
    ClearingEffect,
    None,
    CallWeather,
    RemoveHighestPower,
    RemoveLowestPower,
    DrawCard,
    MultiplyAttack,
    ClearRow,
    AveragePower,

    WeatherEffectFog,
    WeatherEffectRain,
    WeatherEffectFrost,

    IncreaseEffect,
    IncreaseRow
}

[Serializable]
public class Card
{
    public int Id;
    public string CardName;
    public int Power;
    public string CardDescription;
    public Sprite ThisImage;
    public Faction CardFaction;
    public CardType Type;
    public AttackType Attack;
    public SpecialAbility Ability;
    public Unidad UnitType;
    // Constructor
    public Card(int id, string cardName, int power, string cardDescription, Sprite thisImage,
                Faction cardFaction, CardType type, AttackType attack, SpecialAbility ability, Unidad unidad)
    {
        Id = id;
        CardName = cardName;
        Power = power;
        CardDescription = cardDescription;
        ThisImage = thisImage;
        CardFaction = cardFaction;
        Type = type;
        Attack = attack;
        Ability = ability;
        UnitType = unidad;
    }
}
