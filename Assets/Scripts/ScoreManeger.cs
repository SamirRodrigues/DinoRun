using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManeger : MonoBehaviour
{
    //Textos que vão aparecer na tela
    public Text scoreText; 
    public Text hiScoreText;

    // Variáveis que vão armazenar as pontuações

    public float scoreCount;    // Score atual que varia conforme a partida anda   
    public float hiScoreCount;  // High Score


    public float pointsPerSeconds;  // Variável que vai controlar quantos pontos o player ganha por segundo
    public bool scoreRun;           //Controla se o Score vai continuar aumentando (basicamente verifica se o player ta vivo)

    //DifficultyProgression
    private int aux;
    public BackGround velBackGround;
    public Enemy velEnemyG;
    public Enemy velEnemyS;
    public Wood velEnemyW;

    private float atualScore;
    public float maxDifficultyProgression = 901; // Valor que vai definir onde o jogo se mantem no nível mais dificil


    void Start()
    {
        // Verifica se existe alguma informação de HighScore guardada no pc
        if (PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore"); // Se tiver, a variável recebe esse valor
        }
        ResetDifficulty();
    }

    
    void Update()
    {
        if (scoreRun == true) // Permite que continue somando pontos
        { 
            scoreCount += pointsPerSeconds * Time.deltaTime; // Logica para acrescentar pontos
        }
        
        //hiScoreCount = 0; //Reset HighScore
        if (scoreCount > hiScoreCount) // Define novo highScore
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount); // Armaneza highScore no pc
        }

        scoreText.text = "Score: " + Mathf.Round (scoreCount);          // Atualiza as informações de Score na tela
        hiScoreText.text = "High Score: " + Mathf.Round (hiScoreCount); // Atualiza as informações de HighScore na tela


        DifficultyProgression();
    }

    void DifficultyProgression()
    {
        if (aux == 0)
        {
            if (scoreCount <= maxDifficultyProgression)
            {
                atualScore = scoreCount;
                aux = 1;
            }
            
        }
        else if(aux == 1)
        {
            if (scoreCount >= atualScore + 150) // Incrementa a dificuldade a cada 150 pontos
            {
                velBackGround.vel += 0.2f;
                velEnemyW.vel += 0.2f;
                velEnemyG.vel += 1.5f;
                velEnemyS.vel += 1.5f;
                pointsPerSeconds += 2;
                aux = 0;
            }
            
        }
    }

    public void ResetDifficulty()
    {
        velBackGround.vel = 1f;
        velEnemyG.vel = 3f;
        velEnemyS.vel = 3f;
        velEnemyW.vel = 8f;
    }
}
