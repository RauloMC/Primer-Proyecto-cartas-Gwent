using UnityEngine;

public class Zone : MonoBehaviour
{
    public string zoneType;
    public delegate void CardPlaceHandler(Card card, string zoneType); // Firma del delegado
    public event CardPlaceHandler OnCardPlaced;

    public void PlaceCard(Card card)
    {
        OnCardPlaced?.Invoke(card, zoneType);
    }
}
