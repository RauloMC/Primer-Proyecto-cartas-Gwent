using UnityEngine;
using System.Collections.Generic;

public class Tablero : MonoBehaviour
{
    // Prefab de la carta
    public GameObject cardPrefab;

    // Referencias a los jugadores
    public Player player1;
    public Player player2;

    // Jugador actual
    private Player currentPlayer;

    // Zonas de los jugadores
    [Header("Zonas de Jugador 1")]
    public Transform zonaCuerpoACuerpoJ1;
    public Transform zonaAtaqueDistanciaJ1;
    public Transform zonaAsedioJ1;
    public Transform zonaAumentoCuerpoACuerpoJ1;
    public Transform zonaAumentoAtaqueDistanciaJ1;
    public Transform zonaAumentoAsedioJ1;
    public Transform zonaCementerioJ1;
    public Transform zonaMazoJ1;
    public Transform zonaLiderJ1;

    [Header("Zonas de Jugador 2")]
    public Transform zonaCuerpoACuerpoJ2;
    public Transform zonaAtaqueDistanciaJ2;
    public Transform zonaAsedioJ2;
    public Transform zonaAumentoCuerpoACuerpoJ2;
    public Transform zonaAumentoAtaqueDistanciaJ2;
    public Transform zonaAumentoAsedioJ2;
    public Transform zonaCementerioJ2;
    public Transform zonaMazoJ2;
    public Transform zonaLiderJ2;

    [Header("Zona Común")]
    public Transform zonaClimaComun;

    // Diccionario para almacenar las zonas
    private Dictionary<string, Transform> zonas;

    private void Start()
    {
        // Inicializar el diccionario con las zonas
        zonas = new Dictionary<string, Transform>
        {
            { "CuerpoACuerpoJ1", zonaCuerpoACuerpoJ1 },
            { "AtaqueDistanciaJ1", zonaAtaqueDistanciaJ1 },
            { "AsedioJ1", zonaAsedioJ1 },
            { "AumentoCuerpoACuerpoJ1", zonaAumentoCuerpoACuerpoJ1 },
            { "AumentoAtaqueDistanciaJ1", zonaAumentoAtaqueDistanciaJ1 },
            { "AumentoAsedioJ1", zonaAumentoAsedioJ1 },
            { "CementerioJ1", zonaCementerioJ1 },
            { "MazoJ1", zonaMazoJ1 },
            { "LiderJ1", zonaLiderJ1 },

            { "CuerpoACuerpoJ2", zonaCuerpoACuerpoJ2 },
            { "AtaqueDistanciaJ2", zonaAtaqueDistanciaJ2 },
            { "AsedioJ2", zonaAsedioJ2 },
            { "AumentoCuerpoACuerpoJ2", zonaAumentoCuerpoACuerpoJ2 },
            { "AumentoAtaqueDistanciaJ2", zonaAumentoAtaqueDistanciaJ2 },
            { "AumentoAsedioJ2", zonaAumentoAsedioJ2 },
            { "CementerioJ2", zonaCementerioJ2 },
            { "MazoJ2", zonaMazoJ2 },
            { "LiderJ2", zonaLiderJ2 },

            { "ClimaComun", zonaClimaComun }
        };
    }

    // Establece el jugador actual
    public void SetCurrentPlayer(Player player)
    {
        currentPlayer = player;
    }

    // Obtiene el jugador actual
    public Player GetCurrentPlayer()
    {
        return currentPlayer;
    }

    // Cambia el turno entre los jugadores
    public void ChangeTurn()
    {
        if (currentPlayer == player1)
        {
            currentPlayer = player2;
        }
        else
        {
            currentPlayer = player1;
        }
    }

    // Coloca una carta en una zona específica
    public void PlaceCardInZone(Card card, string playerZone)
    {
        Transform zone = ObtenerZona(playerZone);
        if (zone != null)
        {
            // Instanciar el prefab de la carta en la zona
            GameObject cardObject = Instantiate(cardPrefab, zone.position, Quaternion.identity, zone);
            CardComponent cardComponent = cardObject.GetComponent<CardComponent>();

            // Configurar los datos de la carta usando CardComponent
            if (cardComponent != null)
            {
                cardComponent.Initialize(card); // Usar Initialize en CardComponent
            }
            else
            {
                Debug.LogError("El prefab de la carta no contiene un CardComponent.");
            }

            // Notificar al GameManager que se ha colocado una carta
            OnCardPlaced?.Invoke(card, playerZone);
        }
        else
        {
            Debug.LogError("Zona no encontrada: " + playerZone);
        }
    }

    // Obtiene la zona correspondiente a un nombre
    public Transform ObtenerZona(string playerZone)
    {
        if (zonas.TryGetValue(playerZone, out Transform zone))
        {
            return zone;
        }
        Debug.LogError("Zona no encontrada: " + playerZone);
        return null;
    }

    public delegate void CardPlacedHandler(Card card, string playerZone);
    public event CardPlacedHandler OnCardPlaced;
}
