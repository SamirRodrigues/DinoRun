using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManeger : MonoBehaviour
{
    //Textos que vão aparecer na tela
    public Text scoreText; 
    public Text hiScoreText;

    //Variáveis que vão armazenar as pontuações

    public float scoreCount; //Score atual que varia conforme a partida anda   
    public float hiScoreCount; //High Score


    public float pointsPerSeconds; // Variável que vai controlar quantos pontos o player ganha por segundo

    public bool scoreIncreasing; //Controla se vai haver acrescimo de pontos ou não (basicamente verifica se o player ta vivo)


    void Start()
    {
        // Verifica se existe alguma informação de HighScore guardada no pc
        if (PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore"); // Se tiver, a variável recebe esse valor
        }
    }

    
    void Update()
    {
        if (scoreIncreasing == true) //Permite que continue somando pontos
        { 
            scoreCount += pointsPerSeconds * Time.deltaTime; //Logica para acrescentar pontos
        }
        
        hiScoreCount = 0; //Reset HighScore
        if (scoreCount > hiScoreCount) // Define novo highScore
        {
            //hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount); //Armaneza highScore no pc
        }

        scoreText.text = "Score: " + Mathf.Round (scoreCount);   //Atualiza as informações de Score na tela
        hiScoreText.text = "High Score: " + Mathf.Round (hiScoreCount); //Atualiza as informações de HighScore na tela


    }
}
