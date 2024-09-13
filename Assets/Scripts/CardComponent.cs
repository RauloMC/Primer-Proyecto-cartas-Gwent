using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardComponent : MonoBehaviour
{
    // Referencias a los elementos visuales de la carta
    public Image cardImage;                
    public TextMeshProUGUI cardName;       
    public TextMeshProUGUI cardDescription; 
    public TextMeshProUGUI cardPower;    
    public Unidad unitType;
    public SpecialAbility ability;

    // Objeto de datos de la carta
    public Card cardData;

    // Método para inicializar la carta con datos específicos
    public void Initialize(Card card)
    {
        unitType=card.UnitType;
        ability=card.Ability;

        cardData = card;    // Asignar los datos de la carta
        UpdateCardDisplay(); // Actualizar la visualización de la carta
    }

    // Actualiza los elementos visuales con los datos de la carta
    private void UpdateCardDisplay()
    {
        if (cardData != null)
        {
            cardName.text = cardData.CardName; 
            cardDescription.text = cardData.CardDescription; 
            cardPower.text = cardData.Power.ToString(); 
            cardImage.sprite = cardData.ThisImage; 

        }
    }
}
