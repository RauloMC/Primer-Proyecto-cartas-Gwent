using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDetailDisplay : MonoBehaviour
{
    public Image cardImage;
    public TMP_Text cardName;
    public TMP_Text cardCost;
    public TMP_Text cardDescription;

    public void ShowCardDetails(Sprite image, string name, int cost, string description)
    {
        cardImage.sprite = image;
        cardName.text = name;
        cardCost.text = "Costo: " + cost.ToString();
        cardDescription.text = description;
        gameObject.SetActive(true);
    }

    public void HideCardDetails()
    {
        gameObject.SetActive(false);
    }
}
