using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Paneles del tablero principal
    public GameObject player1Panel;
    public GameObject player2Panel;

    // Referencias a los componentes de los paneles
    public TMP_Text player1NameText;
    public Image player1Image;
    public TMP_Text player1ScoreText;

    public TMP_Text player2NameText;
    public Image player2Image;
    public TMP_Text player2ScoreText;

    public Player player1; // Referencia al jugador 1
    public Player player2; // Referencia al jugador 2
    public Mulligan mulliganUIManager; // Referencia al manejador de UI de Mulligan
    public Tablero tablero; // Referencia al tablero

    private void Awake()
    {
        // Asigna las referencias desde los paneles
        player1NameText = player1Panel.transform.Find("NombreJ1").GetComponent<TMP_Text>();
        player1Image = player1Panel.transform.Find("FotoJugador1").GetComponent<Image>();
        player1ScoreText = player1Panel.transform.Find("PuntuacionJ1").GetComponent<TMP_Text>();

        player2NameText = player2Panel.transform.Find("NombreJ2").GetComponent<TMP_Text>();
        player2Image = player2Panel.transform.Find("FotoJugador2").GetComponent<Image>();
        player2ScoreText = player2Panel.transform.Find("PuntuacionJ2").GetComponent<TMP_Text>();

    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        player1.DrawInitialCards();
        player2.DrawInitialCards();

        // Llamar al método para mostrar el panel de mulligan después de robar las cartas iniciales
        ShowMulliganPanel();
    }

    private void ShowMulliganPanel()
    {
        // Mostrar el panel de mulligan
        mulliganUIManager.ShowMulliganPanel();
    }

    public void SetPlayers(PlayerInfo player1Info, PlayerInfo player2Info)
    {
        // Inicializa los paneles de los jugadores
        player1NameText.text = player1Info.Name;
        player1Image.sprite = player1Info.Photo;
        player1ScoreText.text = "Score: 0"; // Inicia la puntuación

        player2NameText.text = player2Info.Name;
        player2Image.sprite = player2Info.Photo;
        player2ScoreText.text = "Score: 0"; // Inicia la puntuación
    }

   
}

