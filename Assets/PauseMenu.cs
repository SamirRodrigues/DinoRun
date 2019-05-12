using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false; // Variável criada para verificar se o jogo está pausado


    public GameObject pauseMenuUI; // Responsável por ativar e desativar o gameObject (Nesse caso, a janela de pause)


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Preciobar ESC me permite acessar a janela de Pause ou voltar ao jogo
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
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
}
