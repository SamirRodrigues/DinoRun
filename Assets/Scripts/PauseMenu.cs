using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false; // Variável criada para verificar se o jogo está pausado
    public bool gameIsOver = false; // Variável criada para verificar se o jogo acabou


    public GameObject pauseMenuUI; // Responsável por ativar e desativar o gameObject (Nesse caso, a janela de Pause)
    public GameObject gameOverUI; // Responsável por ativar e desativar o gameObject (Nesse caso, a janela de Game Over)
    public GameObject scoreUIText; // Responsável por ativar e desativar o gameObject (Nesse caso, a janela de Game Over)
    public GameObject hiScoreUIText; // Responsável por ativar e desativar o gameObject (Nesse caso, a janela de Game Over)


    private void Start()
    {
        Time.timeScale = 1f; //Tempo roda normalmente
        // Foi adicionado pois depois da morte do player o tempo congelava e ao recomeçar a partida o tempo estava freezado
    }

    void Update()
    {
        if (gameIsOver == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape)) // Preciobar ESC me permite acessar a janela de Pause ou voltar ao jogo
            {
                if (gameIsPaused == true)
                {
                    Resume();                    
                }
                else
                {
                    Pause();
                }
            }
           
        }
        else
        {
            GameOver();
        }
    }

    public void Resume() // Se for acionado Resume
    {
        pauseMenuUI.SetActive(false); // Desativa o gameObject
        Time.timeScale = 1f; //Tempo roda normalmente
        gameIsPaused = false; // Informa que o jogo não está pausado
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true); // Ativa o gameObject
        Time.timeScale = 0f; // Congela o tempo
        gameIsPaused = true; // Informa que o jogo está pausado
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        //Debug.Log("Loading Menu... ");
        SceneManager.LoadScene("Menu");
    }

    public void ConfigMenu()
    {
        Debug.Log("Config Menu... ");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game... ");
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    /* ----------------------------- GAME OVER FUNCTIONS ----------------------------- */


    public void GameOver()
    {
        gameOverUI.SetActive(true);         // Ativa o gameObject GameOverUI -- Puxa janela de GameOver
        scoreUIText.SetActive(false);       // Desativa o gameObject do Score -- Desativa os valores de Score
        hiScoreUIText.SetActive(false);     // Desativa o gameObject do HighScore -- Desativa os valores de HighScore
        Time.timeScale = 0f;                // Congela o tempo
    }



}
