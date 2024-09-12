using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text player1ScoreText;
    public TMP_Text player2ScoreText;
    
    [Header("Zonas de Jugador 1")]
    public Transform zonaCuerpoACuerpoJ1;
    public Transform zonaAtaqueDistanciaJ1;
    public Transform zonaAsedioJ1;
    public Transform zonaAumentoCuerpoACuerpoJ1;
    public Transform zonaAumentoAtaqueDistanciaJ1;
    public Transform zonaAumentoAsedioJ1;
    public Transform zonaCementerioJ1;
    public Transform zonaLiderJ1;

    [Header("Zonas de Jugador 2")]
    public Transform zonaCuerpoACuerpoJ2;
    public Transform zonaAtaqueDistanciaJ2;
    public Transform zonaAsedioJ2;
    public Transform zonaAumentoCuerpoACuerpoJ2;
    public Transform zonaAumentoAtaqueDistanciaJ2;
    public Transform zonaAumentoAsedioJ2;
    public Transform zonaCementerioJ2;
    public Transform zonaLiderJ2;

    [Header("Zona Común")]
    public Transform zonaClimaComun;

    private void Update()
    {
        UpdateScores();
    }

    private void UpdateScores()
    {
        int player1Score = CalculateScoreForPlayer(zonaCuerpoACuerpoJ1, zonaAtaqueDistanciaJ1, zonaAsedioJ1);
        int player2Score = CalculateScoreForPlayer(zonaCuerpoACuerpoJ2, zonaAtaqueDistanciaJ2, zonaAsedioJ2);

        player1ScoreText.text = "Score: " + player1Score;
        player2ScoreText.text = "Score: " + player2Score;
    }

    private int CalculateScoreForPlayer(params Transform[] zones)
    {
        int totalScore = 0;

        foreach (Transform zone in zones)
        {
            foreach (Transform child in zone)
            {
                CardComponent cardComponent = child.GetComponent<CardComponent>();
                if (cardComponent != null)
                {
                    totalScore += cardComponent.cardData.Power;
                }
            }
        }

        return totalScore;
    }
}
