using System.Collections.Generic;

using UnityEngine;

public class Cementery : MonoBehaviour {
    

    List<Card> cardsInCementery = new List<Card>();

    public void AddCardToCementery(Card card)
    {
        if (card != null){
            cardsInCementery.Add(card);
        }
    }
}