using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScoreManager : MonoBehaviour
{

    //Variáveis que vão armazenar as pontuações

    private float endScoreGame; // Score final, quando o player morre
    private float hiScoreGame; // HighScore

    //Textos que vão aparecer na tela
    public Text scoreText;
    public Text hiScoreText;

    public ScoreManeger finalScore; //Responsável por fazer a comunicação desse codigo com o ScoreManager


    private void Update()
    {
        GameOver(); // Chama a função no Update para poder executar dentro do jogo
    }

    void GameOver()
    {
        endScoreGame = finalScore.scoreCount;               // Recebe a informação do score do player naquela partida
        scoreText.text = " " + Mathf.Round(endScoreGame);   // Mostra na tela
        hiScoreGame = finalScore.hiScoreCount;              // Recebe a informação do highscore do player 
        hiScoreText.text = " " + Mathf.Round(hiScoreGame);  // Mostra na tela

    }
}
