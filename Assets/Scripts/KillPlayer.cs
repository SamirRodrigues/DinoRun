using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public PauseMenu gameOverAtive;

    //public IABoss boss;

    public Attack killPlayer;

    public ScoreManeger theScoreManager;

    private bool vivo = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Caso um objeto com tag Enemy entre no meu trigger
        {
            collision.GetComponent<Enemy>().Kill();

            killPlayer.TakeDamage(vivo);
            
            StartCoroutine(Instance());   
        }
    }

    public void KillP() //Responsável por poder Matar o player em outros scripts
    {
        StartCoroutine(Instance());
    }

    public IEnumerator Instance()
    {
        yield return new WaitForSeconds(1.5f);  // Espera um tempo em segundo para poder executar a próxima linha, usando por base o valor criado na linha anterior
        gameOverAtive.gameIsOver = true; // Chama tela de Game Over
        yield return new WaitForSeconds(1f);
        theScoreManager.scoreCount = 0; // Reseta o Score para a próxima partida
    }
}
