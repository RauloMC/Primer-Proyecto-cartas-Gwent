using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Draw : MonoBehaviour
{
    public GameObject Hand;
    public List<GameObject> CardsInHands;
    public List<GameObject> Deck;

    // Start is called before the first frame update
    void Start()
    {
        CardsInHands = new List<GameObject>();
    }
    
    public void OnClick()

    {
         if(CardsInHands.Count >= 12)
        {
            Debug.Log("Hand is full. you cannot add more cards.");
        }

        if(Deck.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, Deck.Count);
            GameObject cardToDraw = Deck[randomIndex];

            if(CardsInHands.Count<12)
            {
                 GameObject newCard = Instantiate(cardToDraw, Hand.transform.position, Quaternion.identity, Hand.transform);
            CardsInHands.Add(newCard);

            Deck.RemoveAt(randomIndex);
 
            }       
        }
        else
        {
            Debug.Log("The Deck is empty.");
        }   
    }
}
 