using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    public string ZoneType; // Asignar valores como M R S I L C MR >> en el Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Card"))
        {
            Card card = other.GetComponent<Card>();
            if (card != null)
            {
                if (IsValidZoneForCard(card))
                {
                    // Mostrar alguna indicación visual de que la zona es válida
                    Debug.Log("Zona válida para la carta: " + card.CardName);
                }
                else
                {
                    // Mostrar alguna indicación visual de que la zona no es válida
                    Debug.Log("Zona no válida para la carta: " + card.CardName);
                }
            }
        }
    }


    private bool IsValidZoneForCard(Card card)
    {
        // Verifica si el AttackType de la carta es compatible con la zona
        switch (card.Attack)
        {
            case AttackType.M:
                return ZoneType == "M";
            case AttackType.R:
                return ZoneType == "R";
            case AttackType.S:
                return ZoneType == "S";
            case AttackType.MR:
                return ZoneType == "M" || ZoneType == "R";
            case AttackType.MS:
                return ZoneType == "M" || ZoneType == "S";
            case AttackType.RS:
                return ZoneType == "R" || ZoneType == "S";
            case AttackType.MRS:
                return ZoneType == "M" || ZoneType == "R" || ZoneType == "S";
            case AttackType.C:
                return ZoneType == "C";
            case AttackType.L:
                return ZoneType == "L";
            case AttackType.I:
                return ZoneType == "I";
            default:
                return false;
        }
    }
}
