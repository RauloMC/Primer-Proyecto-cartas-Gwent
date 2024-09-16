using System.Collections.Generic;

public class Cementery{
    List<Card> cardsInCementery = new List<Card>();

    public void AddCardToCementery(Card card)
    {
        if (card != null){
            cardsInCementery.Add(card);
        }
    }
}