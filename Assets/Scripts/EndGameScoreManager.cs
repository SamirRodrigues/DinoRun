using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScoreManager : MonoBehaviour
{

    //Variáveis que vão armazenar as pontuações

    private float endScoreGame; // Score final, quando o player morre

    //Textos que vão aparecer na tela
    public Text scoreText;

    public ScoreManeger finalScore;


    private void Start()
    {
        finalScore = FindObjectOfType<ScoreManeger>();
    }

    private void Update()
    {
        GameOver();
    }

    void GameOver()
    {
        endScoreGame = finalScore.scoreCount;
        scoreText.text = " " + Mathf.Round(endScoreGame);

    }
}
