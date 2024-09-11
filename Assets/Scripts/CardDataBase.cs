using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        // Leader
        cardList.Add(new Card(0, "Dumbledore", 5, 8, "Headmaster of Hogwarts", Resources.Load<Sprite>("Dumbledore"), Faction.Gryffindor, CardType.Leader, AttackType.L, SpecialAbility.IncreaseRow));
        
        // Hero
        cardList.Add(new Card(1, "Harry Potter", 4, 7, "The Boy Who Lived", Resources.Load<Sprite>("Harry"), Faction.Gryffindor, CardType.Hero, AttackType.MRS, SpecialAbility.RemoveHighestPower));
        cardList.Add(new Card(2, "Ron Weasley", 3, 6, "Harry's loyal friend", Resources.Load<Sprite>("Ron"), Faction.Gryffindor, CardType.Hero, AttackType.MR, SpecialAbility.ClearRow));
        cardList.Add(new Card(3, "Hermione Granger", 3, 6, "The Brightest Witch of Her Age", Resources.Load<Sprite>("Hermione"), Faction.Gryffindor, CardType.Hero, AttackType.MR, SpecialAbility.MultiplyAttack));
        cardList.Add(new Card(4, "McGonagall", 4, 7, "Strict but caring Hogwarts professor", Resources.Load<Sprite>("Sprites/RedDeck/McGonagall"), Faction.Gryffindor, CardType.Hero, AttackType.MS, SpecialAbility.AveragePower));
        cardList.Add(new Card(5, "Sirius Black", 4, 7, "Harry's godfather and Animagus", Resources.Load<Sprite>("Sprites/RedDeck/Black"), Faction.Gryffindor, CardType.Hero, AttackType.MS, SpecialAbility.DrawCard));
        
        // Silver
        cardList.Add(new Card(6, "Dobby", 2, 5, "House-elf loyal to Harry Potter", Resources.Load<Sprite>("Sprites/RedDeck/Dobby"), Faction.Gryffindor, CardType.Silver, AttackType.M, SpecialAbility.CallWeather));
        cardList.Add(new Card(7, "Fred Weasley", 3, 6, "Jokester twin brother", Resources.Load<Sprite>("Sprites/RedDeck/Fred"), Faction.Gryffindor, CardType.Silver, AttackType.R, SpecialAbility.RemoveHighestPower));
        cardList.Add(new Card(8, "George Weasley", 3, 6, "Jokester twin brother", Resources.Load<Sprite>("Sprites/RedDeck/George"), Faction.Gryffindor, CardType.Silver, AttackType.R, SpecialAbility.RemoveLowestPower));
        cardList.Add(new Card(9, "Ginny Weasley", 3, 6, "Harry's girlfriend and later wife", Resources.Load<Sprite>("Sprites/RedDeck/Ginny"), Faction.Gryffindor, CardType.Silver, AttackType.RS, SpecialAbility.DrawCard));
        cardList.Add(new Card(10, "Luna Lovegood", 3, 6, "Unique and dreamy Hogwarts student", Resources.Load<Sprite>("Sprites/RedDeck/Luna"), Faction.Gryffindor, CardType.Silver, AttackType.RS, SpecialAbility.None));
        cardList.Add(new Card(11, "Neville Longbottom", 3, 6, "Brave Gryffindor student", Resources.Load<Sprite>("Sprites/RedDeck/Neville"), Faction.Gryffindor, CardType.Silver, AttackType.M, SpecialAbility.None));
        cardList.Add(new Card(12, "Hagrid", 4, 7, "Gentle giant and Hogwarts gamekeeper", Resources.Load<Sprite>("Sprites/RedDeck/Hagrid"), Faction.Gryffindor, CardType.Silver, AttackType.MS, SpecialAbility.IncreaseRow));
        cardList.Add(new Card(13, "Caballeros", 3, 6, "Guardians of Hogwarts", Resources.Load<Sprite>("Sprites/RedDeck/Caballeros"), Faction.Gryffindor, CardType.Silver, AttackType.M, SpecialAbility.MultiplyAttack));
        cardList.Add(new Card(14, "Molly Weasley", 3, 6, "Loving mother of the Weasley family", Resources.Load<Sprite>("Sprites/RedDeck/Molly"), Faction.Gryffindor, CardType.Silver, AttackType.MR, SpecialAbility.ClearRow));
        //Clearing
        cardList.Add(new Card(15, "Snape", 4, 7, "Complex and enigmatic Hogwarts professor", Resources.Load<Sprite>("Sprites/RedDeck/Snape"), Faction.Gryffindor, CardType.Clearing, AttackType.DespejarClima, SpecialAbility.ClearingEffect));
        cardList.Add(new Card(16, "Phoenix", 3, 4, "Bird in flames", Resources.Load<Sprite>("Sprites/RedDeck/Phoenix"), Faction.Gryffindor, CardType.Clearing, AttackType.DespejarClima, SpecialAbility.ClearingEffect));

        // Decoy
        cardList.Add(new Card(17, "Dama Gorda", 3, 6, "Magical Marauder's Map", Resources.Load<Sprite>("Sprites/RedDeck/Dama"), Faction.Gryffindor, CardType.Decoy, AttackType.DevolverCarta, SpecialAbility.AveragePower));
        cardList.Add(new Card(18, "Espejo de Oesed", 4, 7, "Mirror that shows deepest desires", Resources.Load<Sprite>("Sprites/RedDeck/Espejo"), Faction.Gryffindor, CardType.Decoy, AttackType.DevolverCarta, SpecialAbility.IncreaseRow));
        cardList.Add(new Card(19, "Black Lake", 3, 4, "Great lake with magic creatures", Resources.Load<Sprite>("Sprites/RedDeck/Lake"), Faction.Gryffindor, CardType.Decoy, AttackType.DevolverCarta, SpecialAbility.DecoyEffect));

        // Weather
        cardList.Add(new Card(20, "Trelawney", 3, 6, "Divination professor with prophetic powers", Resources.Load<Sprite>("Sprites/RedDeck/Trelawney"), Faction.Gryffindor, CardType.Weather, AttackType.C, SpecialAbility.WeatherEffectRain));
        cardList.Add(new Card(21, "Sirena", 2, 5, "Magical creature from the lake", Resources.Load<Sprite>("Sprites/RedDeck/Siren"), Faction.Gryffindor, CardType.Weather, AttackType.C, SpecialAbility.WeatherEffectFog));
        cardList.Add(new Card(22, "Invernadero", 2, 5, "Magical plants and herbs", Resources.Load<Sprite>("Sprites/RedDeck/Invernadero"), Faction.Gryffindor, CardType.Weather, AttackType.C, SpecialAbility.WeatherEffectFrost));

        // Increase
        cardList.Add(new Card(23, "Cáliz", 4, 7, "Triwizard Tournament trophy", Resources.Load<Sprite>("Sprites/RedDeck/Goblet"), Faction.Gryffindor, CardType.Increase, AttackType.I, SpecialAbility.IncreaseEffect));
        cardList.Add(new Card(24, "Snitch", 1, 4, "Golden flying ball in Quidditch", Resources.Load<Sprite>("Sprites/RedDeck/Snitch"), Faction.Gryffindor, CardType.Increase, AttackType.I, SpecialAbility.IncreaseEffect));
    }  
}
