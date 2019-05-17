using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public IABoss bossInteration;    // Interações com o boss
    public ScoreManeger reset;       // Responsável por resetar a dificuldade do jogo

    public static bool gameIsPaused = false;    // Variável criada para verificar se o jogo está pausado
    public bool gameIsOver = false;             // Variável criada para verificar se o jogo acabou


    public GameObject pauseMenuUI;      // Responsável por ativar e desativar o gameObject (Nesse caso, a janela de Pause)
    public GameObject gameOverUI;       // Responsável por ativar e desativar o gameObject (Nesse caso, a janela de Game Over)
    public GameObject scoreUIText;      // Responsável por ativar e desativar o gameObject (Nesse caso, o texto de Score)
    public GameObject hiScoreUIText;    // Responsável por ativar e desativar o gameObject (Nesse caso, o texto de HighScore)

    


    private void Start()
    {
        Time.timeScale = 1f; //Tempo roda normalmente
        // Foi adicionado pois depois da morte do player o tempo congelava e ao recomeçar a partida o tempo estava freezado
    }

    void Update()
    {
        if (gameIsOver == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape)) // Precionar ESC me permite acessar a janela de Pause ou voltar ao jogo
            {
                if (gameIsPaused == true)
                {
                    Resume();           // Se o jogo estiver pausado e o usuário apertar ESC, volta o jogo   
                }
                else
                {
                    Pause();            // Se o jogo não está pausado e o usuário apertar ESC, pausa o jogo
                }
            }
           
        }
        else
        {
            GameOver();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);       // Desativa o gameObject
        Time.timeScale = 1f;                //Tempo roda normalmente
        gameIsPaused = false;               // Informa que o jogo não está pausado
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);    // Ativa o gameObject
        Time.timeScale = 0f;            // Congela o tempo
        gameIsPaused = true;            // Informa que o jogo está pausado
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;                // Descongela o tempo
        SceneManager.LoadScene("Menu");     // Acessa a cena Menu
    }
    
    public void QuitGame()
    {
        Application.Quit(); // Fecha o jogo
    }

    public void Restart()
    {
        bossInteration.missTakesCount = 0;  // Zera as informações do boss
        bossInteration.aux = 0;             // Zera as informações do boss
        reset.ResetDifficulty();            // Reseta a dificuldade do jogo
        SceneManager.LoadScene("Game");     // Recomeça o jogo
    }

    /* ----------------------------- GAME OVER FUNCTIONS ----------------------------- */


    public void GameOver()
    {
        gameOverUI.SetActive(true);         // Ativa o gameObject GameOverUI -- Puxa janela de GameOver
        scoreUIText.SetActive(false);       // Desativa o gameObject do Score -- Desativa os valores de Score
        hiScoreUIText.SetActive(false);     // Desativa o gameObject do HighScore -- Desativa os valores de HighScore
        reset.ResetDifficulty();            // Reseta a dificuldade do jogo
        Time.timeScale = 0f;                // Congela o tempo
    }



}
