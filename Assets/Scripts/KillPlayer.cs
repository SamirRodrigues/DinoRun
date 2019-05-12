using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public PauseMenu gameOverAtive;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Caso um objeto com tag Enemy entre no meu trigger
        {
            // collision.GetComponent<Enemy>().AumentaVel(speedLVL);   // Aumenta a velocidade geral dos meus inimigos para a velocidade de speedLVL

            gameOverAtive.gameIsOver = true; // Chama tela de Game Over

        }
    }
}
