using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Hand;
    public GameObject Card;
    public List<GameObject> CardsInHands;

    // Start is called before the first frame update
    void Start()
    {
        CardsInHands = new List<GameObject>();
    }
    
    public void OnClick()
    {
        // Instantiate the card as a child of the hand
        GameObject cardInHand = GameObject.Instantiate(Card, Hand.transform.position, Quaternion.identity, Hand.transform);
        
        // Add the instantiated card to the list
        CardsInHands.Add(cardInHand);
    }
}
 /*// Update is called once per frame
    void Update()
    {
        
    }*/