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
        cardList.Add(new Card(0, "Dumbledore", 8, "Headmaster of Hogwarts", Resources.Load<Sprite>("Dumbledore"), Faction.Gryffindor, CardType.Leader, AttackType.L, SpecialAbility.IncreaseRow, Unidad.Unidad));
        
        // Hero
        cardList.Add(new Card(1, "Harry Potter", 7, "The Boy Who Lived", Resources.Load<Sprite>("Harry"), Faction.Gryffindor, CardType.Hero, AttackType.MRS, SpecialAbility.RemoveHighestPower, Unidad.Unidad));
        cardList.Add(new Card(2, "Ron Weasley", 6, "Harry's loyal friend", Resources.Load<Sprite>("Ron"), Faction.Gryffindor, CardType.Hero, AttackType.MR, SpecialAbility.ClearRow, Unidad.Unidad));
        cardList.Add(new Card(3, "Hermione Granger", 6, "The Brightest Witch of Her Age", Resources.Load<Sprite>("Hermione"), Faction.Gryffindor, CardType.Hero, AttackType.MR, SpecialAbility.MultiplyAttack, Unidad.Unidad));
        cardList.Add(new Card(4, "McGonagall", 7, "Strict but caring Hogwarts professor", Resources.Load<Sprite>("Sprites/RedDeck/McGonagall"), Faction.Gryffindor, CardType.Hero, AttackType.MS, SpecialAbility.AveragePower, Unidad.Unidad));
        cardList.Add(new Card(5, "Sirius Black", 7, "Harry's godfather and Animagus", Resources.Load<Sprite>("Sprites/RedDeck/Black"), Faction.Gryffindor, CardType.Hero, AttackType.MS, SpecialAbility.DrawCard, Unidad.Unidad));
        
        // Silver
        cardList.Add(new Card(6, "Dobby", 5, "House-elf loyal to Harry Potter", Resources.Load<Sprite>("Sprites/RedDeck/Dobby"), Faction.Gryffindor, CardType.Silver, AttackType.M, SpecialAbility.CallWeather, Unidad.Unidad));
        cardList.Add(new Card(7, "Fred Weasley", 6, "Jokester twin brother", Resources.Load<Sprite>("Sprites/RedDeck/Fred"), Faction.Gryffindor, CardType.Silver, AttackType.R, SpecialAbility.RemoveHighestPower, Unidad.Unidad));
        cardList.Add(new Card(8, "George Weasley", 6, "Jokester twin brother", Resources.Load<Sprite>("Sprites/RedDeck/George"), Faction.Gryffindor, CardType.Silver, AttackType.R, SpecialAbility.RemoveLowestPower, Unidad.Unidad));
        cardList.Add(new Card(9, "Ginny Weasley", 6, "Harry's girlfriend and later wife", Resources.Load<Sprite>("Sprites/RedDeck/Ginny"), Faction.Gryffindor, CardType.Silver, AttackType.RS, SpecialAbility.DrawCard, Unidad.Unidad));
        cardList.Add(new Card(10, "Luna Lovegood", 6, "Unique and dreamy Hogwarts student", Resources.Load<Sprite>("Sprites/RedDeck/Luna"), Faction.Gryffindor, CardType.Silver, AttackType.RS, SpecialAbility.None, Unidad.Unidad));
        cardList.Add(new Card(11, "Neville Longbottom", 6, "Brave Gryffindor student", Resources.Load<Sprite>("Sprites/RedDeck/Neville"), Faction.Gryffindor, CardType.Silver, AttackType.M, SpecialAbility.None, Unidad.Unidad));
        cardList.Add(new Card(12, "Hagrid", 7, "Gentle giant and Hogwarts gamekeeper", Resources.Load<Sprite>("Sprites/RedDeck/Hagrid"), Faction.Gryffindor, CardType.Silver, AttackType.MS, SpecialAbility.IncreaseRow, Unidad.Unidad));
        cardList.Add(new Card(13, "Caballeros", 6, "Guardians of Hogwarts", Resources.Load<Sprite>("Sprites/RedDeck/Caballeros"), Faction.Gryffindor, CardType.Silver, AttackType.M, SpecialAbility.MultiplyAttack, Unidad.Unidad));
        cardList.Add(new Card(14, "Molly Weasley", 6, "Loving mother of the Weasley family", Resources.Load<Sprite>("Sprites/RedDeck/Molly"), Faction.Gryffindor, CardType.Silver, AttackType.MR, SpecialAbility.ClearRow, Unidad.Unidad));
        
        // Clearing
        cardList.Add(new Card(15, "Snape", 7, "Complex and enigmatic Hogwarts professor", Resources.Load<Sprite>("Sprites/RedDeck/Snape"), Faction.Gryffindor, CardType.Clearing, AttackType.DespejarClima, SpecialAbility.ClearingEffect, Unidad.Especial));
        cardList.Add(new Card(16, "Phoenix", 4, "Bird in flames", Resources.Load<Sprite>("Sprites/RedDeck/Phoenix"), Faction.Gryffindor, CardType.Clearing, AttackType.DespejarClima, SpecialAbility.ClearingEffect, Unidad.Especial));

        // Decoy
        cardList.Add(new Card(17, "Dama Gorda", 6, "Magical Marauder's Map", Resources.Load<Sprite>("Sprites/RedDeck/Dama"), Faction.Gryffindor, CardType.Decoy, AttackType.MRS, SpecialAbility.DecoyEffect, Unidad.Especial));
        cardList.Add(new Card(18, "Espejo de Oesed", 7, "Mirror that shows deepest desires", Resources.Load<Sprite>("Sprites/RedDeck/Espejo"), Faction.Gryffindor, CardType.Decoy, AttackType.MRS, SpecialAbility.DecoyEffect, Unidad.Especial));
        cardList.Add(new Card(19, "Black Lake", 4, "Great lake with magic creatures", Resources.Load<Sprite>("Sprites/RedDeck/Lake"), Faction.Gryffindor, CardType.Decoy, AttackType.MRS, SpecialAbility.DecoyEffect, Unidad.Especial));

        // Weather
        cardList.Add(new Card(20, "Trelawney", 6, "Divination professor with prophetic powers", Resources.Load<Sprite>("Sprites/RedDeck/Trelawney"), Faction.Gryffindor, CardType.Weather, AttackType.C, SpecialAbility.WeatherEffectRain, Unidad.Especial));
        cardList.Add(new Card(21, "Sirena", 5, "Magical creature from the lake", Resources.Load<Sprite>("Sprites/RedDeck/Siren"), Faction.Gryffindor, CardType.Weather, AttackType.C, SpecialAbility.WeatherEffectFog, Unidad.Especial));
        cardList.Add(new Card(22, "Invernadero", 5, "Magical plants and herbs", Resources.Load<Sprite>("Sprites/RedDeck/Invernadero"), Faction.Gryffindor, CardType.Weather, AttackType.C, SpecialAbility.WeatherEffectFrost, Unidad.Especial));

        // Increase
        cardList.Add(new Card(23, "Cáliz", 7, "Triwizard Tournament trophy", Resources.Load<Sprite>("Sprites/RedDeck/Goblet"), Faction.Gryffindor, CardType.Increase, AttackType.I, SpecialAbility.IncreaseEffect, Unidad.Especial));
        cardList.Add(new Card(24, "Snitch", 4, "Golden flying ball in Quidditch", Resources.Load<Sprite>("Sprites/RedDeck/Snitch"), Faction.Gryffindor, CardType.Increase, AttackType.I, SpecialAbility.IncreaseEffect, Unidad.Especial));

        //DeckNo.2
      
        // Líder
cardList.Add(new Card(25, "Voldemort", 7, "Most Feared", Resources.Load<Sprite>("Sprites/Greendeck/voldemort"), Faction.Slytherin, CardType.Leader, AttackType.L, SpecialAbility.MultiplyAttack, Unidad.Unidad));

// Héroes
cardList.Add(new Card(26, "Draco", 4, "Young Slytherin", Resources.Load<Sprite>("Sprites/Greendeck/draco"), Faction.Slytherin, CardType.Hero, AttackType.MR, SpecialAbility.ClearRow, Unidad.Unidad));
cardList.Add(new Card(27, "Snape", 4, "Complex and enigmatic Hogwarts professor", Resources.Load<Sprite>("Sprites/Greendeck/snape"), Faction.Slytherin, CardType.Hero, AttackType.MRS, SpecialAbility.AveragePower, Unidad.Unidad));
cardList.Add(new Card(28, "Lucius", 4, "Aristocratic Death Eater", Resources.Load<Sprite>("Sprites/Greendeck/lucius"), Faction.Slytherin, CardType.Hero, AttackType.MR, SpecialAbility.RemoveHighestPower, Unidad.Unidad));
cardList.Add(new Card(29, "Bellatrix", 4, "Crazed Death Eater", Resources.Load<Sprite>("Sprites/Greendeck/bellatrix"), Faction.Slytherin, CardType.Hero, AttackType.MRS, SpecialAbility.MultiplyAttack, Unidad.Unidad));
cardList.Add(new Card(30, "Narcissa", 3, "Protective Mother", Resources.Load<Sprite>("Sprites/Greendeck/narcissa"), Faction.Slytherin, CardType.Hero, AttackType.RS, SpecialAbility.IncreaseRow, Unidad.Unidad));

// Plata
cardList.Add(new Card(31, "Aragog", 2, "Giant Spider", Resources.Load<Sprite>("Sprites/Greendeck/aragog"), Faction.Slytherin, CardType.Silver, AttackType.M, SpecialAbility.CallWeather, Unidad.Unidad));
cardList.Add(new Card(32, "Nagini", 2, "Voldemort's Snake", Resources.Load<Sprite>("Sprites/Greendeck/nagini"), Faction.Slytherin, CardType.Silver, AttackType.M, SpecialAbility.None, Unidad.Unidad));
cardList.Add(new Card(33, "Dementor", 3, "Dark Creature", Resources.Load<Sprite>("Sprites/Greendeck/dementor"), Faction.Slytherin, CardType.Silver, AttackType.M, SpecialAbility.RemoveLowestPower, Unidad.Unidad));
cardList.Add(new Card(34, "Peter Petegrew", 3, "Betrayer", Resources.Load<Sprite>("Sprites/Greendeck/PeterPetegrew"), Faction.Slytherin, CardType.Silver, AttackType.R, SpecialAbility.DecoyEffect, Unidad.Unidad));
cardList.Add(new Card(35, "Tom Riddle", 4, "Young Voldemort", Resources.Load<Sprite>("Sprites/Greendeck/tom_riddle"), Faction.Slytherin, CardType.Silver, AttackType.S, SpecialAbility.RemoveHighestPower, Unidad.Unidad));
cardList.Add(new Card(36, "Barty Crouch", 3, "Barty Crouch", Resources.Load<Sprite>("Sprites/Greendeck/Crouch"), Faction.Slytherin, CardType.Silver, AttackType.MR, SpecialAbility.None, Unidad.Unidad));
cardList.Add(new Card(37, "Avada Kedavra", 2, "Dark Arts Spell", Resources.Load<Sprite>("Sprites/Greendeck/magic"), Faction.Slytherin, CardType.Decoy, AttackType.DevolverCarta, SpecialAbility.None, Unidad.Unidad));
cardList.Add(new Card(38, "Dolores Umbridge", 3, "Umbridge", Resources.Load<Sprite>("Sprites/Greendeck/umbridge"), Faction.Slytherin, CardType.Silver, AttackType.M, SpecialAbility.RemoveLowestPower, Unidad.Unidad));
cardList.Add(new Card(39, "Salazar Slytherin", 6, "Founder of Slytherin", Resources.Load<Sprite>("Sprites/Greendeck/Salazar"), Faction.Slytherin, CardType.Increase, AttackType.R, SpecialAbility.IncreaseEffect, Unidad.Unidad));

// Decoy
cardList.Add(new Card(40, "Caldero", 3, "Magical Potion", Resources.Load<Sprite>("Sprites/Greendeck/Cauldron"), Faction.Slytherin, CardType.Decoy, AttackType.MRS, SpecialAbility.DecoyEffect, Unidad.Especial));
cardList.Add(new Card(41, "Marca Tenebrosa", 3, "Dark Mark", Resources.Load<Sprite>("Sprites/Greendeck/mark"), Faction.Slytherin, CardType.Decoy, AttackType.MRS, SpecialAbility.DecoyEffect, Unidad.Especial));
cardList.Add(new Card(42, "Toilette de chicas", 3, "Hogwarts Student", Resources.Load<Sprite>("Sprites/Greendeck/Bathroom"), Faction.Slytherin, CardType.Silver, AttackType.MRS, SpecialAbility.DecoyEffect, Unidad.Especial));

// Weather
cardList.Add(new Card(43, "Camara de los scretos", 4, "Chamber of Secrets", Resources.Load<Sprite>("Sprites/Greendeck/Chamber"), Faction.Slytherin, CardType.Weather, AttackType.C, SpecialAbility.WeatherEffectRain, Unidad.Especial));
cardList.Add(new Card(44, "Mazmorras", 3, "Slytherin Dungeons", Resources.Load<Sprite>("Sprites/Greendeck/dungeons"), Faction.Slytherin, CardType.Weather, AttackType.C, SpecialAbility.WeatherEffectFog, Unidad.Especial));
cardList.Add(new Card(45, "Bosque Prohibido", 3, "Forbidden Forest", Resources.Load<Sprite>("Sprites/Greendeck/forest"), Faction.Slytherin, CardType.Weather, AttackType.C, SpecialAbility.WeatherEffectFrost, Unidad.Especial));

// Increase
cardList.Add(new Card(46, "Mapa", 3, "Magical Map", Resources.Load<Sprite>("Sprites/Greendeck/Map"), Faction.Slytherin, CardType.Weather, AttackType.I, SpecialAbility.IncreaseEffect, Unidad.Especial));
cardList.Add(new Card(47, "Copa de Slytherin", 5, "Slytherin Coup", Resources.Load<Sprite>("Sprites/Greendeck/SlytherinCoup"), Faction.Slytherin, CardType.Increase, AttackType.I, SpecialAbility.IncreaseEffect, Unidad.Especial));

// Clearing
cardList.Add(new Card(48, "Toilette de Slytherin", 4, "Chamber of Secrets", Resources.Load<Sprite>("Sprites/Greendeck/SlytherinBath"), Faction.Slytherin, CardType.Clearing, AttackType.DespejarClima, SpecialAbility.ClearingEffect, Unidad.Especial));
cardList.Add(new Card(59, "Basilisco", 1, "Magical Creature", Resources.Load<Sprite>("Sprites/Greendeck/snake"), Faction.Slytherin, CardType.Silver, AttackType.DespejarClima, SpecialAbility.None, Unidad.Especial));

    }  
}
