using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnManager : MonoBehaviour
{
    public PlayerDeck player1Deck;
    public PlayerDeck player2Deck;
    public Button passButton;
    public TMP_Text roundText; // Para mostrar el número de ronda

    // Zonas del Jugador 1
    private Image zonaCuerpoACuerpoJ1;
    private Image zonaAtaqueDistanciaJ1;
    private Image zonaAsedioJ1;
    private Image zonaAumentoCuerpoACuerpoJ1;
    private Image zonaAumentoAtaqueDistanciaJ1;
    private Image zonaAumentoAsedioJ1;
    private Image zonaLiderJ1;

    // Zonas del Jugador 2
    private Image zonaCuerpoACuerpoJ2;
    private Image zonaAtaqueDistanciaJ2;
    private Image zonaAsedioJ2;
    private Image zonaAumentoCuerpoACuerpoJ2;
    private Image zonaAumentoAtaqueDistanciaJ2;
    private Image zonaAumentoAsedioJ2;
    private Image zonaLiderJ2;

    private bool isPlayer1Turn = true;
    private bool player1Passed = false;
    private bool player2Passed = false;
    private int currentRound = 1;
    private int maxRounds = 3; // Número máximo de rondas

    void Start()
    {
        InitializeZones(); // Inicializar las zonas al inicio
        StartRound();
        if (passButton != null)
        {
            passButton.onClick.AddListener(OnPassButtonClick);
        }
    }

    void InitializeZones()
    {
        // Buscar y asignar componentes Image del Jugador 1
        zonaCuerpoACuerpoJ1 = GameObject.Find("CuerpoACuerpoJ1")?.GetComponent<Image>();
        zonaAtaqueDistanciaJ1 = GameObject.Find("AtaqueDistanciaJ1")?.GetComponent<Image>();
        zonaAsedioJ1 = GameObject.Find("AsedioJ1")?.GetComponent<Image>();
        zonaAumentoCuerpoACuerpoJ1 = GameObject.Find("AumentoCuerpoACuerpoJ1")?.GetComponent<Image>();
        zonaAumentoAtaqueDistanciaJ1 = GameObject.Find("AumentoAtaqueDistanciaJ1")?.GetComponent<Image>();
        zonaAumentoAsedioJ1 = GameObject.Find("AumentoAsedioJ1")?.GetComponent<Image>();
        zonaLiderJ1 = GameObject.Find("LiderJ1")?.GetComponent<Image>();

        // Buscar y asignar componentes Image del Jugador 2
        zonaCuerpoACuerpoJ2 = GameObject.Find("CuerpoACuerpoJ2")?.GetComponent<Image>();
        zonaAtaqueDistanciaJ2 = GameObject.Find("AtaqueDistanciaJ2")?.GetComponent<Image>();
        zonaAsedioJ2 = GameObject.Find("AsedioJ2")?.GetComponent<Image>();
        zonaAumentoCuerpoACuerpoJ2 = GameObject.Find("AumentoCuerpoACuerpoJ2")?.GetComponent<Image>();
        zonaAumentoAtaqueDistanciaJ2 = GameObject.Find("AumentoAtaqueDistanciaJ2")?.GetComponent<Image>();
        zonaAumentoAsedioJ2 = GameObject.Find("AumentoAsedioJ2")?.GetComponent<Image>();
        zonaLiderJ2 = GameObject.Find("LiderJ2")?.GetComponent<Image>();
    }

    void StartRound()
    {
        player1Passed = false;
        player2Passed = false;
        isPlayer1Turn = true; // El Jugador 1 comienza la primera ronda
        player1Deck.canPlayCards = true;
        player2Deck.canPlayCards = false;
        UpdatePassButtonState();
        UpdateRoundText();
        UpdateZoneOpacity(); // Ajustar la opacidad al inicio de cada ronda
    }

    public void OnPassButtonClick()
    {
        EndTurn();
    }

    public void EndTurn()
    {
        if (isPlayer1Turn)
        {
            player1Passed = true;
            player1Deck.canPlayCards = false;
        }
        else
        {
            player2Passed = true;
            player2Deck.canPlayCards = false;
        }

        if (player1Passed && player2Passed)
        {
            EndRound();
        }
        else
        {
            isPlayer1Turn = !isPlayer1Turn;
            StartPlayerTurn(isPlayer1Turn);
        }
    }

    private void StartPlayerTurn(bool isPlayer1)
    {
        if (isPlayer1)
        {
            player1Deck.canPlayCards = true;
            player2Deck.canPlayCards = false;
            Debug.Log("Turno del Jugador 1.");
        }
        else
        {
            player1Deck.canPlayCards = false;
            player2Deck.canPlayCards = true;
            Debug.Log("Turno del Jugador 2.");
        }
        UpdatePassButtonState();
        UpdateZoneOpacity(); // Ajustar la opacidad al iniciar el turno
    }

    private void UpdatePassButtonState()
    {
        passButton.gameObject.SetActive(player1Deck.canPlayCards || player2Deck.canPlayCards);
    }

    private void UpdateZoneOpacity()
    {
        if (isPlayer1Turn)
        {
            // Zonas del Jugador 1 (Visibles)
            SetZoneOpacity(new Image[]
            {
                zonaCuerpoACuerpoJ1,
                zonaAtaqueDistanciaJ1,
                zonaAsedioJ1,
                zonaAumentoCuerpoACuerpoJ1,
                zonaAumentoAtaqueDistanciaJ1,
                zonaAumentoAsedioJ1,
                zonaLiderJ1
            }, 0f); // Totalmente visible para el jugador 1

            // Zonas del Jugador 2 (Opaque)
            SetZoneOpacity(new Image[]
            {
                zonaCuerpoACuerpoJ2,
                zonaAtaqueDistanciaJ2,
                zonaAsedioJ2,
                zonaAumentoCuerpoACuerpoJ2,
                zonaAumentoAtaqueDistanciaJ2,
                zonaAumentoAsedioJ2,
                zonaLiderJ2
            }, 0.8f); // Semi-transparente para el jugador 2
        }
        else
        {
            // Zonas del Jugador 1 (Opaque)
            SetZoneOpacity(new Image[]
            {
                zonaCuerpoACuerpoJ1,
                zonaAtaqueDistanciaJ1,
                zonaAsedioJ1,
                zonaAumentoCuerpoACuerpoJ1,
                zonaAumentoAtaqueDistanciaJ1,
                zonaAumentoAsedioJ1,
                zonaLiderJ1
            }, 0.8f); // Semi-transparente para el jugador 1

            // Zonas del Jugador 2 (Visibles)
            SetZoneOpacity(new Image[]
            {
                zonaCuerpoACuerpoJ2,
                zonaAtaqueDistanciaJ2,
                zonaAsedioJ2,
                zonaAumentoCuerpoACuerpoJ2,
                zonaAumentoAtaqueDistanciaJ2,
                zonaAumentoAsedioJ2,
                zonaLiderJ2
            }, 0f); // Totalmente visible para el jugador 2
        }
    }

    private void SetZoneOpacity(Image[] zones, float opacity)
    {
        foreach (Image zone in zones)
        {
            if (zone != null)
            {
                Color color = zone.color;
                color.a = opacity; // Ajusta la opacidad
                zone.color = color;
            }
        }
    }

    void EndRound()
    {
        if (currentRound >= maxRounds)
        {
            EndGame();
        }
        else
        {
            currentRound++;
            StartRound();
        }
    }

    void EndGame()
    {
        // Lógica para finalizar el juego, determinar al ganador, etc.
        Debug.Log("El juego ha terminado.");
    }

    void UpdateRoundText()
    {
        if (roundText != null)
        {
            roundText.text = "Ronda: " + currentRound;
        }
    }
}
